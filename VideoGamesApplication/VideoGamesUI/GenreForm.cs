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

        private void Namelabel_Click(object sender, EventArgs e)
        {
            //update text boxes with the new serlected item
            Genre selectedGenre = (Genre)GenreListBox.SelectedItem;

            GenreIDTextBox.Text = selectedGenre.GenreID.ToString();
            NameTextBox.Text = selectedGenre.Name;
        }
    }
}
