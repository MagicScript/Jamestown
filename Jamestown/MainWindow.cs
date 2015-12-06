using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jamestown
{
    public partial class MainWindow : Form
    {
        GameLib.Game game_ = new GameLib.Game();
        GameLib.Settlement settlement_;

        public MainWindow()
        {
            InitializeComponent();
            settlement_ = game_.Settlements.First();

            mainMap.Settlement = settlement_;
            mainMap.TileSize = 4;
            mainMap.LookLocation = new Point(0, 0);
            mainMap.MouseOverChanged += MainMap_MouseOverChanged;
            mainMap.SelectedBuildingChanged += MainMap_SelectedBuildingChanged;
            mainMap.SelectedZoneChanged += MainMap_SelectedZoneChanged;
            mainMap.OnDrawArea += MainMap_OnSelectArea;

            settlementInspector_.Settlement = settlement_;
            settlementInspector_.Visible = true;

            terrainLabel.Text = "None";
            UpdateSelectionText();
            DoSelect(null, null);
        }

        private void MainMap_OnSelectArea(int x, int y, int width, int height)
        {
            if(settlementInspector_.CurrentAction == ActionType.PlaceChopZone)
            {
                settlement_.AddOrder(new GameLib.ClearTreesOrder(settlement_, x, y, width, height));
                settlementInspector_.Update();
            }
            else if(settlementInspector_.CurrentAction == ActionType.PlaceHuntZone)
            {
                settlement_.AddOrder(new GameLib.HuntOrder(settlement_, x, y, width, height));
                settlementInspector_.Update();
            }
            UpdateSelectionText();
        }

        private void MainMap_SelectedBuildingChanged(GameLib.Building b)
        {
            DoSelect(mainMap.SelectedBuilding, mainMap.SelectedZone);
        }

        private void MainMap_SelectedZoneChanged(GameLib.ZonedOrder order)
        {
            DoSelect(mainMap.SelectedBuilding, mainMap.SelectedZone);
        }


        private void DoSelect(GameLib.Building building, GameLib.ZonedOrder order)
        {
            if (building == null && order == null)
            {
                settlementInspector_.Visible = true;
                buildingInspector_.Visible = false;
                zonedOrderInspector.Visible = false;
            }
            else if (order != null)
            {
                settlementInspector_.Visible = false;

                buildingInspector_.Visible = false;
                zonedOrderInspector.Order = order;
                zonedOrderInspector.Visible = true;
            }
            else if (building != null)
            {
                settlementInspector_.Visible = false;

                buildingInspector_.Building = building;
                buildingInspector_.Visible = true;
                zonedOrderInspector.Visible = false;
            }
            else
                throw new Exception("Multiselect not supported");
        }

        private void MainMap_MouseOverChanged(int x, int y)
        {
            if(x == -1 && y == -1)
            {
                terrainLabel.Text = "None";
            }
            else
            {
                GameLib.LandType type = settlement_.Map.GetType(x, y);
                int height = settlement_.Map.GetHeight(x, y);
                terrainLabel.Text = string.Format("{0}  Altitude: {1} ({2},{3})", type.ToString(), height, x, y);
            }

            UpdateSelectionText();
        }

        private void endTurnButton__Click(object sender, EventArgs e)
        {
            game_.ProcessTurn();
            mainMap.UpdateTreeMap();
        }



        private void UpdateSelectionText()
        {
            if (mainMap.CurrentlyDrawingArea)
            {
                selectionArea.Text = string.Format("Selection: {0}x{1}={2} ft²", mainMap.DrawingArea.Width, mainMap.DrawingArea.Height, mainMap.DrawingArea.Width * mainMap.DrawingArea.Height);
            }
            else if (mainMap.SelectedBuilding != null)
            {
                selectionArea.Text = mainMap.SelectedBuilding.Name;
            }
            else if (mainMap.SelectedZone != null)
            {
                selectionArea.Text = "Zone";
            }
            else
            {
                selectionArea.Text = "No Selection";
            }
        }

        private void zoomDropdown_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            int size = int.Parse(e.ClickedItem.Tag as string);
            mainMap.TileSize = size;
            zoomDropdown.Text = e.ClickedItem.Text;
        }
    }
}
