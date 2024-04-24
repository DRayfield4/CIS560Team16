namespace OnlineBookstore
{
    partial class HomepageForm
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
            uxBookList = new ListBox();
            uxBuyList = new ListBox();
            e = new Label();
            uxDisplaying = new Label();
            uxPrice = new Label();
            label4 = new Label();
            label5 = new Label();
            uxBuy = new Button();
            uxAdd = new Button();
            uxRemove = new Button();
            uxSearchButton = new Button();
            uxSearchBox = new TextBox();
            uxFilter = new ComboBox();
            uxGenreComboBox = new ComboBox();
            uxBackButton = new Button();
            SuspendLayout();
            // 
            // uxBookList
            // 
            uxBookList.FormattingEnabled = true;
            uxBookList.ItemHeight = 15;
            uxBookList.Location = new Point(39, 39);
            uxBookList.Name = "uxBookList";
            uxBookList.Size = new Size(375, 214);
            uxBookList.TabIndex = 0;
            // 
            // uxBuyList
            // 
            uxBuyList.FormattingEnabled = true;
            uxBuyList.ItemHeight = 15;
            uxBuyList.Location = new Point(486, 46);
            uxBuyList.Name = "uxBuyList";
            uxBuyList.Size = new Size(352, 169);
            uxBuyList.TabIndex = 1;
            uxBuyList.SelectedIndexChanged += uxBuyList_SelectedIndexChanged;
            // 
            // e
            // 
            e.AutoSize = true;
            e.Location = new Point(486, 28);
            e.Name = "e";
            e.Size = new Size(67, 15);
            e.TabIndex = 2;
            e.Text = "Order Table";
            // 
            // uxDisplaying
            // 
            uxDisplaying.AutoSize = true;
            uxDisplaying.Location = new Point(39, 21);
            uxDisplaying.Name = "uxDisplaying";
            uxDisplaying.Size = new Size(0, 15);
            uxDisplaying.TabIndex = 3;
            uxDisplaying.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // uxPrice
            // 
            uxPrice.AutoSize = true;
            uxPrice.Location = new Point(759, 218);
            uxPrice.Name = "uxPrice";
            uxPrice.Size = new Size(35, 15);
            uxPrice.TabIndex = 4;
            uxPrice.Text = "Total:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(499, 235);
            label4.Name = "label4";
            label4.Size = new Size(45, 15);
            label4.TabIndex = 5;
            label4.Text = "Search:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(483, 276);
            label5.Name = "label5";
            label5.Size = new Size(61, 15);
            label5.TabIndex = 6;
            label5.Text = "Search by:";
            // 
            // uxBuy
            // 
            uxBuy.Location = new Point(844, 112);
            uxBuy.Name = "uxBuy";
            uxBuy.Size = new Size(74, 28);
            uxBuy.TabIndex = 7;
            uxBuy.Text = "Buy";
            uxBuy.UseVisualStyleBackColor = true;
            uxBuy.Click += uxBuy_Click;
            // 
            // uxAdd
            // 
            uxAdd.Location = new Point(844, 44);
            uxAdd.Name = "uxAdd";
            uxAdd.Size = new Size(74, 28);
            uxAdd.TabIndex = 8;
            uxAdd.Text = "Add";
            uxAdd.UseVisualStyleBackColor = true;
            uxAdd.Click += uxAdd_Click;
            // 
            // uxRemove
            // 
            uxRemove.Location = new Point(844, 78);
            uxRemove.Name = "uxRemove";
            uxRemove.Size = new Size(74, 28);
            uxRemove.TabIndex = 9;
            uxRemove.Text = "Remove";
            uxRemove.UseVisualStyleBackColor = true;
            uxRemove.Click += uxRemove_Click;
            // 
            // uxSearchButton
            // 
            uxSearchButton.Location = new Point(571, 302);
            uxSearchButton.Name = "uxSearchButton";
            uxSearchButton.Size = new Size(75, 23);
            uxSearchButton.TabIndex = 10;
            uxSearchButton.Text = "Search";
            uxSearchButton.UseVisualStyleBackColor = true;
            uxSearchButton.Click += uxSearchButton_Click;
            // 
            // uxSearchBox
            // 
            uxSearchBox.Location = new Point(550, 235);
            uxSearchBox.Name = "uxSearchBox";
            uxSearchBox.Size = new Size(121, 23);
            uxSearchBox.TabIndex = 11;
            // 
            // uxFilter
            // 
            uxFilter.FormattingEnabled = true;
            uxFilter.Items.AddRange(new object[] { "Title", "Author", "ISBN", "Genre", "Price", "Publisher" });
            uxFilter.Location = new Point(550, 273);
            uxFilter.Name = "uxFilter";
            uxFilter.Size = new Size(121, 23);
            uxFilter.TabIndex = 12;
            uxFilter.SelectedIndexChanged += uxFilter_SelectedIndexChanged;
            // 
            // uxGenreComboBox
            // 
            uxGenreComboBox.FormattingEnabled = true;
            uxGenreComboBox.Location = new Point(686, 273);
            uxGenreComboBox.Name = "uxGenreComboBox";
            uxGenreComboBox.Size = new Size(121, 23);
            uxGenreComboBox.TabIndex = 13;
            uxGenreComboBox.Visible = false;
            // 
            // uxBackButton
            // 
            uxBackButton.Location = new Point(979, 495);
            uxBackButton.Name = "uxBackButton";
            uxBackButton.Size = new Size(119, 23);
            uxBackButton.TabIndex = 14;
            uxBackButton.Text = "Back to Sign Up";
            uxBackButton.UseVisualStyleBackColor = true;
            uxBackButton.Click += uxBackButton_Click;
            // 
            // HomepageForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1110, 530);
            Controls.Add(uxBackButton);
            Controls.Add(uxGenreComboBox);
            Controls.Add(uxFilter);
            Controls.Add(uxSearchBox);
            Controls.Add(uxSearchButton);
            Controls.Add(uxRemove);
            Controls.Add(uxAdd);
            Controls.Add(uxBuy);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(uxPrice);
            Controls.Add(uxDisplaying);
            Controls.Add(e);
            Controls.Add(uxBuyList);
            Controls.Add(uxBookList);
            Margin = new Padding(3, 2, 3, 2);
            Name = "HomepageForm";
            Text = "HomePage";
            Load += HomepageForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox uxBookList;
        private ListBox uxBuyList;
        private Label e;
        private Label uxDisplaying;
        private Label uxPrice;
        private Label label4;
        private Label label5;
        private Button uxBuy;
        private Button uxAdd;
        private Button uxRemove;
        private Button uxSearchButton;
        private TextBox uxSearchBox;
        private ComboBox uxFilter;
        private ComboBox uxGenreComboBox;
        private Button uxBackButton;
    }
}