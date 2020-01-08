using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnimalChessFelix
{
    public partial class FormMode : Form
    {
        public FormMode()
        {
            InitializeComponent();
        }

        private void btnEasy_Click(object sender, EventArgs e)
        {
            FormEasy f = new FormEasy();
            f.modePlay = "Easy";
            this.Hide();
            f.ShowDialog();
            this.Close();
        }

        private void btnMedium_Click(object sender, EventArgs e)
        {
            //AI Jalan duluan
            FormMedium f = new FormMedium(1);
            this.Hide();
            f.ShowDialog();
            this.Close();
        }

        private void btnHard_Click(object sender, EventArgs e)
        {
            FormEasy f = new FormEasy();
            f.modePlay = "Hard";
            this.Hide();
            f.ShowDialog();
            this.Close();
        }
    }
}
