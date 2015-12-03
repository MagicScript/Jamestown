using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameLib;

namespace Jamestown
{
    public partial class AssignLabour : Form
    {
        private Order order_;

        public AssignLabour(Order order)
        {
            order_ = order;
            InitializeComponent();

            personList.Persons = order.Settlement.Persons;
            titleLabel_.Text = order.Name;

            UpdateDuration();
        }

        private void doneButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void assignButton_Click(object sender, EventArgs e)
        {
            foreach(var p in personList.SelectedPersons)
            {
                p.WorkOrder = order_;
            }

            //Requery
            personList.Persons = order_.Settlement.Persons;
            UpdateDuration();
        }

        private void unassignButton_Click(object sender, EventArgs e)
        {
            foreach (var p in personList.SelectedPersons)
            {
                if (p.WorkOrder == order_)
                    p.WorkOrder = null;
            }

            //Requery
            personList.Persons = order_.Settlement.Persons;
            UpdateDuration();
        }

        private void UpdateDuration()
        {
            int workLeft = order_.GetWorkLeft();
            if (workLeft < 0)
                durationLabel.Text = "This order will never complete.";
            else if (workLeft == 0)
                durationLabel.Text = "This order is already complete.";
            else
                durationLabel.Text = string.Format("This order will complete in {0} weeks.", workLeft);
        }
    }
}
