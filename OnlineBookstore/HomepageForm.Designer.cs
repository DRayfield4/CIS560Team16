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
            this.uxBookList = new System.Windows.Forms.ListBox();
            this.uxBuyList = new System.Windows.Forms.ListBox();
            this.e = new System.Windows.Forms.Label();
            this.uxDisplaying = new System.Windows.Forms.Label();
            this.uxPrice = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.uxBuy = new System.Windows.Forms.Button();
            this.uxAdd = new System.Windows.Forms.Button();
            this.uxRemove = new System.Windows.Forms.Button();
            this.uxSearchButton = new System.Windows.Forms.Button();
            this.uxSearchBox = new System.Windows.Forms.TextBox();
            this.uxFilter = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // uxBookList
            // 
            this.uxBookList.FormattingEnabled = true;
            this.uxBookList.ItemHeight = 15;
            this.uxBookList.Location = new System.Drawing.Point(39, 39);
            this.uxBookList.Name = "uxBookList";
            this.uxBookList.Size = new System.Drawing.Size(163, 214);
            this.uxBookList.TabIndex = 0;
            this.uxBookList.SelectedIndexChanged += new System.EventHandler(this.uxBookList_SelectedIndexChanged);
            // 
            // uxBuyList
            // 
            this.uxBuyList.FormattingEnabled = true;
            this.uxBuyList.ItemHeight = 15;
            this.uxBuyList.Location = new System.Drawing.Point(241, 39);
            this.uxBuyList.Name = "uxBuyList";
            this.uxBuyList.Size = new System.Drawing.Size(120, 94);
            this.uxBuyList.TabIndex = 1;
            this.uxBuyList.SelectedIndexChanged += new System.EventHandler(this.uxBuyList_SelectedIndexChanged);
            // 
            // e
            // 
            this.e.AutoSize = true;
            this.e.Location = new System.Drawing.Point(274, 21);
            this.e.Name = "e";
            this.e.Size = new System.Drawing.Size(67, 15);
            this.e.TabIndex = 2;
            this.e.Text = "Order Table";
            // 
            // uxDisplaying
            // 
            this.uxDisplaying.AutoSize = true;
            this.uxDisplaying.Location = new System.Drawing.Point(110, 21);
            this.uxDisplaying.Name = "uxDisplaying";
            this.uxDisplaying.Size = new System.Drawing.Size(0, 15);
            this.uxDisplaying.TabIndex = 3;
            this.uxDisplaying.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uxPrice
            // 
            this.uxPrice.AutoSize = true;
            this.uxPrice.Location = new System.Drawing.Point(224, 136);
            this.uxPrice.Name = "uxPrice";
            this.uxPrice.Size = new System.Drawing.Size(0, 15);
            this.uxPrice.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(241, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "Search:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(241, 199);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 15);
            this.label5.TabIndex = 6;
            this.label5.Text = "Search by:";
            // 
            // uxBuy
            // 
            this.uxBuy.Location = new System.Drawing.Point(367, 107);
            this.uxBuy.Name = "uxBuy";
            this.uxBuy.Size = new System.Drawing.Size(74, 28);
            this.uxBuy.TabIndex = 7;
            this.uxBuy.Text = "Buy";
            this.uxBuy.UseVisualStyleBackColor = true;
            this.uxBuy.Click += new System.EventHandler(this.uxBuy_Click);
            // 
            // uxAdd
            // 
            this.uxAdd.Location = new System.Drawing.Point(367, 39);
            this.uxAdd.Name = "uxAdd";
            this.uxAdd.Size = new System.Drawing.Size(74, 28);
            this.uxAdd.TabIndex = 8;
            this.uxAdd.Text = "Add";
            this.uxAdd.UseVisualStyleBackColor = true;
            this.uxAdd.Click += new System.EventHandler(this.uxAdd_Click);
            // 
            // uxRemove
            // 
            this.uxRemove.Location = new System.Drawing.Point(367, 73);
            this.uxRemove.Name = "uxRemove";
            this.uxRemove.Size = new System.Drawing.Size(74, 28);
            this.uxRemove.TabIndex = 9;
            this.uxRemove.Text = "Remove";
            this.uxRemove.UseVisualStyleBackColor = true;
            this.uxRemove.Click += new System.EventHandler(this.uxRemove_Click);
            // 
            // uxSearchButton
            // 
            this.uxSearchButton.Location = new System.Drawing.Point(340, 230);
            this.uxSearchButton.Name = "uxSearchButton";
            this.uxSearchButton.Size = new System.Drawing.Size(75, 23);
            this.uxSearchButton.TabIndex = 10;
            this.uxSearchButton.Text = "Search";
            this.uxSearchButton.UseVisualStyleBackColor = true;
            this.uxSearchButton.Click += new System.EventHandler(this.uxSearchButton_Click);
            // 
            // uxSearchBox
            // 
            this.uxSearchBox.Location = new System.Drawing.Point(320, 153);
            this.uxSearchBox.Name = "uxSearchBox";
            this.uxSearchBox.Size = new System.Drawing.Size(121, 23);
            this.uxSearchBox.TabIndex = 11;
            // 
            // uxFilter
            // 
            this.uxFilter.FormattingEnabled = true;
            this.uxFilter.Items.AddRange(new object[] {
            "Title",
            "Author",
            "ISBN",
            "Genre",
            "Price",
            "Publisher"});
            this.uxFilter.Location = new System.Drawing.Point(320, 191);
            this.uxFilter.Name = "uxFilter";
            this.uxFilter.Size = new System.Drawing.Size(121, 23);
            this.uxFilter.TabIndex = 12;
            this.uxFilter.SelectedIndexChanged += new System.EventHandler(this.uxFilter_SelectedIndexChanged);
            // 
            // HomepageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 338);
            this.Controls.Add(this.uxFilter);
            this.Controls.Add(this.uxSearchBox);
            this.Controls.Add(this.uxSearchButton);
            this.Controls.Add(this.uxRemove);
            this.Controls.Add(this.uxAdd);
            this.Controls.Add(this.uxBuy);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.uxPrice);
            this.Controls.Add(this.uxDisplaying);
            this.Controls.Add(this.e);
            this.Controls.Add(this.uxBuyList);
            this.Controls.Add(this.uxBookList);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "HomepageForm";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.HomepageForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}