﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using GameLib;

namespace Jamestown
{
    public enum MapMode
    {
        Terrain,
        Height
    }

    public partial class MapControl : UserControl
    {

        public delegate void MouseOver(int x, int y);
        public delegate void SelectBuilding(Building b);
        public delegate void SelectZone(ZonedOrder order);
        public delegate void FinishedDrawArea(int x, int y, int width, int height);

        public event MouseOver MouseOverChanged;
        public event SelectBuilding SelectedBuildingChanged;
        public event SelectZone SelectedZoneChanged;
        public event FinishedDrawArea OnDrawArea;

        private int tileSize_ = 16;
        public int TileSize
        {
            get { return tileSize_; }
            set
            {
                if(tileSize_ != value)
                {
                    tileSize_ = value;
                    Invalidate();
                }
            }
        }

        private Point lookLocation_;
        public Point LookLocation
        {
            get { return lookLocation_; }
            set
            {
                if(lookLocation_ != value)
                {
                    lookLocation_ = value;
                    Invalidate();
                }
            }
        }

        private Settlement settlement_;
        private Map map_;
        public Settlement Settlement
        {
            get { return settlement_; }
            set
            {
                if(settlement_ != value)
                {
                    settlement_ = value;
                    map_ = settlement_.Map;
                    Invalidate();
                }
            }
        }

        private Building selectedBuilding_;
        public Building SelectedBuilding
        {
            get { return selectedBuilding_; }
            set
            {
                if (selectedBuilding_ != value)
                {
                    selectedBuilding_ = value;
                    Invalidate();
                }
            }
        }

        public ZonedOrder selectedZone_;
        public ZonedOrder SelectedZone
        {
            get { return selectedZone_; }
            set
            {
                if (selectedZone_ != value)
                {
                    selectedZone_ = value;
                    Invalidate();
                }
            }
        }

        private MapMode mode_ = MapMode.Terrain;
        public MapMode Mode
        {
            get { return mode_; }
            set
            {
                if(mode_ != value)
                {
                    mode_ = value;
                    Invalidate();
                }
            }
        }

        private Color selectAreaColor_ = Color.AliceBlue;
        public Color SelectAreaColor
        {
            get { return selectAreaColor_; }
            set
            {
                if(selectAreaColor_ != value)
                {
                    selectAreaColor_ = value;
                    Invalidate();
                }
            }
        }

        public bool CurrentlyDrawingArea
        {
            get { return selectingArea_; }
        }
        public Rectangle DrawingArea
        {
            get
            {
                int left = Math.Min(selectedAreaStart_.X, selectedAreaEnd_.X);
                int top = Math.Min(selectedAreaStart_.Y, selectedAreaEnd_.Y);
                int width = Math.Abs(selectedAreaStart_.X - selectedAreaEnd_.X);
                int height = Math.Abs(selectedAreaStart_.Y - selectedAreaEnd_.Y);
                return new Rectangle(left, top, width, height);
            }
        }

        private Brush[] tileColors = new Brush[4] { Brushes.YellowGreen, Brushes.DarkGreen, Brushes.SaddleBrown, Brushes.Blue };

        private Point mouseDownPt_;
        private Point mouseOverTile_;

        private Point startDragPt_;
        private bool dragging_ = false;

        private bool selectingArea_ = false;
        private Point selectedAreaStart_;
        private Point selectedAreaEnd_;

        public MapControl()
        {
            InitializeComponent();
        }

