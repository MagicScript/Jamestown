namespace Jamestown
{
    partial class ZonedOrderInspector
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
            this.assignButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // nameLabel_
            // 
            this.nameLabel_.AutoSize = true;
            this.nameLabel_.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLabel_.Location = new System.Drawing.Point(3, 0);
            this.nameLabel_.Name = "nameLabel_";
            this.nameLabel_.Size = new System.Drawing.Size(95, 20);
            this.nameLabel_.TabIndex = 1;
            this.nameLabel_.Text = "Order Name";
            // 
            // assignButton
            // 
            this.assignButton.Location = new System.Drawing.Point(7, 23);
            this.assignButton.Name = "assignButton";
            this.assignButton.Size = new System.Drawing.Size(91, 23);
            this.assignButton.TabIndex = 2;
            this.assignButton.Text = "Assign Labour";
            this.assignButton.UseVisualStyleBackColor = true;
            this.assignButton.Click += new System.EventHandler(this.assignButton_Click);
            // 
            // ZonedOrderInspector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.assignButton);
            this.Controls.Add(this.nameLabel_);
            this.Name = "ZonedOrderInspector";
            this.Size = new System.Drawing.Size(210, 259);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nameLabel_;
        private System.Windows.Forms.Button assignButton;
    }
}
