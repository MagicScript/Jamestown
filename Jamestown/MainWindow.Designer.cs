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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.scrollPanel = new System.Windows.Forms.Panel();
            this.endTurnButton_ = new System.Windows.Forms.Button();
            this.mainStatus = new System.Windows.Forms.StatusStrip();
            this.terrainLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.selectionArea = new System.Windows.Forms.ToolStripStatusLabel();
            this.zoomDropdown = new System.Windows.Forms.ToolStripDropDownButton();
            this.xToolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.xToolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.xToolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.xToolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.xToolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.xToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.xToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.xToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.xToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xToolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
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
            this.selectionArea,
            this.zoomDropdown});
            this.mainStatus.Location = new System.Drawing.Point(0, 643);
            this.mainStatus.Name = "mainStatus";
            this.mainStatus.Size = new System.Drawing.Size(1136, 22);
            this.mainStatus.TabIndex = 3;
            this.mainStatus.Text = "16x";
            // 
            // terrainLabel
            // 
            this.terrainLabel.AutoSize = false;
            this.terrainLabel.Name = "terrainLabel";
            this.terrainLabel.Size = new System.Drawing.Size(150, 17);
            this.terrainLabel.Text = "Terrain";
            // 
            // selectionArea
            // 
            this.selectionArea.AutoSize = false;
            this.selectionArea.Name = "selectionArea";
            this.selectionArea.Size = new System.Drawing.Size(150, 17);
            this.selectionArea.Text = "toolStripStatusLabel1";
            // 
            // zoomDropdown
            // 
            this.zoomDropdown.AutoSize = false;
            this.zoomDropdown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.zoomDropdown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.zoomDropdown.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xToolStripMenuItem9,
            this.xToolStripMenuItem8,
            this.xToolStripMenuItem7,
            this.xToolStripMenuItem6,
            this.xToolStripMenuItem5});
            this.zoomDropdown.Image = ((System.Drawing.Image)(resources.GetObject("zoomDropdown.Image")));
            this.zoomDropdown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.zoomDropdown.Name = "zoomDropdown";
            this.zoomDropdown.Size = new System.Drawing.Size(40, 20);
            this.zoomDropdown.Text = "2x";
            this.zoomDropdown.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.zoomDropdown.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.zoomDropdown_DropDownItemClicked);
            // 
            // xToolStripMenuItem8
            // 
            this.xToolStripMenuItem8.Name = "xToolStripMenuItem8";
            this.xToolStripMenuItem8.Size = new System.Drawing.Size(152, 22);
            this.xToolStripMenuItem8.Tag = "16";
            this.xToolStripMenuItem8.Text = "8x";
            // 
            // xToolStripMenuItem7
            // 
            this.xToolStripMenuItem7.Name = "xToolStripMenuItem7";
            this.xToolStripMenuItem7.Size = new System.Drawing.Size(152, 22);
            this.xToolStripMenuItem7.Tag = "8";
            this.xToolStripMenuItem7.Text = "4x";
            // 
            // xToolStripMenuItem6
            // 
            this.xToolStripMenuItem6.Name = "xToolStripMenuItem6";
            this.xToolStripMenuItem6.Size = new System.Drawing.Size(152, 22);
            this.xToolStripMenuItem6.Tag = "4";
            this.xToolStripMenuItem6.Text = "2x";
            // 
            // xToolStripMenuItem5
            // 
            this.xToolStripMenuItem5.Name = "xToolStripMenuItem5";
            this.xToolStripMenuItem5.Size = new System.Drawing.Size(152, 22);
            this.xToolStripMenuItem5.Tag = "2";
            this.xToolStripMenuItem5.Text = "1x";
            // 
            // xToolStripMenuItem4
            // 
            this.xToolStripMenuItem4.Name = "xToolStripMenuItem4";
            this.xToolStripMenuItem4.Size = new System.Drawing.Size(91, 22);
            this.xToolStripMenuItem4.Text = "16x";
            // 
            // xToolStripMenuItem3
            // 
            this.xToolStripMenuItem3.Name = "xToolStripMenuItem3";
            this.xToolStripMenuItem3.Size = new System.Drawing.Size(91, 22);
            this.xToolStripMenuItem3.Text = "8x";
            // 
            // xToolStripMenuItem2
            // 
            this.xToolStripMenuItem2.Name = "xToolStripMenuItem2";
            this.xToolStripMenuItem2.Size = new System.Drawing.Size(91, 22);
            this.xToolStripMenuItem2.Text = "4x";
            // 
            // xToolStripMenuItem1
            // 
            this.xToolStripMenuItem1.Name = "xToolStripMenuItem1";
            this.xToolStripMenuItem1.Size = new System.Drawing.Size(91, 22);
            this.xToolStripMenuItem1.Text = "2x";
            // 
            // xToolStripMenuItem
            // 
            this.xToolStripMenuItem.Name = "xToolStripMenuItem";
            this.xToolStripMenuItem.Size = new System.Drawing.Size(91, 22);
            this.xToolStripMenuItem.Text = "1x";
            // 
            // xToolStripMenuItem9
            // 
            this.xToolStripMenuItem9.Name = "xToolStripMenuItem9";
            this.xToolStripMenuItem9.Size = new System.Drawing.Size(152, 22);
            this.xToolStripMenuItem9.Tag = "32";
            this.xToolStripMenuItem9.Text = "16x";
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
        private System.Windows.Forms.ToolStripDropDownButton zoomDropdown;
        private System.Windows.Forms.ToolStripMenuItem xToolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem xToolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem xToolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem xToolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem xToolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem xToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem xToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem xToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem xToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xToolStripMenuItem9;
    }
}

