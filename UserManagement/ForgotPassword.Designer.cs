﻿namespace UserManagement
{
    partial class forgotPasswordForm
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
            this.usernameBox = new System.Windows.Forms.TextBox();
            this.newPasswordBox = new System.Windows.Forms.TextBox();
            this.confirmPasswordBox = new System.Windows.Forms.TextBox();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.newPasswordLabel = new System.Windows.Forms.Label();
            this.confirmPasswordLabel = new System.Windows.Forms.Label();
            this.applyButton = new System.Windows.Forms.Button();
            this.titleLabel = new System.Windows.Forms.Label();
            this.deleteButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // usernameBox
            // 
            this.usernameBox.Location = new System.Drawing.Point(190, 99);
            this.usernameBox.Name = "usernameBox";
            this.usernameBox.Size = new System.Drawing.Size(410, 26);
            this.usernameBox.TabIndex = 0;
            // 
            // newPasswordBox
            // 
            this.newPasswordBox.Location = new System.Drawing.Point(190, 160);
            this.newPasswordBox.Name = "newPasswordBox";
            this.newPasswordBox.Size = new System.Drawing.Size(410, 26);
            this.newPasswordBox.TabIndex = 1;
            // 
            // confirmPasswordBox
            // 
            this.confirmPasswordBox.Location = new System.Drawing.Point(190, 232);
            this.confirmPasswordBox.Name = "confirmPasswordBox";
            this.confirmPasswordBox.Size = new System.Drawing.Size(410, 26);
            this.confirmPasswordBox.TabIndex = 2;
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Location = new System.Drawing.Point(31, 99);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(83, 20);
            this.usernameLabel.TabIndex = 3;
            this.usernameLabel.Text = "Username";
            // 
            // newPasswordLabel
            // 
            this.newPasswordLabel.AutoSize = true;
            this.newPasswordLabel.Location = new System.Drawing.Point(31, 166);
            this.newPasswordLabel.Name = "newPasswordLabel";
            this.newPasswordLabel.Size = new System.Drawing.Size(113, 20);
            this.newPasswordLabel.TabIndex = 4;
            this.newPasswordLabel.Text = "New Password";
            // 
            // confirmPasswordLabel
            // 
            this.confirmPasswordLabel.AutoSize = true;
            this.confirmPasswordLabel.Location = new System.Drawing.Point(31, 238);
            this.confirmPasswordLabel.Name = "confirmPasswordLabel";
            this.confirmPasswordLabel.Size = new System.Drawing.Size(137, 20);
            this.confirmPasswordLabel.TabIndex = 5;
            this.confirmPasswordLabel.Text = "Confirm Password";
            // 
            // applyButton
            // 
            this.applyButton.Location = new System.Drawing.Point(190, 305);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(131, 36);
            this.applyButton.TabIndex = 6;
            this.applyButton.Text = "Apply";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(225, 30);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(300, 38);
            this.titleLabel.TabIndex = 7;
            this.titleLabel.Text = "Change Password";
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(469, 305);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(131, 36);
            this.deleteButton.TabIndex = 8;
            this.deleteButton.Text = "Delete Account";
            this.deleteButton.UseVisualStyleBackColor = true;
            // 
            // forgotPasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 405);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.confirmPasswordLabel);
            this.Controls.Add(this.newPasswordLabel);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.confirmPasswordBox);
            this.Controls.Add(this.newPasswordBox);
            this.Controls.Add(this.usernameBox);
            this.Name = "forgotPasswordForm";
            this.Text = "Form3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox usernameBox;
        private System.Windows.Forms.TextBox newPasswordBox;
        private System.Windows.Forms.TextBox confirmPasswordBox;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Label newPasswordLabel;
        private System.Windows.Forms.Label confirmPasswordLabel;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Button deleteButton;
    }
}