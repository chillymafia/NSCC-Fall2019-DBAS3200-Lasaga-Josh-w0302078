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

                //execute DAL update and check result
                if (GenreManager.UpdateGenre(GenreID, GenreName) == 1)
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
    }
}
