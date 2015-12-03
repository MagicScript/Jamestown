namespace Jamestown
{
    partial class Rename
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
            this.label1 = new System.Windows.Forms.Label();
            this.newNameBox_ = new System.Windows.Forms.TextBox();
            this.okButton_ = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Please enter the new name:";
            // 
            // newNameBox_
            // 
            this.newNameBox_.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.newNameBox_.Location = new System.Drawing.Point(15, 26);
            this.newNameBox_.Name = "newNameBox_";
            this.newNameBox_.Size = new System.Drawing.Size(337, 20);
            this.newNameBox_.TabIndex = 1;
            // 
            // okButton_
            // 
            this.okButton_.Location = new System.Drawing.Point(76, 52);
            this.okButton_.Name = "okButton_";
            this.okButton_.Size = new System.Drawing.Size(75, 23);
            this.okButton_.TabIndex = 2;
            this.okButton_.Text = "OK";
            this.okButton_.UseVisualStyleBackColor = true;
            this.okButton_.Click += new System.EventHandler(this.okButton__Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(181, 52);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // Rename
            // 
            this.AcceptButton = this.okButton_;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 87);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton_);
            this.Controls.Add(this.newNameBox_);
            this.Controls.Add(this.label1);
            this.Name = "Rename";
            this.Text = "Rename";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox newNameBox_;
        private System.Windows.Forms.Button okButton_;
        private System.Windows.Forms.Button cancelButton;
    }
}