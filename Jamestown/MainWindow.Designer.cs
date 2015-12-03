namespace Jamestown
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.scrollPanel = new System.Windows.Forms.Panel();
            this.endTurnButton_ = new System.Windows.Forms.Button();
            this.mainStatus = new System.Windows.Forms.StatusStrip();
            this.terrainLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.selectionArea = new System.Windows.Forms.ToolStripStatusLabel();
            this.mainMap = new Jamestown.MapControl();
            this.zonedOrderInspector = new Jamestown.ZonedOrderInspector();
            this.settlementInspector_ = new Jamestown.SettlementInspector();
            this.buildingInspector_ = new Jamestown.BuildingInspector();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.scrollPanel.SuspendLayout();
            this.mainStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1136, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.mainMap);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1136, 619);
            this.splitContainer1.SplitterDistance = 886;
            this.splitContainer1.TabIndex = 2;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.scrollPanel);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.endTurnButton_);
            this.splitContainer2.Size = new System.Drawing.Size(246, 619);
            this.splitContainer2.SplitterDistance = 577;
            this.splitContainer2.TabIndex = 0;
            // 
            // scrollPanel
            // 
            this.scrollPanel.AutoScroll = true;
            this.scrollPanel.Controls.Add(this.zonedOrderInspector);
            this.scrollPanel.Controls.Add(this.settlementInspector_);
            this.scrollPanel.Controls.Add(this.buildingInspector_);
            this.scrollPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scrollPanel.Location = new System.Drawing.Point(0, 0);
            this.scrollPanel.Name = "scrollPanel";
            this.scrollPanel.Size = new System.Drawing.Size(246, 577);
            this.scrollPanel.TabIndex = 0;
            // 
            // endTurnButton_
            // 
            this.endTurnButton_.Dock = System.Windows.Forms.DockStyle.Fill;
            this.endTurnButton_.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endTurnButton_.Location = new System.Drawing.Point(0, 0);
            this.endTurnButton_.Name = "endTurnButton_";
            this.endTurnButton_.Size = new System.Drawing.Size(246, 38);
            this.endTurnButton_.TabIndex = 0;
            this.endTurnButton_.Text = "End Turn";
            this.endTurnButton_.UseVisualStyleBackColor = true;
            this.endTurnButton_.Click += new System.EventHandler(this.endTurnButton__Click);
            // 
            // mainStatus
            // 
            this.mainStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.terrainLabel,
            this.selectionArea});
            this.mainStatus.Location = new System.Drawing.Point(0, 643);
            this.mainStatus.Name = "mainStatus";
            this.mainStatus.Size = new System.Drawing.Size(1136, 22);
            this.mainStatus.TabIndex = 3;
            this.mainStatus.Text = "statusStrip1";
            // 
            // terrainLabel
            // 
            this.terrainLabel.Name = "terrainLabel";
            this.terrainLabel.Size = new System.Drawing.Size(118, 17);
            this.terrainLabel.Text = "toolStripStatusLabel1";
            // 
            // selectionArea
            // 
            this.selectionArea.Name = "selectionArea";
            this.selectionArea.Size = new System.Drawing.Size(118, 17);
            this.selectionArea.Text = "toolStripStatusLabel1";
            // 
            // mainMap
            // 
            this.mainMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainMap.Location = new System.Drawing.Point(0, 0);
            this.mainMap.LookLocation = new System.Drawing.Point(0, 0);
            this.mainMap.Mode = Jamestown.MapMode.Terrain;
            this.mainMap.Name = "mainMap";
            this.mainMap.SelectAreaColor = System.Drawing.Color.AliceBlue;
            this.mainMap.SelectedBuilding = null;
            this.mainMap.SelectedZone = null;
            this.mainMap.Settlement = null;
            this.mainMap.Size = new System.Drawing.Size(886, 619);
            this.mainMap.TabIndex = 0;
            this.mainMap.TileSize = 16;
            // 
            // zonedOrderInspector
            // 
            this.zonedOrderInspector.Location = new System.Drawing.Point(0, 3);
            this.zonedOrderInspector.Name = "zonedOrderInspector";
            this.zonedOrderInspector.Order = null;
            this.zonedOrderInspector.Size = new System.Drawing.Size(243, 248);
            this.zonedOrderInspector.TabIndex = 2;
            this.zonedOrderInspector.Visible = false;
            // 
            // settlementInspector_
            // 
            this.settlementInspector_.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.settlementInspector_.AutoSize = true;
            this.settlementInspector_.BackColor = System.Drawing.SystemColors.Control;
            this.settlementInspector_.CurrentAction = Jamestown.ActionType.None;
            this.settlementInspector_.Location = new System.Drawing.Point(3, 0);
            this.settlementInspector_.Name = "settlementInspector_";
            this.settlementInspector_.Settlement = null;
            this.settlementInspector_.Size = new System.Drawing.Size(243, 170);
            this.settlementInspector_.TabIndex = 1;
            this.settlementInspector_.Visible = false;
            // 
            // buildingInspector_
            // 
            this.buildingInspector_.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buildingInspector_.BackColor = System.Drawing.SystemColors.Control;
            this.buildingInspector_.Building = null;
            this.buildingInspector_.Location = new System.Drawing.Point(3, 0);
            this.buildingInspector_.Name = "buildingInspector_";
            this.buildingInspector_.Size = new System.Drawing.Size(240, 170);
            this.buildingInspector_.TabIndex = 0;
            this.buildingInspector_.Visible = false;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1136, 665);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.mainStatus);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.Text = "Form1";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.scrollPanel.ResumeLayout(false);
            this.scrollPanel.PerformLayout();
            this.mainStatus.ResumeLayout(false);
            this.mainStatus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private MapControl mainMap;
        private System.Windows.Forms.StatusStrip mainStatus;
        private System.Windows.Forms.ToolStripStatusLabel terrainLabel;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button endTurnButton_;
        private System.Windows.Forms.Panel scrollPanel;
        private BuildingInspector buildingInspector_;
        private SettlementInspector settlementInspector_;
        private System.Windows.Forms.ToolStripStatusLabel selectionArea;
        private ZonedOrderInspector zonedOrderInspector;
    }
}

