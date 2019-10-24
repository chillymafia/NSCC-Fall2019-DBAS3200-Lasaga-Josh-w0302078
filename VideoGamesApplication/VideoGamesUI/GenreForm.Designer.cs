namespace VideoGamesUI
{
    partial class GenreForm
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
            this.GenreListBox = new System.Windows.Forms.ListBox();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.Namelabel = new System.Windows.Forms.Label();
            this.GenreIDTextBox = new System.Windows.Forms.TextBox();
            this.GenreIDLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // GenreListBox
            // 
            this.GenreListBox.FormattingEnabled = true;
            this.GenreListBox.Location = new System.Drawing.Point(12, 12);
            this.GenreListBox.Name = "GenreListBox";
            this.GenreListBox.Size = new System.Drawing.Size(207, 420);
            this.GenreListBox.TabIndex = 0;
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(414, 154);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(100, 20);
            this.NameTextBox.TabIndex = 1;
            // 
            // Namelabel
            // 
            this.Namelabel.AutoSize = true;
            this.Namelabel.Location = new System.Drawing.Point(360, 157);
            this.Namelabel.Name = "Namelabel";
            this.Namelabel.Size = new System.Drawing.Size(35, 13);
            this.Namelabel.TabIndex = 2;
            this.Namelabel.Text = "Name";
            this.Namelabel.Click += new System.EventHandler(this.Namelabel_Click);
            // 
            // GenreIDTextBox
            // 
            this.GenreIDTextBox.Location = new System.Drawing.Point(414, 110);
            this.GenreIDTextBox.Name = "GenreIDTextBox";
            this.GenreIDTextBox.ReadOnly = true;
            this.GenreIDTextBox.Size = new System.Drawing.Size(100, 20);
            this.GenreIDTextBox.TabIndex = 3;
            // 
            // GenreIDLabel
            // 
            this.GenreIDLabel.AutoSize = true;
            this.GenreIDLabel.Location = new System.Drawing.Point(360, 113);
            this.GenreIDLabel.Name = "GenreIDLabel";
            this.GenreIDLabel.Size = new System.Drawing.Size(21, 13);
            this.GenreIDLabel.TabIndex = 4;
            this.GenreIDLabel.Text = "ID:";
            // 
            // GenreForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.GenreIDLabel);
            this.Controls.Add(this.GenreIDTextBox);
            this.Controls.Add(this.Namelabel);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.GenreListBox);
            this.Name = "GenreForm";
            this.Text = "GenreForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.GenreForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox GenreListBox;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.Label Namelabel;
        private System.Windows.Forms.TextBox GenreIDTextBox;
        private System.Windows.Forms.Label GenreIDLabel;
    }
}