namespace Jamestown
{
    partial class BuildingInspector
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
            this.buildingName_ = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buildingName_
            // 
            this.buildingName_.AutoSize = true;
            this.buildingName_.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buildingName_.Location = new System.Drawing.Point(4, 4);
            this.buildingName_.Name = "buildingName_";
            this.buildingName_.Size = new System.Drawing.Size(111, 20);
            this.buildingName_.TabIndex = 0;
            this.buildingName_.Text = "Building Name";
            this.buildingName_.DoubleClick += new System.EventHandler(this.buildingName_DoubleClick);
            // 
            // BuildingInspector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.buildingName_);
            this.Name = "BuildingInspector";
            this.Size = new System.Drawing.Size(262, 422);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label buildingName_;
    }
}
