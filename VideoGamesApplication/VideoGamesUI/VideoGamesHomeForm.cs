using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VideoGamesUI
{
    public partial class VideoGamesHomeForm : Form
    {
        public VideoGamesHomeForm()
        {
            InitializeComponent();
        }

        private void VideoGamesHomeForm_Load(object sender, EventArgs e)
        {
            Form genreForm = new GenreForm();
            genreForm.MdiParent = this;
            genreForm.FormBorderStyle = FormBorderStyle.None;
            genreForm.Dock = DockStyle.Fill;

            genreForm.Show();
        }

        private void AppToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Goodbye");
            Application.Exit();
        }
    }
}