        private PointF ToClient(SharpDX.Vector3 v)
        {
            return new PointF(v.X * 10.0f - lookLocation_.X, v.Z * 10.0f - lookLocation_.Y);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.Clear(Color.Black);
            if (map_ == null)
                return;

            int tileWidth = ClientSize.Width / tileSize_;
            int tileHeight = ClientSize.Height / tileSize_;
            int startX = Math.Max(lookLocation_.X / tileSize_, 0);
            int startY = Math.Max(lookLocation_.Y / tileSize_, 0);
            int endX = Math.Min(startX + tileWidth+1, map_.Width);
            int endY = Math.Min(startY + tileHeight+1, map_.Height);

            Size size = new Size(tileSize_, tileSize_);
            for(int j = startY; j < endY; ++j)
            {
                int top = j * tileSize_ - lookLocation_.Y;

                for (int i = startX; i < endX; ++i)
                {
                    Point topLeft = new Point(i * tileSize_ - lookLocation_.X, top);
                    if(mode_ == MapMode.Height)
                    { 
                        int height = map_.GetHeight(i, j);
                        if(height < 0)
                        {
                            using (Brush brush = new SolidBrush(Color.FromArgb(0, 0, 255 + height)))
                            {
                                e.Graphics.FillRectangle(brush, new Rectangle(topLeft, size));
                            }
                        }
                        else
                        {
                            using (Brush brush = new SolidBrush(Color.FromArgb(0, height, 0)))
                            {
                                e.Graphics.FillRectangle(brush, new Rectangle(topLeft, size));
                            }
                        }
                    }
                    else
                    {
                        LandType type = map_.GetType(i, j);
                        e.Graphics.FillRectangle(tileColors[(int)type], new Rectangle(topLeft, size));
                    }
                }
            }

            foreach(Building building in settlement_.Buildings)
            {
                Point topLeft = new Point(building.X * tileSize_ - lookLocation_.X, building.Y * tileSize_ - lookLocation_.Y);
                Size buildingSize = new Size(building.Width * tileSize_, building.Height * tileSize_);
                using (Brush brush = new SolidBrush(Color.Brown))
                {
                    e.Graphics.FillRectangle(brush, new Rectangle(topLeft, buildingSize));
                }
            }

            for (int j = startY; j < endY; ++j)
            {
                int top = j * tileSize_ - lookLocation_.Y;

                for (int i = startX; i < endX; ++i)
                {
                    Point topLeft = new Point(i * tileSize_ - lookLocation_.X, top);
                    if (mode_ == MapMode.Terrain)
                    {
                        TreeType type = map_.GetTree(i, j);
                        if(type == TreeType.Oak)
                        {
                            RectangleF rect = new RectangleF(topLeft, new Size(5 * tileSize_, 5 * tileSize_));
                            rect.Offset(-2.5f * tileSize_, -2.5f * tileSize_);
                            e.Graphics.FillEllipse(Brushes.Green, rect);
                        }
                    }
                }
            }

            if (selectedBuilding_ != null)
            {
                Point topLeft = new Point(selectedBuilding_.X * tileSize_ - lookLocation_.X, selectedBuilding_.Y * tileSize_ - lookLocation_.Y);
                Size buildingSize = new Size(selectedBuilding_.Width * tileSize_, selectedBuilding_.Height * tileSize_);
                Rectangle rect = new Rectangle(topLeft, buildingSize);
                DrawSelection(e.Graphics, rect);
            }

            foreach (var order in settlement_.Orders)
            {
                ZonedOrder zo = order as ZonedOrder;
                if(zo != null)
                {
                    DrawArea(e.Graphics, zo.X, zo.Y, zo.Width, zo.Height, zo.Color, zo == selectedZone_);
                }
            }

            if (selectingArea_)
            {
                int left = Math.Min(selectedAreaStart_.X, selectedAreaEnd_.X);
                int top = Math.Min(selectedAreaStart_.Y, selectedAreaEnd_.Y);
                int width = Math.Abs(selectedAreaStart_.X - selectedAreaEnd_.X);
                int height = Math.Abs(selectedAreaStart_.Y - selectedAreaEnd_.Y);
                DrawArea(e.Graphics, left, top, width, height, selectAreaColor_, false);
            }
        }

