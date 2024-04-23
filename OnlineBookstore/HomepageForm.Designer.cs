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
            this.uxSearchBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.uxAdminAccess = new System.Windows.Forms.Button();
            this.uxBuy = new System.Windows.Forms.Button();
            this.uxBuyList = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.uxFilter = new System.Windows.Forms.ComboBox();
            this.uxDisplaying = new System.Windows.Forms.Label();
            this.uxSearchButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.remove = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // uxBookList
            // 
            this.uxBookList.FormattingEnabled = true;
            this.uxBookList.ItemHeight = 15;
            this.uxBookList.Location = new System.Drawing.Point(25, 31);
            this.uxBookList.Name = "uxBookList";
            this.uxBookList.Size = new System.Drawing.Size(197, 184);
            this.uxBookList.TabIndex = 0;
            // 
            // uxSearchBox
            // 
            this.uxSearchBox.Location = new System.Drawing.Point(430, 70);
            this.uxSearchBox.Name = "uxSearchBox";
            this.uxSearchBox.Size = new System.Drawing.Size(123, 23);
            this.uxSearchBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(379, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Search:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(363, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Search by:";
            // 
            // uxAdminAccess
            // 
            this.uxAdminAccess.Location = new System.Drawing.Point(240, 184);
            this.uxAdminAccess.Name = "uxAdminAccess";
            this.uxAdminAccess.Size = new System.Drawing.Size(120, 31);
            this.uxAdminAccess.TabIndex = 4;
            this.uxAdminAccess.Text = "Admin Access";
            this.uxAdminAccess.UseVisualStyleBackColor = true;
            this.uxAdminAccess.Click += new System.EventHandler(this.uxAdminAccess_Click);
            // 
            // uxBuy
            // 
            this.uxBuy.Location = new System.Drawing.Point(315, 116);
            this.uxBuy.Name = "uxBuy";
            this.uxBuy.Size = new System.Drawing.Size(42, 34);
            this.uxBuy.TabIndex = 5;
            this.uxBuy.Text = "Buy";
            this.uxBuy.UseVisualStyleBackColor = true;
            this.uxBuy.Click += new System.EventHandler(this.uxBuy_Click);
            // 
            // uxBuyList
            // 
            this.uxBuyList.AccessibleName = "uxBuyList";
            this.uxBuyList.FormattingEnabled = true;
            this.uxBuyList.ItemHeight = 15;
            this.uxBuyList.Location = new System.Drawing.Point(240, 31);
            this.uxBuyList.Name = "uxBuyList";
            this.uxBuyList.Size = new System.Drawing.Size(120, 79);
            this.uxBuyList.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(240, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Buy List";
            this.label3.Click += new System.EventHandler(this.label3_Click);
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
            this.uxFilter.Location = new System.Drawing.Point(430, 131);
            this.uxFilter.Name = "uxFilter";
            this.uxFilter.Size = new System.Drawing.Size(121, 23);
            this.uxFilter.TabIndex = 8;
            this.uxFilter.SelectedIndexChanged += new System.EventHandler(this.uxFilter_SelectedIndexChanged);
            // 
            // uxDisplaying
            // 
            this.uxDisplaying.AutoSize = true;
            this.uxDisplaying.Location = new System.Drawing.Point(85, 13);
            this.uxDisplaying.Name = "uxDisplaying";
            this.uxDisplaying.Size = new System.Drawing.Size(76, 15);
            this.uxDisplaying.TabIndex = 9;
            this.uxDisplaying.Text = "blank of max";
            // 
            // uxSearchButton
            // 
            this.uxSearchButton.Location = new System.Drawing.Point(430, 184);
            this.uxSearchButton.Name = "uxSearchButton";
            this.uxSearchButton.Size = new System.Drawing.Size(121, 31);
            this.uxSearchButton.TabIndex = 10;
            this.uxSearchButton.Text = "Search";
            this.uxSearchButton.UseVisualStyleBackColor = true;
            this.uxSearchButton.Click += new System.EventHandler(this.uxSearchButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(240, 116);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(42, 34);
            this.button1.TabIndex = 11;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // remove
            // 
            this.remove.Location = new System.Drawing.Point(331, 153);
            this.remove.Name = "remove";
            this.remove.Size = new System.Drawing.Size(75, 23);
            this.remove.TabIndex = 12;
            this.remove.Text = "remove";
            this.remove.UseVisualStyleBackColor = true;
            // 
            // HomepageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 229);
            this.Controls.Add(this.remove);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.uxSearchButton);
            this.Controls.Add(this.uxDisplaying);
            this.Controls.Add(this.uxFilter);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.uxBuyList);
            this.Controls.Add(this.uxBuy);
            this.Controls.Add(this.uxAdminAccess);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.uxSearchBox);
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
        private TextBox uxSearchBox;
        private Label label1;
        private Label label2;
        private Button uxAdminAccess;
        private Button uxBuy;
        private ListBox uxBuyList;
        private Label label3;
        private ComboBox uxFilter;
        private Label uxDisplaying;
        private Button uxSearchButton;
        private Button button1;
        private Button remove;
    }
}