﻿using System;
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
    public partial class SettlementInspector : UserControl
    {
        private Settlement settlement_;
        public Settlement Settlement
        {
            get { return settlement_; }
            set
            {
                if(settlement_ != value)
                {
                    settlement_ = value;
                    DoUpdate();
                }
            }
        }

        private ActionType currActionType_ = ActionType.None;
        public ActionType CurrentAction
        {
            get { return currActionType_; }
            set
            {
                if(currActionType_ != value)
                {
                    chopTrees.Checked = currActionType_== ActionType.PlaceChopZone;
                    hunt.Checked = currActionType_ == ActionType.PlaceHuntZone;
                }
            }
        }

        public SettlementInspector()
        {
            InitializeComponent();

            chopTrees.CheckedChanged += CheckedChanged;
            cutLogs.CheckedChanged += CheckedChanged;
            hunt.CheckedChanged += CheckedChanged;
        }

        private void CheckedChanged(object sender, EventArgs e)
        {
            if (chopTrees.Checked)
                currActionType_ = ActionType.PlaceChopZone;
            else if (cutLogs.Checked)
                currActionType_ = ActionType.PlaceCutLogsZone;
            else if (hunt.Checked)
                currActionType_ = ActionType.PlaceHuntZone;
            else
                currActionType_ = ActionType.None;
        }

        private void DoUpdate()
        {
            if(settlement_ != null)
            {
                nameLabel_.Text = settlement_.Name;
                populationLabel.Text = "Population: " + settlement_.Persons.Count();

                var mats = settlement_.Materials;
                resourceView.RowCount = mats.Count();
                int i = 0;
                foreach(var p in mats)
                {
                    resourceView.Rows[i].Cells[0].Value = p.Key;
                    resourceView.Rows[i].Cells[1].Value = p.Value;
                    ++i;
                }
            }
            else
            {
                nameLabel_.Text = string.Empty;
                populationLabel.Text = string.Empty;
            }
        }

        private void nameLabel__DoubleClick(object sender, EventArgs e)
        {
            string name = settlement_.Name;
            if (Rename.DoRename(ref name))
            {
                settlement_.Name = name;
                DoUpdate();
            }
        }

        public void BeginTurn()
        {
            DoUpdate();
        }
    }
}
