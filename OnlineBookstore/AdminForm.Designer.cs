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
            uxAggregatingQueriesComboBox.Location = new Point(334, 115);
            uxAggregatingQueriesComboBox.Name = "uxAggregatingQueriesComboBox";
            uxAggregatingQueriesComboBox.Size = new Size(152, 23);
            uxAggregatingQueriesComboBox.TabIndex = 0;
            uxAggregatingQueriesComboBox.SelectedIndexChanged += uxAggregatingQueriesComboBox_SelectedIndexChanged_1;
            // 
            // uxStartDateLabel
            // 
            uxStartDateLabel.AutoSize = true;
            uxStartDateLabel.Location = new Point(248, 180);
            uxStartDateLabel.Name = "uxStartDateLabel";
            uxStartDateLabel.Size = new Size(61, 15);
            uxStartDateLabel.TabIndex = 3;
            uxStartDateLabel.Text = "Start Date:";
            uxStartDateLabel.Visible = false;
            // 
            // uxEndDateLabel
            // 
            uxEndDateLabel.AutoSize = true;
            uxEndDateLabel.Location = new Point(252, 220);
            uxEndDateLabel.Name = "uxEndDateLabel";
            uxEndDateLabel.Size = new Size(57, 15);
            uxEndDateLabel.TabIndex = 4;
            uxEndDateLabel.Text = "End Date:";
            uxEndDateLabel.Visible = false;
            // 
            // uxAggregatingQueryLabel
            // 
            uxAggregatingQueryLabel.AutoSize = true;
            uxAggregatingQueryLabel.Location = new Point(198, 117);
            uxAggregatingQueryLabel.Name = "uxAggregatingQueryLabel";
            uxAggregatingQueryLabel.Size = new Size(119, 15);
            uxAggregatingQueryLabel.TabIndex = 5;
            uxAggregatingQueryLabel.Text = "Aggregating Queries:";
            // 
            // uxResultButton
            // 
            uxResultButton.Location = new Point(371, 254);
            uxResultButton.Name = "uxResultButton";
            uxResultButton.Size = new Size(75, 23);
            uxResultButton.TabIndex = 6;
            uxResultButton.Text = "Result";
            uxResultButton.UseVisualStyleBackColor = true;
            uxResultButton.Click += uxResultButton_Click;
            // 
            // uxResultListBox
            // 
            uxResultListBox.FormattingEnabled = true;
            uxResultListBox.ItemHeight = 15;
            uxResultListBox.Location = new Point(161, 302);
            uxResultListBox.Name = "uxResultListBox";
            uxResultListBox.Size = new Size(478, 94);
            uxResultListBox.TabIndex = 7;
            // 
            // uxStartDatePicker
            // 
            uxStartDatePicker.Format = DateTimePickerFormat.Custom;
            uxStartDatePicker.Location = new Point(315, 174);
            uxStartDatePicker.MaxDate = new DateTime(2024, 4, 23, 0, 0, 0, 0);
            uxStartDatePicker.Name = "uxStartDatePicker";
            uxStartDatePicker.Size = new Size(200, 23);
            uxStartDatePicker.TabIndex = 8;
            uxStartDatePicker.Value = new DateTime(2024, 4, 23, 0, 0, 0, 0);
            uxStartDatePicker.Visible = false;
            // 
            // uxEndDatePicker
            // 
            uxEndDatePicker.Format = DateTimePickerFormat.Custom;
            uxEndDatePicker.Location = new Point(315, 214);
            uxEndDatePicker.MaxDate = new DateTime(2024, 4, 23, 0, 0, 0, 0);
            uxEndDatePicker.Name = "uxEndDatePicker";
            uxEndDatePicker.Size = new Size(200, 23);
            uxEndDatePicker.TabIndex = 9;
            uxEndDatePicker.Value = new DateTime(2024, 4, 23, 0, 0, 0, 0);
            uxEndDatePicker.Visible = false;
            // 
            // uxAddBookButton
            // 
            uxAddBookButton.Location = new Point(209, 50);
            uxAddBookButton.Name = "uxAddBookButton";
            uxAddBookButton.Size = new Size(94, 23);
            uxAddBookButton.TabIndex = 10;
            uxAddBookButton.Text = "Add Book";
            uxAddBookButton.UseVisualStyleBackColor = true;
            uxAddBookButton.Click += uxAddBookButton_Click;
            // 
            // uxUpdateBookButton
            // 
            uxUpdateBookButton.Location = new Point(352, 50);
            uxUpdateBookButton.Name = "uxUpdateBookButton";
            uxUpdateBookButton.Size = new Size(94, 23);
            uxUpdateBookButton.TabIndex = 11;
            uxUpdateBookButton.Text = "Update Book";
            uxUpdateBookButton.UseVisualStyleBackColor = true;
            uxUpdateBookButton.Click += uxUpdateBookButton_Click;
            // 
            // uxRemoveBookButton
            // 
            uxRemoveBookButton.Location = new Point(486, 50);
            uxRemoveBookButton.Name = "uxRemoveBookButton";
            uxRemoveBookButton.Size = new Size(94, 23);
            uxRemoveBookButton.TabIndex = 12;
            uxRemoveBookButton.Text = "Remove Book";
            uxRemoveBookButton.UseVisualStyleBackColor = true;
            uxRemoveBookButton.Click += uxRemoveBookButton_Click;
            // 
            // AdminForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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