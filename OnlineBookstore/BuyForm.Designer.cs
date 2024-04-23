namespace OnlineBookstore
{
    partial class BuyForm
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
            uxCredentialsLabel = new Label();
            uxCheckoutLabel = new Label();
            uxBuyList = new ListBox();
            uxFirstNameTextBox = new TextBox();
            uxLastNameTextBox = new TextBox();
            uxAddressTextBox = new TextBox();
            uxPhoneNumberTextBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            uxConfirmPurchase = new Button();
            label5 = new Label();
            SuspendLayout();
            // 
            // uxCredentialsLabel
            // 
            uxCredentialsLabel.AutoSize = true;
            uxCredentialsLabel.Location = new Point(427, 35);
            uxCredentialsLabel.Name = "uxCredentialsLabel";
            uxCredentialsLabel.Size = new Size(157, 15);
            uxCredentialsLabel.TabIndex = 0;
            uxCredentialsLabel.Text = "Please enter your credentials";
            // 
            // uxCheckoutLabel
            // 
            uxCheckoutLabel.AutoSize = true;
            uxCheckoutLabel.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            uxCheckoutLabel.Location = new Point(12, 9);
            uxCheckoutLabel.Name = "uxCheckoutLabel";
            uxCheckoutLabel.Size = new Size(128, 37);
            uxCheckoutLabel.TabIndex = 1;
            uxCheckoutLabel.Text = "Checkout";
            // 
            // uxBuyList
            // 
            uxBuyList.FormattingEnabled = true;
            uxBuyList.ItemHeight = 15;
            uxBuyList.Location = new Point(20, 49);
            uxBuyList.Name = "uxBuyList";
            uxBuyList.Size = new Size(294, 154);
            uxBuyList.TabIndex = 2;
            // 
            // uxFirstNameTextBox
            // 
            uxFirstNameTextBox.Location = new Point(484, 61);
            uxFirstNameTextBox.Name = "uxFirstNameTextBox";
            uxFirstNameTextBox.Size = new Size(100, 23);
            uxFirstNameTextBox.TabIndex = 3;
            // 
            // uxLastNameTextBox
            // 
            uxLastNameTextBox.Location = new Point(484, 90);
            uxLastNameTextBox.Name = "uxLastNameTextBox";
            uxLastNameTextBox.Size = new Size(100, 23);
            uxLastNameTextBox.TabIndex = 4;
            // 
            // uxAddressTextBox
            // 
            uxAddressTextBox.Location = new Point(484, 119);
            uxAddressTextBox.Name = "uxAddressTextBox";
            uxAddressTextBox.Size = new Size(100, 23);
            uxAddressTextBox.TabIndex = 5;
            // 
            // uxPhoneNumberTextBox
            // 
            uxPhoneNumberTextBox.Location = new Point(484, 148);
            uxPhoneNumberTextBox.Name = "uxPhoneNumberTextBox";
            uxPhoneNumberTextBox.Size = new Size(100, 23);
            uxPhoneNumberTextBox.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(411, 64);
            label1.Name = "label1";
            label1.Size = new Size(67, 15);
            label1.TabIndex = 7;
            label1.Text = "First Name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(412, 93);
            label2.Name = "label2";
            label2.Size = new Size(66, 15);
            label2.TabIndex = 8;
            label2.Text = "Last Name:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(426, 122);
            label3.Name = "label3";
            label3.Size = new Size(52, 15);
            label3.TabIndex = 9;
            label3.Text = "Address:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(387, 151);
            label4.Name = "label4";
            label4.Size = new Size(91, 15);
            label4.TabIndex = 10;
            label4.Text = "Phone Number:";
            // 
            // uxConfirmPurchase
            // 
            uxConfirmPurchase.Location = new Point(462, 202);
            uxConfirmPurchase.Name = "uxConfirmPurchase";
            uxConfirmPurchase.Size = new Size(122, 23);
            uxConfirmPurchase.TabIndex = 11;
            uxConfirmPurchase.Text = "Confirm Purchase";
            uxConfirmPurchase.UseVisualStyleBackColor = true;
            uxConfirmPurchase.Click += uxConfirmPurchase_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(229, 210);
            label5.Name = "label5";
            label5.Size = new Size(35, 15);
            label5.TabIndex = 12;
            label5.Text = "Total:";
            // 
            // BuyForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(664, 287);
            Controls.Add(label5);
            Controls.Add(uxConfirmPurchase);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(uxPhoneNumberTextBox);
            Controls.Add(uxAddressTextBox);
            Controls.Add(uxLastNameTextBox);
            Controls.Add(uxFirstNameTextBox);
            Controls.Add(uxBuyList);
            Controls.Add(uxCheckoutLabel);
            Controls.Add(uxCredentialsLabel);
            Name = "BuyForm";
            Text = "BuyForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label uxCredentialsLabel;
        private Label uxCheckoutLabel;
        private ListBox uxBuyList;
        private TextBox uxFirstNameTextBox;
        private TextBox uxLastNameTextBox;
        private TextBox uxAddressTextBox;
        private TextBox uxPhoneNumberTextBox;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button uxConfirmPurchase;
        private Label label5;
    }
}