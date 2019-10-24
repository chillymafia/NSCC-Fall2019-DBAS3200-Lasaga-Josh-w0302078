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
            //getting list of genres from dal genremanager
            List<Genre> genres = GenreManager.GetGenreList();

            //put the data into the listbox
            GenreListBox.DataSource = genres;
            GenreListBox.DisplayMember = "Name";
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if(genreIDTextBox.Text == string.Empty)
            {
                Genre g = new Genre();
                g.Name = NameTextBox.Text;

            }
            
            else
            {
                //save changes to existing item (genre)
                int genreID = int.Parse(genreIDTextBox.Text);
                string genreName = NameTextBox.Text;

                if (GenreManager.UpdateGenre(genreID, genreName) == 1)
                {
                    //update successful
                    MessageBox.Show("Genre Updated");
                    //update the value in the list
                    //((Genre)GenreListBox.SelectedItem).Name = genreName;
                    List<Genre> genreList = GenreManager.GetGenreList();
                    GenreListBox.DataSource = genreList;

                    //reselect the chosen box



                }
                else
                {

                    MessageBox.Show("NOT Updated");
                }
            }
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            //update text boxes with the new serlected item
            Genre selectedGenre = (Genre)GenreListBox.SelectedItem;

            genreIDTextBox.Text = selectedGenre.GenreID.ToString();
            NameTextBox.Text = selectedGenre.Name;
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            int GenreID = int.Parse(genreIDTextBox.Text);

            int rowsAffected = GenreManager.DeleteGenre(GenreID);

            if(rowsAffected == 1)
            {
                MessageBox.Show("Genre Deleted", "Deleted", MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(
                    "Unable to Deete Genre, check log file for more details",
                    );
            }

            
        }

        private void AddNewButton_Click(object sender, EventArgs e)
        {
            // set the value of the id in the textbox to be empty string
            genreIDTextBox.Text = string.Empty;

            //clear any value in the name text box
            NameTextBox.Text = string.Empty;

            //clear any selection in the istbox

            GenreListBox.SelectedIndex
        }
    }
}
