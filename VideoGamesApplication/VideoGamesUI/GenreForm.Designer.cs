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
            this.NameLabel = new System.Windows.Forms.Label();
            this.GenreIDTextBox = new System.Windows.Forms.TextBox();
            this.GenreIdLabel = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.AddNewButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // GenreListBox
            // 
            this.GenreListBox.FormattingEnabled = true;
            this.GenreListBox.Location = new System.Drawing.Point(12, 64);
            this.GenreListBox.Name = "GenreListBox";
            this.GenreListBox.Size = new System.Drawing.Size(224, 342);
            this.GenreListBox.TabIndex = 0;
            this.GenreListBox.SelectedIndexChanged += new System.EventHandler(this.GenreListBox_SelectedIndexChanged);
            // 
            // NameTextBox
            // 
            this.NameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameTextBox.Location = new System.Drawing.Point(358, 114);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(277, 35);
            this.NameTextBox.TabIndex = 1;
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameLabel.Location = new System.Drawing.Point(268, 117);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(84, 29);
            this.NameLabel.TabIndex = 2;
            this.NameLabel.Text = "Name:";
            // 
            // GenreIDTextBox
            // 
            this.GenreIDTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GenreIDTextBox.Location = new System.Drawing.Point(358, 64);
            this.GenreIDTextBox.Name = "GenreIDTextBox";
            this.GenreIDTextBox.ReadOnly = true;
            this.GenreIDTextBox.Size = new System.Drawing.Size(94, 35);
            this.GenreIDTextBox.TabIndex = 3;
            // 
            // GenreIdLabel
            // 
            this.GenreIdLabel.AutoSize = true;
            this.GenreIdLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GenreIdLabel.Location = new System.Drawing.Point(313, 67);
            this.GenreIdLabel.Name = "GenreIdLabel";
            this.GenreIdLabel.Size = new System.Drawing.Size(39, 29);
            this.GenreIdLabel.TabIndex = 4;
            this.GenreIdLabel.Text = "Id:";
            // 
            // SaveButton
            // 
            this.SaveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveButton.Location = new System.Drawing.Point(358, 175);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(107, 47);
            this.SaveButton.TabIndex = 5;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteButton.Location = new System.Drawing.Point(471, 175);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(107, 47);
            this.DeleteButton.TabIndex = 6;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // AddNewButton
            // 
            this.AddNewButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddNewButton.Location = new System.Drawing.Point(584, 175);
            this.AddNewButton.Name = "AddNewButton";
            this.AddNewButton.Size = new System.Drawing.Size(107, 47);
            this.AddNewButton.TabIndex = 7;
            this.AddNewButton.Text = "Add New";
            this.AddNewButton.UseVisualStyleBackColor = true;
            this.AddNewButton.Click += new System.EventHandler(this.AddNewButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(182, 55);
            this.label4.TabIndex = 8;
            this.label4.Text = "Genres";
            // 
            // GenreForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.AddNewButton);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.GenreIdLabel);
            this.Controls.Add(this.GenreIDTextBox);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.GenreListBox);
            this.Name = "GenreForm";
            this.Load += new System.EventHandler(this.GenreForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox GenreListBox;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.TextBox GenreIDTextBox;
        private System.Windows.Forms.Label GenreIdLabel;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button AddNewButton;
        private System.Windows.Forms.Label label4;
    }
}