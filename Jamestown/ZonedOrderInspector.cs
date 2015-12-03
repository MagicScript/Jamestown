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
    public partial class ZonedOrderInspector : UserControl
    {
        private ZonedOrder order_;
        public ZonedOrder Order
        {
            get { return order_; }
            set
            {
                order_ = value;
                assignButton.Enabled = order_ != null;

                if(order_ != null)
                {
                    nameLabel_.Text = order_.Name;
                }
                else
                {
                    nameLabel_.Text = string.Empty;
                }
            }
        }

        public ZonedOrderInspector()
        {
            InitializeComponent();
        }

        private void assignButton_Click(object sender, EventArgs e)
        {
            AssignLabour dlg = new AssignLabour(order_);
            dlg.ShowDialog();
        }
    }
}
