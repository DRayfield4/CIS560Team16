namespace OnlineBookstore
{
    partial class AdminForm
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
            uxAggregatingQueriesComboBox = new ComboBox();
            uxStartDateLabel = new Label();
            uxEndDateLabel = new Label();
            uxAggregatingQueryLabel = new Label();
            uxResultButton = new Button();
            uxResultListBox = new ListBox();
            uxStartDatePicker = new DateTimePicker();
            uxEndDatePicker = new DateTimePicker();
            uxAddBookButton = new Button();
            uxUpdateBookButton = new Button();
            uxRemoveBookButton = new Button();
            SuspendLayout();
            // 
            // uxAggregatingQueriesComboBox
            // 
            uxAggregatingQueriesComboBox.DropDownWidth = 280;
            uxAggregatingQueriesComboBox.FormattingEnabled = true;
            uxAggregatingQueriesComboBox.Items.AddRange(new object[] { "1) Total sales revenue for each genre", "2) Top 10 bestselling authors", "3) Monthly revenue over certain amount of years", "4) Distribution of frequent customers" });
            uxAggregatingQueriesComboBox.Location = new Point(382, 153);
            uxAggregatingQueriesComboBox.Margin = new Padding(3, 4, 3, 4);
            uxAggregatingQueriesComboBox.Name = "uxAggregatingQueriesComboBox";
            uxAggregatingQueriesComboBox.Size = new Size(173, 28);
            uxAggregatingQueriesComboBox.TabIndex = 0;
            uxAggregatingQueriesComboBox.SelectedIndexChanged += uxAggregatingQueriesComboBox_SelectedIndexChanged_1;
            // 
            // uxStartDateLabel
            // 
            uxStartDateLabel.AutoSize = true;
            uxStartDateLabel.Location = new Point(283, 240);
            uxStartDateLabel.Name = "uxStartDateLabel";
            uxStartDateLabel.Size = new Size(79, 20);
            uxStartDateLabel.TabIndex = 3;
            uxStartDateLabel.Text = "Start Date:";
            uxStartDateLabel.Visible = false;
            // 
            // uxEndDateLabel
            // 
            uxEndDateLabel.AutoSize = true;
            uxEndDateLabel.Location = new Point(288, 293);
            uxEndDateLabel.Name = "uxEndDateLabel";
            uxEndDateLabel.Size = new Size(73, 20);
            uxEndDateLabel.TabIndex = 4;
            uxEndDateLabel.Text = "End Date:";
            uxEndDateLabel.Visible = false;
            // 
            // uxAggregatingQueryLabel
            // 
            uxAggregatingQueryLabel.AutoSize = true;
            uxAggregatingQueryLabel.Location = new Point(226, 156);
            uxAggregatingQueryLabel.Name = "uxAggregatingQueryLabel";
            uxAggregatingQueryLabel.Size = new Size(150, 20);
            uxAggregatingQueryLabel.TabIndex = 5;
            uxAggregatingQueryLabel.Text = "Aggregating Queries:";
            // 
            // uxResultButton
            // 
            uxResultButton.Location = new Point(424, 339);
            uxResultButton.Margin = new Padding(3, 4, 3, 4);
            uxResultButton.Name = "uxResultButton";
            uxResultButton.Size = new Size(86, 31);
            uxResultButton.TabIndex = 6;
            uxResultButton.Text = "Result";
            uxResultButton.UseVisualStyleBackColor = true;
            uxResultButton.Click += uxResultButton_Click;
            // 
            // uxResultListBox
            // 
            uxResultListBox.FormattingEnabled = true;
            uxResultListBox.ItemHeight = 20;
            uxResultListBox.Location = new Point(295, 403);
            uxResultListBox.Margin = new Padding(3, 4, 3, 4);
            uxResultListBox.Name = "uxResultListBox";
            uxResultListBox.Size = new Size(331, 124);
            uxResultListBox.TabIndex = 7;
            // 
            // uxStartDatePicker
            // 
            uxStartDatePicker.Format = DateTimePickerFormat.Custom;
            uxStartDatePicker.Location = new Point(360, 232);
            uxStartDatePicker.Margin = new Padding(3, 4, 3, 4);
            uxStartDatePicker.MaxDate = new DateTime(2024, 4, 23, 0, 0, 0, 0);
            uxStartDatePicker.Name = "uxStartDatePicker";
            uxStartDatePicker.Size = new Size(228, 27);
            uxStartDatePicker.TabIndex = 8;
            uxStartDatePicker.Value = new DateTime(2024, 4, 23, 0, 0, 0, 0);
            uxStartDatePicker.Visible = false;
            // 
            // uxEndDatePicker
            // 
            uxEndDatePicker.Format = DateTimePickerFormat.Custom;
            uxEndDatePicker.Location = new Point(360, 285);
            uxEndDatePicker.Margin = new Padding(3, 4, 3, 4);
            uxEndDatePicker.MaxDate = new DateTime(2024, 4, 23, 0, 0, 0, 0);
            uxEndDatePicker.Name = "uxEndDatePicker";
            uxEndDatePicker.Size = new Size(228, 27);
            uxEndDatePicker.TabIndex = 9;
            uxEndDatePicker.Value = new DateTime(2024, 4, 23, 0, 0, 0, 0);
            uxEndDatePicker.Visible = false;
            // 
            // uxAddBookButton
            // 
            uxAddBookButton.Location = new Point(239, 67);
            uxAddBookButton.Margin = new Padding(3, 4, 3, 4);
            uxAddBookButton.Name = "uxAddBookButton";
            uxAddBookButton.Size = new Size(107, 31);
            uxAddBookButton.TabIndex = 10;
            uxAddBookButton.Text = "Add Book";
            uxAddBookButton.UseVisualStyleBackColor = true;
            uxAddBookButton.Click += uxAddBookButton_Click;
            // 
            // uxUpdateBookButton
            // 
            uxUpdateBookButton.Location = new Point(402, 67);
            uxUpdateBookButton.Margin = new Padding(3, 4, 3, 4);
            uxUpdateBookButton.Name = "uxUpdateBookButton";
            uxUpdateBookButton.Size = new Size(107, 31);
            uxUpdateBookButton.TabIndex = 11;
            uxUpdateBookButton.Text = "Update Book";
            uxUpdateBookButton.UseVisualStyleBackColor = true;
            uxUpdateBookButton.Click += uxUpdateBookButton_Click;
            // 
            // uxRemoveBookButton
            // 
            uxRemoveBookButton.Location = new Point(555, 67);
            uxRemoveBookButton.Margin = new Padding(3, 4, 3, 4);
            uxRemoveBookButton.Name = "uxRemoveBookButton";
            uxRemoveBookButton.Size = new Size(107, 31);
            uxRemoveBookButton.TabIndex = 12;
            uxRemoveBookButton.Text = "Remove Book";
            uxRemoveBookButton.UseVisualStyleBackColor = true;
            uxRemoveBookButton.Click += uxRemoveBookButton_Click;
            // 
            // AdminForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(uxRemoveBookButton);
            Controls.Add(uxUpdateBookButton);
            Controls.Add(uxAddBookButton);
            Controls.Add(uxEndDatePicker);
            Controls.Add(uxStartDatePicker);
            Controls.Add(uxResultListBox);
            Controls.Add(uxResultButton);
            Controls.Add(uxAggregatingQueryLabel);
            Controls.Add(uxEndDateLabel);
            Controls.Add(uxStartDateLabel);
            Controls.Add(uxAggregatingQueriesComboBox);
            Margin = new Padding(3, 4, 3, 4);
            Name = "AdminForm";
            Text = "Admin View";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox uxAggregatingQueriesComboBox;
        private Label uxStartDateLabel;
        private Label uxEndDateLabel;
        private Label uxAggregatingQueryLabel;
        private Button uxResultButton;
        private ListBox uxResultListBox;
        private DateTimePicker uxStartDatePicker;
        private DateTimePicker uxEndDatePicker;
        private Button uxAddBookButton;
        private Button uxUpdateBookButton;
        private Button uxRemoveBookButton;
    }
}