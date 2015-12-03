namespace Jamestown
{
    partial class AssignLabour
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
            this.doneButton = new System.Windows.Forms.Button();
            this.assignButton = new System.Windows.Forms.Button();
            this.unassignButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.titleLabel_ = new System.Windows.Forms.Label();
            this.personList = new Jamestown.PersonList();
            this.durationLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // doneButton
            // 
            this.doneButton.Location = new System.Drawing.Point(446, 12);
            this.doneButton.Name = "doneButton";
            this.doneButton.Size = new System.Drawing.Size(73, 23);
            this.doneButton.TabIndex = 1;
            this.doneButton.Text = "Done";
            this.doneButton.UseVisualStyleBackColor = true;
            this.doneButton.Click += new System.EventHandler(this.doneButton_Click);
            // 
            // assignButton
            // 
            this.assignButton.Location = new System.Drawing.Point(446, 200);
            this.assignButton.Name = "assignButton";
            this.assignButton.Size = new System.Drawing.Size(73, 23);
            this.assignButton.TabIndex = 2;
            this.assignButton.Text = "Assign";
            this.assignButton.UseVisualStyleBackColor = true;
            this.assignButton.Click += new System.EventHandler(this.assignButton_Click);
            // 
            // unassignButton
            // 
            this.unassignButton.Location = new System.Drawing.Point(446, 247);
            this.unassignButton.Name = "unassignButton";
            this.unassignButton.Size = new System.Drawing.Size(73, 23);
            this.unassignButton.TabIndex = 3;
            this.unassignButton.Text = "Unassign";
            this.unassignButton.UseVisualStyleBackColor = true;
            this.unassignButton.Click += new System.EventHandler(this.unassignButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Assign labour to this order. ";
            // 
            // titleLabel_
            // 
            this.titleLabel_.AutoSize = true;
            this.titleLabel_.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel_.Location = new System.Drawing.Point(8, 9);
            this.titleLabel_.Name = "titleLabel_";
            this.titleLabel_.Size = new System.Drawing.Size(95, 20);
            this.titleLabel_.TabIndex = 5;
            this.titleLabel_.Text = "Order Name";
            // 
            // personList
            // 
            this.personList.Location = new System.Drawing.Point(12, 67);
            this.personList.Name = "personList";
            this.personList.Persons = null;
            this.personList.Size = new System.Drawing.Size(428, 313);
            this.personList.TabIndex = 6;
            // 
            // durationLabel
            // 
            this.durationLabel.AutoSize = true;
            this.durationLabel.Location = new System.Drawing.Point(12, 51);
            this.durationLabel.Name = "durationLabel";
            this.durationLabel.Size = new System.Drawing.Size(150, 13);
            this.durationLabel.TabIndex = 7;
            this.durationLabel.Text = "This order will never complete.";
            // 
            // AssignLabour
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 392);
            this.Controls.Add(this.durationLabel);
            this.Controls.Add(this.personList);
            this.Controls.Add(this.titleLabel_);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.unassignButton);
            this.Controls.Add(this.assignButton);
            this.Controls.Add(this.doneButton);
            this.Name = "AssignLabour";
            this.Text = "AssignLabour";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button doneButton;
        private System.Windows.Forms.Button assignButton;
        private System.Windows.Forms.Button unassignButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label titleLabel_;
        private PersonList personList;
        private System.Windows.Forms.Label durationLabel;
    }
}