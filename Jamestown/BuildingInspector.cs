using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameLib;

namespace Jamestown
{
    public partial class BuildingInspector : UserControl
    {
        private Building building_;
        public Building Building
        {
            get { return building_; }
            set
            {
                if(building_ != value)
                {
                    building_ = value;
                    DoUpdate();
                }
            }
        }

        public BuildingInspector()
        {
            InitializeComponent();
        }

        private void DoUpdate()
        {
            if(building_ != null)
            {
                buildingName_.Text = building_.Name;
            }
            else
            {
                buildingName_.Text = string.Empty;
            }
        }

        private void buildingName_DoubleClick(object sender, EventArgs e)
        {
            string name = building_.Name;
            if(Rename.DoRename(ref name))
            {
                building_.Name = name;
                DoUpdate();
            }
        }
    }
}
