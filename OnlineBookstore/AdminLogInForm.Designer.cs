namespace OnlineBookstore
{
    partial class AdminLogInForm
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
            uxAdminEmailTextbox = new TextBox();
            uxAdminPasswordTextbox = new TextBox();
            uxAdminEmailLabel = new Label();
            uxAdminPasswordLabel = new Label();
            uxAdminWelcomeLabel = new Label();
            uxAdminLogInButton = new Button();
            uxReturnToSignUp = new Button();
            SuspendLayout();
            // 
            // uxAdminEmailTextbox
            // 
            uxAdminEmailTextbox.Location = new Point(351, 185);
            uxAdminEmailTextbox.Name = "uxAdminEmailTextbox";
            uxAdminEmailTextbox.Size = new Size(100, 23);
            uxAdminEmailTextbox.TabIndex = 0;
            // 
            // uxAdminPasswordTextbox
            // 
            uxAdminPasswordTextbox.Location = new Point(351, 209);
            uxAdminPasswordTextbox.Name = "uxAdminPasswordTextbox";
            uxAdminPasswordTextbox.Size = new Size(100, 23);
            uxAdminPasswordTextbox.TabIndex = 1;
            // 
            // uxAdminEmailLabel
            // 
            uxAdminEmailLabel.AutoSize = true;
            uxAdminEmailLabel.Location = new Point(303, 188);
            uxAdminEmailLabel.Name = "uxAdminEmailLabel";
            uxAdminEmailLabel.Size = new Size(42, 15);
            uxAdminEmailLabel.TabIndex = 2;
            uxAdminEmailLabel.Text = "Email: ";
            // 
            // uxAdminPasswordLabel
            // 
            uxAdminPasswordLabel.AutoSize = true;
            uxAdminPasswordLabel.Location = new Point(282, 212);
            uxAdminPasswordLabel.Name = "uxAdminPasswordLabel";
            uxAdminPasswordLabel.Size = new Size(63, 15);
            uxAdminPasswordLabel.TabIndex = 3;
            uxAdminPasswordLabel.Text = "Password: ";
            // 
            // uxAdminWelcomeLabel
            // 
            uxAdminWelcomeLabel.AutoSize = true;
            uxAdminWelcomeLabel.Location = new Point(328, 125);
            uxAdminWelcomeLabel.Name = "uxAdminWelcomeLabel";
            uxAdminWelcomeLabel.Size = new Size(135, 15);
            uxAdminWelcomeLabel.TabIndex = 4;
            uxAdminWelcomeLabel.Text = "Hello supposed admin...";
            // 
            // uxAdminLogInButton
            // 
            uxAdminLogInButton.Location = new Point(362, 249);
            uxAdminLogInButton.Name = "uxAdminLogInButton";
            uxAdminLogInButton.Size = new Size(75, 23);
            uxAdminLogInButton.TabIndex = 5;
            uxAdminLogInButton.Text = "Log In";
            uxAdminLogInButton.UseVisualStyleBackColor = true;
            uxAdminLogInButton.Click += uxAdminLogInButton_Click;
            // 
            // uxReturnToSignUp
            // 
            uxReturnToSignUp.Location = new Point(669, 415);
            uxReturnToSignUp.Name = "uxReturnToSignUp";
            uxReturnToSignUp.Size = new Size(119, 23);
            uxReturnToSignUp.TabIndex = 6;
            uxReturnToSignUp.Text = "Back to Sign Up page";
            uxReturnToSignUp.UseVisualStyleBackColor = true;
            uxReturnToSignUp.Click += uxReturnToSignUp_Click;
            // 
            // AdminLogInForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(uxReturnToSignUp);
            Controls.Add(uxAdminLogInButton);
            Controls.Add(uxAdminWelcomeLabel);
            Controls.Add(uxAdminPasswordLabel);
            Controls.Add(uxAdminEmailLabel);
            Controls.Add(uxAdminPasswordTextbox);
            Controls.Add(uxAdminEmailTextbox);
            Name = "AdminLogInForm";
            Text = "AdminLogInForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox uxAdminEmailTextbox;
        private TextBox uxAdminPasswordTextbox;
        private Label uxAdminEmailLabel;
        private Label uxAdminPasswordLabel;
        private Label uxAdminWelcomeLabel;
        private Button uxAdminLogInButton;
        private Button uxReturnToSignUp;
    }
}