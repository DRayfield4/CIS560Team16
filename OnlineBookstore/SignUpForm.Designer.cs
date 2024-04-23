namespace OnlineBookstore
{
    partial class SignUpForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.uxEmailLabel = new System.Windows.Forms.Label();
            this.uxPasswordLabel = new System.Windows.Forms.Label();
            this.uxEmailTextbox = new System.Windows.Forms.TextBox();
            this.uxPasswordTextbox = new System.Windows.Forms.TextBox();
            this.uxWelcome = new System.Windows.Forms.Label();
            this.uxSignUpButton = new System.Windows.Forms.Button();
            this.uxGuestButton = new System.Windows.Forms.Button();
            this.uxIsAdminCheckbox = new System.Windows.Forms.CheckBox();
            this.uxAdminAccesButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // uxEmailLabel
            // 
            this.uxEmailLabel.AutoSize = true;
            this.uxEmailLabel.Location = new System.Drawing.Point(292, 141);
            this.uxEmailLabel.Name = "uxEmailLabel";
            this.uxEmailLabel.Size = new System.Drawing.Size(42, 15);
            this.uxEmailLabel.TabIndex = 2;
            this.uxEmailLabel.Text = "Email: ";
            // 
            // uxPasswordLabel
            // 
            this.uxPasswordLabel.AutoSize = true;
            this.uxPasswordLabel.Location = new System.Drawing.Point(271, 164);
            this.uxPasswordLabel.Name = "uxPasswordLabel";
            this.uxPasswordLabel.Size = new System.Drawing.Size(63, 15);
            this.uxPasswordLabel.TabIndex = 3;
            this.uxPasswordLabel.Text = "Password: ";
            // 
            // uxEmailTextbox
            // 
            this.uxEmailTextbox.Location = new System.Drawing.Point(344, 139);
            this.uxEmailTextbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.uxEmailTextbox.Name = "uxEmailTextbox";
            this.uxEmailTextbox.Size = new System.Drawing.Size(110, 23);
            this.uxEmailTextbox.TabIndex = 4;
            // 
            // uxPasswordTextbox
            // 
            this.uxPasswordTextbox.Location = new System.Drawing.Point(344, 164);
            this.uxPasswordTextbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.uxPasswordTextbox.Name = "uxPasswordTextbox";
            this.uxPasswordTextbox.Size = new System.Drawing.Size(110, 23);
            this.uxPasswordTextbox.TabIndex = 5;
            // 
            // uxWelcome
            // 
            this.uxWelcome.AutoSize = true;
            this.uxWelcome.Location = new System.Drawing.Point(324, 101);
            this.uxWelcome.Name = "uxWelcome";
            this.uxWelcome.Size = new System.Drawing.Size(141, 15);
            this.uxWelcome.TabIndex = 6;
            this.uxWelcome.Text = "Welcome! Please sign up!";
            // 
            // uxSignUpButton
            // 
            this.uxSignUpButton.Location = new System.Drawing.Point(357, 202);
            this.uxSignUpButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.uxSignUpButton.Name = "uxSignUpButton";
            this.uxSignUpButton.Size = new System.Drawing.Size(82, 25);
            this.uxSignUpButton.TabIndex = 7;
            this.uxSignUpButton.Text = "Sign Up";
            this.uxSignUpButton.UseVisualStyleBackColor = true;
            // 
            // uxGuestButton
            // 
            this.uxGuestButton.Location = new System.Drawing.Point(334, 274);
            this.uxGuestButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.uxGuestButton.Name = "uxGuestButton";
            this.uxGuestButton.Size = new System.Drawing.Size(132, 26);
            this.uxGuestButton.TabIndex = 8;
            this.uxGuestButton.Text = "Continue as guest";
            this.uxGuestButton.UseVisualStyleBackColor = true;
            this.uxGuestButton.Click += new System.EventHandler(this.uxGuestButton_Click);
            // 
            // uxIsAdminCheckbox
            // 
            this.uxIsAdminCheckbox.AutoSize = true;
            this.uxIsAdminCheckbox.Location = new System.Drawing.Point(470, 168);
            this.uxIsAdminCheckbox.Name = "uxIsAdminCheckbox";
            this.uxIsAdminCheckbox.Size = new System.Drawing.Size(125, 19);
            this.uxIsAdminCheckbox.TabIndex = 9;
            this.uxIsAdminCheckbox.Text = "Are you an admin?";
            this.uxIsAdminCheckbox.UseVisualStyleBackColor = true;
            // 
            // uxAdminAccesButton
            // 
            this.uxAdminAccesButton.Location = new System.Drawing.Point(680, 415);
            this.uxAdminAccesButton.Name = "uxAdminAccesButton";
            this.uxAdminAccesButton.Size = new System.Drawing.Size(108, 23);
            this.uxAdminAccesButton.TabIndex = 10;
            this.uxAdminAccesButton.Text = "Admin Access";
            this.uxAdminAccesButton.UseVisualStyleBackColor = true;
            this.uxAdminAccesButton.Click += new System.EventHandler(this.uxAdminAccesButton_Click);
            // 
            // SignUpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.uxAdminAccesButton);
            this.Controls.Add(this.uxIsAdminCheckbox);
            this.Controls.Add(this.uxGuestButton);
            this.Controls.Add(this.uxSignUpButton);
            this.Controls.Add(this.uxWelcome);
            this.Controls.Add(this.uxPasswordTextbox);
            this.Controls.Add(this.uxEmailTextbox);
            this.Controls.Add(this.uxPasswordLabel);
            this.Controls.Add(this.uxEmailLabel);
            this.Name = "SignUpForm";
            this.Text = "Sign Up";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label uxEmailLabel;
        private Label uxPasswordLabel;
        private TextBox uxEmailTextbox;
        private TextBox uxPasswordTextbox;
        private Label uxWelcome;
        private Button uxSignUpButton;
        private Button uxGuestButton;
        private CheckBox uxIsAdminCheckbox;
        private Button uxAdminAccesButton;
    }
}