using System;
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
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.IO;

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
        public delegate void VisibleAreaChanged(Rectangle area);

        public event MouseOver MouseOverChanged;
        public event SelectBuilding SelectedBuildingChanged;
        public event SelectZone SelectedZoneChanged;
        public event FinishedDrawArea OnDrawArea;
        public event VisibleAreaChanged OnVisibleAreaChanged;

        private int tileSize_ = 16;
        public int TileSize
        {
            get { return tileSize_; }
            set
            {
                if(tileSize_ != value)
                {
                    double centerX = lookLocation_.X + ClientSize.Width / (double)tileSize_ * 0.5;
                    double centerY = lookLocation_.Y + ClientSize.Height / (double)tileSize_ * 0.5;
                    centerX = centerX * (value / (double)tileSize_);
                    centerY = centerY * (value / (double)tileSize_);
                    tileSize_ = value;
                    lookLocation_.X = (int)(centerX - ClientSize.Width / (double)tileSize_ * 0.5);
                    lookLocation_.Y = (int)(centerY - ClientSize.Height / (double)tileSize_ * 0.5);
                    Invalidate();

                    if (OnVisibleAreaChanged != null)
                    {
                        OnVisibleAreaChanged(VisibleArea);
                    }
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

                    if (OnVisibleAreaChanged != null)
                    {
                        OnVisibleAreaChanged(VisibleArea);
                    }
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
                    UpdateBaseMap();
                    UpdateTreeMap();
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

        public Rectangle VisibleArea
        {
            get
            {
                int tileWidth = ClientSize.Width / tileSize_;
                int tileHeight = ClientSize.Height / tileSize_;
                return new Rectangle(lookLocation_.X / tileSize_, lookLocation_.Y / tileSize_, tileWidth, tileHeight);
            }
            set
            {
                lookLocation_.X = value.X * tileSize_;
                lookLocation_.Y = value.Y * tileSize_;
                Invalidate();
            }
        }

        public Image MapImage
        {
            get
            {
                return basicLand_;
            }
        }

        private Color[] tileColors_ = new Color[3] { Color.YellowGreen, Color.DarkGreen, Color.Blue };
        private Brush[] tileBrushes_;

        private Point mouseDownPt_;
        private Point mouseOverTile_;

        private Point startDragPt_;
        private bool dragging_ = false;

        private bool selectingArea_ = false;
        private Point selectedAreaStart_;
        private Point selectedAreaEnd_;

        private Bitmap basicLand_;
        private Bitmap treeLand_;

        private Image shipImage_ = null;

        public MapControl()
        {
            InitializeComponent();

            if (tileColors_.Length != Enum.GetNames(typeof(LandType)).Length)
                throw new Exception("Mismatched land types and colors");

            tileBrushes_ = new Brush[tileColors_.Length];
            for(int i = 0; i < tileColors_.Length; ++i)
            {
                tileBrushes_[i] = new SolidBrush(tileColors_[i]);
            }

            if(File.Exists("three_mast.png"))
                shipImage_ = Image.FromFile("three_mast.png");
        }

        public void NewTurn()
        {
            UpdateTreeMap();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.Clear(Color.Black);
            if (map_ == null)
                return;

            int tileWidth = (int)Math.Ceiling(ClientSize.Width / (double)tileSize_) + 1;
            int tileHeight = (int)Math.Ceiling(ClientSize.Height / (double)tileSize_) + 1;
            int startX = Math.Max(lookLocation_.X / tileSize_, 0);
            int startY = Math.Max(lookLocation_.Y / tileSize_, 0);

            //Draw the background.
            DrawBitmap(e.Graphics, basicLand_, tileWidth, tileHeight, startX, startY, false);

            foreach(Building building in settlement_.Buildings)
            {
                Point topLeft = new Point(building.X * tileSize_ - lookLocation_.X, building.Y * tileSize_ - lookLocation_.Y);
                Size buildingSize = new Size(building.Width * tileSize_, building.Height * tileSize_);
                using (Brush brush = new SolidBrush(Color.Brown))
                {
                    e.Graphics.FillRectangle(brush, new Rectangle(topLeft, buildingSize));
                }
            }

            //Draw the trees.
            //DrawBitmap(e.Graphics, treeLand_, tileWidth, tileHeight, startX, startY, true);
            int treeStartX = Math.Max(startX - TreeType.MaxCanopySize, 0);
            int treeStartY = Math.Max(startY - TreeType.MaxCanopySize, 0);
            int treeEndX = Math.Min(startX + tileWidth + TreeType.MaxCanopySize, map_.Width);
            int treeEndY = Math.Min(startY + tileHeight + TreeType.MaxCanopySize, map_.Height);
            for (int y = treeStartY; y < treeEndY; ++y)
            {
                for (int x = treeStartX; x < treeEndX; ++x)
                {
                    Point topLeft = new Point(x * tileSize_ - lookLocation_.X, y * tileSize_ - lookLocation_.Y);
                    Tree tree = map_.GetTree(x, y);
                    if (tree != null)
                    {
                        if (tree.IsStump)
                        {
                            RectangleF rect = new RectangleF(topLeft, new SizeF(tree.Diameter * tileSize_, tree.Diameter * tileSize_));
                            rect.Offset(-tree.Diameter * tileSize_ * 0.5f, -tree.Diameter * tileSize_ * 0.5f);
                            e.Graphics.FillEllipse(Brushes.SaddleBrown, rect);
                        }
                        else
                        {
                            RectangleF rect = new RectangleF(topLeft, new SizeF(tree.CanopySize * tileSize_, tree.CanopySize * tileSize_));
                            rect.Offset(-tree.CanopySize * tileSize_ * 0.5f, -tree.CanopySize * tileSize_ * 0.5f);
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

            if(shipImage_ != null)
            {
                foreach (var ship in settlement_.ShipsInPort)
                {
                    Point topLeft = new Point(ship.X * tileSize_ - lookLocation_.X, ship.Y * tileSize_ - lookLocation_.Y);
                    e.Graphics.DrawImage(shipImage_, topLeft.X, topLeft.Y, shipImage_.Width / 4, shipImage_.Height / 4);
                }
            }

            foreach (var order in settlement_.Orders)
            {
                ZonedOrder zo = order as ZonedOrder;
                if (zo != null)
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

        private void DrawBitmap(Graphics G, Image image, int tileWidth, int tileHeight, int startX, int startY, bool useTransparent)
        {
            Rectangle sourceRect = new Rectangle(startX, startY, tileWidth, tileHeight);
            Rectangle dstRect = new Rectangle(new Point(startX * tileSize_ - lookLocation_.X, startY * tileSize_ - lookLocation_.Y), new Size(tileWidth * tileSize_, tileHeight * tileSize_));
            G.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            G.DrawImage(image, dstRect, sourceRect, GraphicsUnit.Pixel);
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

                if(OnVisibleAreaChanged != null)
                {
                    OnVisibleAreaChanged(VisibleArea);
                }
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
                        int left = Math.Max(Math.Min(selectedAreaStart_.X, selectedAreaEnd_.X), 0);
                        int top = Math.Max(Math.Min(selectedAreaStart_.Y, selectedAreaEnd_.Y), 0);
                        int right = Math.Min(Math.Max(selectedAreaStart_.X, selectedAreaEnd_.X), map_.Width);
                        int bottom = Math.Min(Math.Max(selectedAreaStart_.Y, selectedAreaEnd_.Y), map_.Height);

                        OnDrawArea(left, top, right - left, bottom - top);
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

        private void UpdateBaseMap()
        {
            basicLand_ = new Bitmap(map_.Width, map_.Height);
            BitmapData bitmapData = basicLand_.LockBits(new Rectangle(0, 0, map_.Width, map_.Height), ImageLockMode.WriteOnly, PixelFormat.Format32bppRgb);

            int[] row = new int[bitmapData.Stride/4];
            for(int y = 0; y < map_.Height; ++y)
            {
                for(int x = 0; x < map_.Width; ++x)
                {
                    row[x] = tileColors_[(int)map_.GetType(x, y)].ToArgb();
                }
                Marshal.Copy(row, 0, bitmapData.Scan0 + y * bitmapData.Stride, bitmapData.Stride / 4);
            }
            basicLand_.UnlockBits(bitmapData);

            Invalidate();
        }

        public void UpdateTreeMap()
        {
#if false
            treeLand_ = new Bitmap(map_.Width, map_.Height, PixelFormat.Format32bppPArgb);
            using (Graphics G = Graphics.FromImage(treeLand_))
            {
                for (int y = 0; y < map_.Height; ++y)
                {
                    for (int x = 0; x < map_.Width; ++x)
                    {
                        Point topLeft = new Point(x, y);
                        Tree tree = map_.GetTree(x, y);
                        if (tree != null)
                        {
                            if (tree.Stump)
                            {
                                RectangleF rect = new RectangleF(topLeft, new SizeF(tree.Diameter, tree.Diameter));
                                rect.Offset(-tree.Diameter * 0.5f, -tree.Diameter * 0.5f);
                                G.FillEllipse(Brushes.Brown, rect);
                            }
                            else
                            {
                                RectangleF rect = new RectangleF(topLeft, new SizeF(tree.CanopySize, tree.CanopySize));
                                rect.Offset(-tree.CanopySize * 0.5f, -tree.CanopySize * 0.5f);
                                G.FillEllipse(Brushes.Green, rect);
                            }
                        }
                    }
                }
            }

#endif
            Invalidate();
        }
    }
}
