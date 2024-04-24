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
            uxEmailLabel = new Label();
            uxPasswordLabel = new Label();
            uxEmailTextbox = new TextBox();
            uxPasswordTextbox = new TextBox();
            uxWelcome = new Label();
            uxSignUpButton = new Button();
            uxIsAdminCheckbox = new CheckBox();
            uxAdminAccesButton = new Button();
            SuspendLayout();
            // 
            // uxEmailLabel
            // 
            uxEmailLabel.AutoSize = true;
            uxEmailLabel.Location = new Point(293, 182);
            uxEmailLabel.Name = "uxEmailLabel";
            uxEmailLabel.Size = new Size(42, 15);
            uxEmailLabel.TabIndex = 2;
            uxEmailLabel.Text = "Email: ";
            // 
            // uxPasswordLabel
            // 
            uxPasswordLabel.AutoSize = true;
            uxPasswordLabel.Location = new Point(272, 205);
            uxPasswordLabel.Name = "uxPasswordLabel";
            uxPasswordLabel.Size = new Size(63, 15);
            uxPasswordLabel.TabIndex = 3;
            uxPasswordLabel.Text = "Password: ";
            // 
            // uxEmailTextbox
            // 
            uxEmailTextbox.Location = new Point(345, 180);
            uxEmailTextbox.Margin = new Padding(3, 2, 3, 2);
            uxEmailTextbox.Name = "uxEmailTextbox";
            uxEmailTextbox.Size = new Size(110, 23);
            uxEmailTextbox.TabIndex = 4;
            // 
            // uxPasswordTextbox
            // 
            uxPasswordTextbox.Location = new Point(345, 205);
            uxPasswordTextbox.Margin = new Padding(3, 2, 3, 2);
            uxPasswordTextbox.Name = "uxPasswordTextbox";
            uxPasswordTextbox.Size = new Size(110, 23);
            uxPasswordTextbox.TabIndex = 5;
            // 
            // uxWelcome
            // 
            uxWelcome.AutoSize = true;
            uxWelcome.Location = new Point(316, 152);
            uxWelcome.Name = "uxWelcome";
            uxWelcome.Size = new Size(168, 15);
            uxWelcome.TabIndex = 6;
            uxWelcome.Text = "Welcome! Please sign up or in!";
            // 
            // uxSignUpButton
            // 
            uxSignUpButton.Location = new Point(358, 243);
            uxSignUpButton.Margin = new Padding(3, 2, 3, 2);
            uxSignUpButton.Name = "uxSignUpButton";
            uxSignUpButton.Size = new Size(82, 25);
            uxSignUpButton.TabIndex = 7;
            uxSignUpButton.Text = "Sign Up/In";
            uxSignUpButton.UseVisualStyleBackColor = true;
            uxSignUpButton.Click += EventHandlerSignUpButton;
            // 
            // uxIsAdminCheckbox
            // 
            uxIsAdminCheckbox.AutoSize = true;
            uxIsAdminCheckbox.Location = new Point(471, 209);
            uxIsAdminCheckbox.Name = "uxIsAdminCheckbox";
            uxIsAdminCheckbox.Size = new Size(125, 19);
            uxIsAdminCheckbox.TabIndex = 9;
            uxIsAdminCheckbox.Text = "Are you an admin?";
            uxIsAdminCheckbox.UseVisualStyleBackColor = true;
            // 
            // uxAdminAccesButton
            // 
            uxAdminAccesButton.Location = new Point(680, 415);
            uxAdminAccesButton.Name = "uxAdminAccesButton";
            uxAdminAccesButton.Size = new Size(108, 23);
            uxAdminAccesButton.TabIndex = 10;
            uxAdminAccesButton.Text = "Admin Access";
            uxAdminAccesButton.UseVisualStyleBackColor = true;
            uxAdminAccesButton.Click += uxAdminAccesButton_Click;
            // 
            // SignUpForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(uxAdminAccesButton);
            Controls.Add(uxIsAdminCheckbox);
            Controls.Add(uxSignUpButton);
            Controls.Add(uxWelcome);
            Controls.Add(uxPasswordTextbox);
            Controls.Add(uxEmailTextbox);
            Controls.Add(uxPasswordLabel);
            Controls.Add(uxEmailLabel);
            Name = "SignUpForm";
            Text = "Sign Up";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label uxEmailLabel;
        private Label uxPasswordLabel;
        private TextBox uxEmailTextbox;
        private TextBox uxPasswordTextbox;
        private Label uxWelcome;
        private Button uxSignUpButton;
        private CheckBox uxIsAdminCheckbox;
        private Button uxAdminAccesButton;
    }
}