        private static void DrawSelection(Graphics G, Rectangle rect)
        {
            rect.Inflate(5, 5);
            using (Pen p = new Pen(Color.Red, 3))
            {
                G.DrawLines(p, new Point[] { new Point(rect.Left, rect.Top + 20), new Point(rect.Left, rect.Top), new Point(rect.Left + 20, rect.Top) });
                G.DrawLines(p, new Point[] { new Point(rect.Right - 20, rect.Top), new Point(rect.Right, rect.Top), new Point(rect.Right, rect.Top + 20) });
                G.DrawLines(p, new Point[] { new Point(rect.Left, rect.Bottom - 20), new Point(rect.Left, rect.Bottom), new Point(rect.Left + 20, rect.Bottom) });
                G.DrawLines(p, new Point[] { new Point(rect.Right - 20, rect.Bottom), new Point(rect.Right, rect.Bottom), new Point(rect.Right, rect.Bottom - 20) });
            }
        }

        private void DrawArea(Graphics G, int left, int top, int width, int height, Color baseColor, bool selected)
        {
            Rectangle rect = new Rectangle(left * tileSize_ - lookLocation_.X, top * tileSize_ - lookLocation_.Y, width * tileSize_, height * tileSize_);

            using (Brush b = new SolidBrush(Color.FromArgb(100, baseColor)))
            {
                G.FillRectangle(b, rect);
            }
            using (Pen p = new Pen(baseColor, 2))
            {
                G.DrawRectangle(p, rect);
            }

            if(selected)
            {
                DrawSelection(G, rect);
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            mouseDownPt_ = e.Location;
            startDragPt_ = e.Location;
            if (e.Button == MouseButtons.Right)
                dragging_ = true;
            else if (e.Button == MouseButtons.Left)
            {
                selectedAreaStart_ = selectedAreaEnd_ = ClientToTile(e.Location);
                selectingArea_ = true;
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (dragging_)
            {
                lookLocation_.X -= e.Location.X - startDragPt_.X;
                lookLocation_.Y -= e.Location.Y - startDragPt_.Y;
                startDragPt_ = e.Location;
                Invalidate();
            }
            else if(selectingArea_)
            {
                selectedAreaEnd_ = ClientToTile(e.Location);
                Invalidate();
            }

            Point currTile = ClientToTile(e.Location);
            if (currTile.X < 0 || currTile.X >= map_.Width || currTile.Y < 0 || currTile.Y >= map_.Height)
            {
                currTile = new Point(-1, -1);
            }
            if (currTile != mouseOverTile_)
            {
                mouseOverTile_ = currTile;
                if(MouseOverChanged != null)
                    MouseOverChanged(mouseOverTile_.X, mouseOverTile_.Y);
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            dragging_ = false;

            if(selectingArea_)
            { 
                if(selectedAreaStart_ == selectedAreaEnd_)
                {
                    Point tile = ClientToTile(e.Location);
                    Building clickedBuilding = settlement_.GetBuildingOn(tile.X, tile.Y);
                    ZonedOrder clickedOrder = settlement_.GetZoneOn(tile.X, tile.Y);
                    if(clickedBuilding != selectedBuilding_)
                    {
                        selectedBuilding_ = clickedBuilding;
                        if(SelectedBuildingChanged != null)
                            SelectedBuildingChanged(selectedBuilding_);
                    }
                    if(clickedOrder != selectedZone_)
                    {
                        selectedZone_ = clickedOrder;
                        if (SelectedZoneChanged != null)
                            SelectedZoneChanged(selectedZone_);
                    }
                    
                }
                else
                {
                    if (OnDrawArea != null)
                    {
                        int left = Math.Min(selectedAreaStart_.X, selectedAreaEnd_.X);
                        int top = Math.Min(selectedAreaStart_.Y, selectedAreaEnd_.Y);
                        int width = Math.Abs(selectedAreaStart_.X - selectedAreaEnd_.X);
                        int height = Math.Abs(selectedAreaStart_.Y - selectedAreaEnd_.Y);
                        OnDrawArea(left, top, width, height);
                    }
                }
                selectingArea_ = false;
                Invalidate();
            }
        }

        private Point ClientToTile(Point p)
        {
            return new Point((lookLocation_.X + p.X) / tileSize_, (lookLocation_.Y + p.Y) / tileSize_);
        }
    }
}