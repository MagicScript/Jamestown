namespace Jamestown
{
    partial class SettlementInspector
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.nameLabel_ = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.chopTrees = new System.Windows.Forms.RadioButton();
            this.hunt = new System.Windows.Forms.RadioButton();
            this.populationLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // nameLabel_
            // 
            this.nameLabel_.AutoSize = true;
            this.nameLabel_.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLabel_.Location = new System.Drawing.Point(4, 4);
            this.nameLabel_.Name = "nameLabel_";
            this.nameLabel_.Size = new System.Drawing.Size(133, 20);
            this.nameLabel_.TabIndex = 0;
            this.nameLabel_.Text = "Settlement Name";
            this.nameLabel_.DoubleClick += new System.EventHandler(this.nameLabel__DoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.flowLayoutPanel1);
            this.groupBox1.Location = new System.Drawing.Point(3, 47);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(204, 120);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Orders";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.chopTrees);
            this.flowLayoutPanel1.Controls.Add(this.hunt);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(6, 19);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(192, 95);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // chopTrees
            // 
            this.chopTrees.Appearance = System.Windows.Forms.Appearance.Button;
            this.chopTrees.AutoSize = true;
            this.chopTrees.Location = new System.Drawing.Point(3, 3);
            this.chopTrees.Name = "chopTrees";
            this.chopTrees.Size = new System.Drawing.Size(72, 23);
            this.chopTrees.TabIndex = 0;
            this.chopTrees.TabStop = true;
            this.chopTrees.Text = "Chop Trees";
            this.chopTrees.UseVisualStyleBackColor = true;
            // 
            // hunt
            // 
            this.hunt.Appearance = System.Windows.Forms.Appearance.Button;
            this.hunt.AutoSize = true;
            this.hunt.Location = new System.Drawing.Point(81, 3);
            this.hunt.Name = "hunt";
            this.hunt.Size = new System.Drawing.Size(40, 23);
            this.hunt.TabIndex = 1;
            this.hunt.TabStop = true;
            this.hunt.Text = "Hunt";
            this.hunt.UseVisualStyleBackColor = true;
            // 
            // populationLabel
            // 
            this.populationLabel.AutoSize = true;
            this.populationLabel.Location = new System.Drawing.Point(12, 28);
            this.populationLabel.Name = "populationLabel";
            this.populationLabel.Size = new System.Drawing.Size(35, 13);
            this.populationLabel.TabIndex = 2;
            this.populationLabel.Text = "label1";
            // 
            // SettlementInspector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.populationLabel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.nameLabel_);
            this.Name = "SettlementInspector";
            this.Size = new System.Drawing.Size(210, 309);
            this.groupBox1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nameLabel_;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.RadioButton chopTrees;
        private System.Windows.Forms.RadioButton hunt;
        private System.Windows.Forms.Label populationLabel;
    }
}
