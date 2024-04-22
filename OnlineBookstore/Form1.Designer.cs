namespace OnlineBookstore
{
    partial class Form1
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
            button1 = new Button();
            label1 = new Label();
            uxEmailLabel = new Label();
            uxPasswordLabel = new Label();
            uxEmailTextbox = new TextBox();
            uxPasswordTextbox = new TextBox();
            uxWelcome = new Label();
            uxSignUpButton = new Button();
            uxGuestButton = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(773, 399);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(86, 31);
            button1.TabIndex = 0;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Visible = false;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(793, 445);
            label1.Name = "label1";
            label1.Size = new Size(50, 20);
            label1.TabIndex = 1;
            label1.Text = "label1";
            label1.Visible = false;
            // 
            // uxEmailLabel
            // 
            uxEmailLabel.AutoSize = true;
            uxEmailLabel.Location = new Point(334, 188);
            uxEmailLabel.Name = "uxEmailLabel";
            uxEmailLabel.Size = new Size(53, 20);
            uxEmailLabel.TabIndex = 2;
            uxEmailLabel.Text = "Email: ";
            // 
            // uxPasswordLabel
            // 
            uxPasswordLabel.AutoSize = true;
            uxPasswordLabel.Location = new Point(310, 219);
            uxPasswordLabel.Name = "uxPasswordLabel";
            uxPasswordLabel.Size = new Size(77, 20);
            uxPasswordLabel.TabIndex = 3;
            uxPasswordLabel.Text = "Password: ";
            // 
            // uxEmailTextbox
            // 
            uxEmailTextbox.Location = new Point(393, 185);
            uxEmailTextbox.Name = "uxEmailTextbox";
            uxEmailTextbox.Size = new Size(125, 27);
            uxEmailTextbox.TabIndex = 4;
            // 
            // uxPasswordTextbox
            // 
            uxPasswordTextbox.Location = new Point(393, 219);
            uxPasswordTextbox.Name = "uxPasswordTextbox";
            uxPasswordTextbox.Size = new Size(125, 27);
            uxPasswordTextbox.TabIndex = 5;
            // 
            // uxWelcome
            // 
            uxWelcome.AutoSize = true;
            uxWelcome.Location = new Point(370, 135);
            uxWelcome.Name = "uxWelcome";
            uxWelcome.Size = new Size(177, 20);
            uxWelcome.TabIndex = 6;
            uxWelcome.Text = "Welcome! Please sign up!";
            // 
            // uxSignUpButton
            // 
            uxSignUpButton.Location = new Point(408, 270);
            uxSignUpButton.Name = "uxSignUpButton";
            uxSignUpButton.Size = new Size(94, 33);
            uxSignUpButton.TabIndex = 7;
            uxSignUpButton.Text = "Sign Up";
            uxSignUpButton.UseVisualStyleBackColor = true;
            uxSignUpButton.Click += EventHandlerSignUpButton;
            // 
            // uxGuestButton
            // 
            uxGuestButton.Location = new Point(382, 366);
            uxGuestButton.Name = "uxGuestButton";
            uxGuestButton.Size = new Size(151, 35);
            uxGuestButton.TabIndex = 8;
            uxGuestButton.Text = "Continue as guest";
            uxGuestButton.UseVisualStyleBackColor = true;
            uxGuestButton.Click += uxGuestButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(uxGuestButton);
            Controls.Add(uxSignUpButton);
            Controls.Add(uxWelcome);
            Controls.Add(uxPasswordTextbox);
            Controls.Add(uxEmailTextbox);
            Controls.Add(uxPasswordLabel);
            Controls.Add(uxEmailLabel);
            Controls.Add(label1);
            Controls.Add(button1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label1;
        private Label uxEmailLabel;
        private Label uxPasswordLabel;
        private TextBox uxEmailTextbox;
        private TextBox uxPasswordTextbox;
        private Label uxWelcome;
        private Button uxSignUpButton;
        private Button uxGuestButton;
    }
}