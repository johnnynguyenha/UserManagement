namespace UserManagement
{
    partial class loggedInForm
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
            this.editDetailsButton = new System.Windows.Forms.Button();
            this.titleLabel = new System.Windows.Forms.Label();
            this.deleteButton = new System.Windows.Forms.Button();
            this.manageButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // editDetailsButton
            // 
            this.editDetailsButton.Location = new System.Drawing.Point(74, 313);
            this.editDetailsButton.Name = "editDetailsButton";
            this.editDetailsButton.Size = new System.Drawing.Size(114, 44);
            this.editDetailsButton.TabIndex = 0;
            this.editDetailsButton.Text = "Edit Details";
            this.editDetailsButton.UseVisualStyleBackColor = true;
            this.editDetailsButton.Click += new System.EventHandler(this.editDetailsButton_Click_1);
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(204, 55);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(109, 38);
            this.titleLabel.TabIndex = 1;
            this.titleLabel.Text = "label1";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.titleLabel.Click += new System.EventHandler(this.titleLabel_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(616, 313);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(114, 44);
            this.deleteButton.TabIndex = 2;
            this.deleteButton.Text = "Delete Account";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // manageButton
            // 
            this.manageButton.Location = new System.Drawing.Point(346, 313);
            this.manageButton.Name = "manageButton";
            this.manageButton.Size = new System.Drawing.Size(114, 44);
            this.manageButton.TabIndex = 3;
            this.manageButton.Text = "Manage Other Users";
            this.manageButton.UseVisualStyleBackColor = true;
            this.manageButton.Click += new System.EventHandler(this.manageButton_Click);
            // 
            // loggedInForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.manageButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.editDetailsButton);
            this.Name = "loggedInForm";
            this.Text = "LoggedIn";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button editDetailsButton;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button manageButton;
    }
}