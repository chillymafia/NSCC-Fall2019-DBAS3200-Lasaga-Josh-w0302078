using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VideoGamesDAL;
using VideoGamesDAL.Models;

namespace VideoGamesUI
{
    public partial class GenreForm : Form
    {
        private TextBox GenreIDTextBox;
        private TextBox NameTextBox;
        private Button SaveButton;
        private Button DeleteButton;
        private Label IDLabel;
        private Label NameLabel;
        private Button AddNewButton;
        private ListBox GenreListBox;

        public GenreForm()
        {
            InitializeComponent();
        }

        private void GenreForm_Load(object sender, EventArgs e)
        {
            //GETTING LIST OF GENRES FROM DAL (GenreManager)
            List<Genre> genres = GenreManager.GetGenreList();

            //PUT THE DATA INTO THE LISTBOX
            GenreListBox.DataSource = genres;
            GenreListBox.DisplayMember = "Name";

        }

        private void GenreListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (GenreListBox.SelectedIndex > -1)
            {
                //UPDATE THE TEXTBOXES WITH THE NEW SELECTED ITEM
                Genre selectedGenre = (Genre)GenreListBox.SelectedItem;

                GenreIDTextBox.Text = selectedGenre.GenreID.ToString();
                NameTextBox.Text = selectedGenre.Name;
            }

        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (GenreIDTextBox.Text == string.Empty)
            {
                //new entry .... save as new
                Genre g = new Genre();
                g.Name = NameTextBox.Text;

                //call DAL method to save data
                Genre savedGenre = GenreManager.AddGenre(g);

                //create successful
                MessageBox.Show("Genre Added");

                //refresh the genre list to display new genre
                List<Genre> genreList = GenreManager.GetGenreList();
                GenreListBox.DataSource = genreList;

                //select the new genre from the listbox
                SelectGenreFromListBox(savedGenre.GenreID);
            }
            else
            {
                //SAVE CHANGES TO EXISTING ITEM (genre)

                //get the selected genre id and name from text boxes
                int GenreID = int.Parse(GenreIDTextBox.Text);
                string GenreName = NameTextBox.Text;

                Genre newGenre = new Genre()
                {
                    GenreID = GenreID,
                    Name = GenreName
                };

                //execute DAL update and check result
                if (GenreManager.UpdateGenre(newGenre) == 1)
                {
                    //update successful
                    MessageBox.Show("Genre Updated");

                    //refresh the list
                    List<Genre> genreList = GenreManager.GetGenreList();
                    GenreListBox.DataSource = genreList;

                    //re-select the updated genre
                    SelectGenreFromListBox(GenreID);
                }
                else
                {
                    MessageBox.Show("NOT updated");
                }
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            //get the genre id to delete
            int GenreID = int.Parse(GenreIDTextBox.Text);

            //execute Delete in DAL
            int rowsAffected = GenreManager.DeleteGenre(GenreID);

            //Check Results
            if (rowsAffected == 1)
            {
                //Delete successful
                MessageBox.Show(
                    "Genre Deleted",
                    "Deleted",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                //refresh the list box because the genre was deleted
                GenreListBox.DataSource = GenreManager.GetGenreList();
            }
            else
            {
                //Delete failed
                MessageBox.Show(
                    "Unable to delete genre. Check log files for details",
                    "Unable to Delete",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void AddNewButton_Click(object sender, EventArgs e)
        {
            //set the value of id in the textbox to be empty string
            GenreIDTextBox.Text = string.Empty;

            //clear any value in the name textbox
            NameTextBox.Text = string.Empty;

            //clear any selection in the listbox
            GenreListBox.SelectedIndex = -1;

            //set focus to the name list box
            NameTextBox.Focus();
        }

        private void SelectGenreFromListBox(int GenreID)
        {
            foreach (var item in GenreListBox.Items)
            {
                Genre g = (Genre)item;
                if (g.GenreID == GenreID)
                {
                    //we found the genre....select it
                    GenreListBox.SelectedItem = item;
                    return;
                }
            }
        }

        private void InitializeComponent()
        {
            this.GenreListBox = new System.Windows.Forms.ListBox();
            this.GenreIDTextBox = new System.Windows.Forms.TextBox();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.IDLabel = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.AddNewButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // GenreListBox
            // 
            this.GenreListBox.FormattingEnabled = true;
            this.GenreListBox.Location = new System.Drawing.Point(13, 13);
            this.GenreListBox.Name = "GenreListBox";
            this.GenreListBox.Size = new System.Drawing.Size(194, 355);
            this.GenreListBox.TabIndex = 0;
            // 
            // GenreIDTextBox
            // 
            this.GenreIDTextBox.Location = new System.Drawing.Point(390, 107);
            this.GenreIDTextBox.Name = "GenreIDTextBox";
            this.GenreIDTextBox.Size = new System.Drawing.Size(100, 20);
            this.GenreIDTextBox.TabIndex = 1;
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(390, 149);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(100, 20);
            this.NameTextBox.TabIndex = 2;
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(349, 192);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 3;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(430, 192);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(75, 23);
            this.DeleteButton.TabIndex = 4;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // IDLabel
            // 
            this.IDLabel.AutoSize = true;
            this.IDLabel.Location = new System.Drawing.Point(351, 107);
            this.IDLabel.Name = "IDLabel";
            this.IDLabel.Size = new System.Drawing.Size(21, 13);
            this.IDLabel.TabIndex = 5;
            this.IDLabel.Text = "ID:";
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(346, 152);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(38, 13);
            this.NameLabel.TabIndex = 6;
            this.NameLabel.Text = "Name:";
            // 
            // AddNewButton
            // 
            this.AddNewButton.Location = new System.Drawing.Point(512, 191);
            this.AddNewButton.Name = "AddNewButton";
            this.AddNewButton.Size = new System.Drawing.Size(75, 23);
            this.AddNewButton.TabIndex = 7;
            this.AddNewButton.Text = "Add New";
            this.AddNewButton.UseVisualStyleBackColor = true;
            // 
            // GenreForm
            // 
            this.ClientSize = new System.Drawing.Size(783, 388);
            this.Controls.Add(this.AddNewButton);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.IDLabel);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.GenreIDTextBox);
            this.Controls.Add(this.GenreListBox);
            this.Name = "GenreForm";
            this.Load += new System.EventHandler(this.GenreForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

    }
}
