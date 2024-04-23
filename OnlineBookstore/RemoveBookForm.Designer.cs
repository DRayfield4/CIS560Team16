namespace OnlineBookstore
{
    partial class RemoveBookForm
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
            uxBooksList = new ListBox();
            uxRemoveBookButton = new Button();
            uxUndoButton = new Button();
            SuspendLayout();
            // 
            // uxBooksList
            // 
            uxBooksList.FormattingEnabled = true;
            uxBooksList.ItemHeight = 20;
            uxBooksList.Location = new Point(137, 59);
            uxBooksList.Name = "uxBooksList";
            uxBooksList.Size = new Size(538, 204);
            uxBooksList.TabIndex = 0;
            // 
            // uxRemoveBookButton
            // 
            uxRemoveBookButton.Location = new Point(252, 325);
            uxRemoveBookButton.Name = "uxRemoveBookButton";
            uxRemoveBookButton.Size = new Size(94, 29);
            uxRemoveBookButton.TabIndex = 1;
            uxRemoveBookButton.Text = "Remove";
            uxRemoveBookButton.UseVisualStyleBackColor = true;
            uxRemoveBookButton.Click += uxRemoveBookButton_Click;
            // 
            // uxUndoButton
            // 
            uxUndoButton.Location = new Point(487, 325);
            uxUndoButton.Name = "uxUndoButton";
            uxUndoButton.Size = new Size(94, 29);
            uxUndoButton.TabIndex = 2;
            uxUndoButton.Text = "Undo";
            uxUndoButton.UseVisualStyleBackColor = true;
            uxUndoButton.Click += uxUndoButton_Click;
            // 
            // RemoveBookForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(uxUndoButton);
            Controls.Add(uxRemoveBookButton);
            Controls.Add(uxBooksList);
            Name = "RemoveBookForm";
            Text = "RemoveBookForm";
            ResumeLayout(false);
        }

        #endregion

        private ListBox uxBooksList;
        private Button uxRemoveBookButton;
        private Button uxUndoButton;
    }
}