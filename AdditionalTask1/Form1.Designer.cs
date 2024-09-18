namespace Gutenberg_Shakespeare
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
            startButton = new Button();
            hamletTextBox = new TextBox();
            SuspendLayout();
            // 
            // startButton
            // 
            startButton.FlatStyle = FlatStyle.Flat;
            startButton.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            startButton.Location = new Point(352, 35);
            startButton.Name = "startButton";
            startButton.Size = new Size(103, 39);
            startButton.TabIndex = 0;
            startButton.Text = "Go";
            startButton.UseVisualStyleBackColor = true;
            startButton.Click += startButton_Click;
            // 
            // hamletTextBox
            // 
            hamletTextBox.Location = new Point(76, 101);
            hamletTextBox.Multiline = true;
            hamletTextBox.Name = "hamletTextBox";
            hamletTextBox.ScrollBars = ScrollBars.Vertical;
            hamletTextBox.Size = new Size(673, 324);
            hamletTextBox.TabIndex = 1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(hamletTextBox);
            Controls.Add(startButton);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button startButton;
        private TextBox hamletTextBox;
    }
}
