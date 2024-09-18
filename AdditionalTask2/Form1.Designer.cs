namespace Gutenberg_PopularBooks
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
            bookListBox = new ListBox();
            bookTextBox = new RichTextBox();
            SuspendLayout();
            // 
            // bookListBox
            // 
            bookListBox.FormattingEnabled = true;
            bookListBox.ItemHeight = 15;
            bookListBox.Location = new Point(34, 28);
            bookListBox.Name = "bookListBox";
            bookListBox.Size = new Size(243, 379);
            bookListBox.TabIndex = 0;
            bookListBox.SelectedIndexChanged += bookListBox_SelectedIndexChanged;
            // 
            // bookTextBox
            // 
            bookTextBox.Location = new Point(346, 28);
            bookTextBox.Name = "bookTextBox";
            bookTextBox.Size = new Size(421, 379);
            bookTextBox.TabIndex = 1;
            bookTextBox.Text = "";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(bookTextBox);
            Controls.Add(bookListBox);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private ListBox bookListBox;
        private RichTextBox bookTextBox;
    }
}
