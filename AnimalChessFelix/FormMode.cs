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
            new Form1().modePlay = "Easy";
            this.Hide();
            new Form1().ShowDialog();
            this.Close();
        }

        private void btnMedium_Click(object sender, EventArgs e)
        {
            new Form1().modePlay = "Medium";
            this.Hide();
            new Form1().ShowDialog();
            this.Close();
        }

        private void btnHard_Click(object sender, EventArgs e)
        {
            new Form1().modePlay = "Hard";
            this.Hide();
            new Form1().ShowDialog();
            this.Close();
        }
    }
}
