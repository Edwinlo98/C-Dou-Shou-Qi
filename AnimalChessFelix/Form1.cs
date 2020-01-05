using System;
using System.Collections;
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
    public partial class Form1 : Form
    {
        CNode root; 

        int[,] pemain = new int[9,7];
        string[,] hewan  = new string[9, 7];
        int giliran;
        int numofclick;
        int clickedy, clickedx;
        public string modePlay;
        ArrayList dataHewan = new ArrayList();

        public void goPlay()
        {
            numofclick = 0;
            clickedy = 0;
            clickedx = 0; 
            giliran = 1; 
            for(int a = 0; a < 9; a++)
            {
                for(int b = 0; b < 7; b++)
                {
                    pemain[a, b] = 0;
                    hewan[a, b] = ""; 

                    if(a == 8 && b == 0)
                    {
                        pemain[a, b] = 1;
                        hewan[a, b] = "tiger";
                        dataHewan.Add("tiger-"+a.ToString()+"-"+b.ToString());
                    }
                    else if (a == 6 && b == 0)
                    {
                        pemain[a, b] = 2;
                        hewan[a, b] = "rat";
                        dataHewan.Add("rat-" + a.ToString() + "-" + b.ToString());
                    }
                    else if (a == 6 && b == 2)
                    {
                        pemain[a, b] = 3;
                        hewan[a, b] = "wolf";
                        dataHewan.Add("wolf-" + a.ToString() + "-" + b.ToString());
                    }
                    else if (a == 6 && b == 3)
                    {
                        pemain[a, b] = 4;
                        hewan[a, b] = "dog";
                        dataHewan.Add("dog-" + a.ToString() + "-" + b.ToString());
                    }
                    else if (a == 6 && b == 5)
                    {
                        pemain[a, b] = 5;
                        hewan[a, b] = "leopard";
                        dataHewan.Add("leopard-" + a.ToString() + "-" + b.ToString());
                    }
                    else if (a == 7 && b ==6)
                    {
                        pemain[a, b] = 6;
                        hewan[a, b] = "lion";
                        dataHewan.Add("lion-" + a.ToString() + "-" + b.ToString());
                    }
                    else if (a == 8 && b == 1)
                    {
                        pemain[a, b] = 7;
                        hewan[a, b] = "elepant";
                        dataHewan.Add("elepant-" + a.ToString() + "-" + b.ToString());
                    }
                    else if (a == 7 && b == 4)
                    {
                        pemain[a, b] = 8;
                        hewan[a, b] = "cat";
                        dataHewan.Add("cat-" + a.ToString() + "-" + b.ToString());
                    }
                }
            }
            root = new CNode(0, giliran, hewan);

            refreshlayar(); 
        }

        public void refreshlayar()
        {
            if(giliran == 1) { lblgiliran.Text = "Giliran : Player 1"; }
            else { lblgiliran.Text = "Giliran : Player 2"; }
            this.Invalidate();
        }

        public Form1()
        {
            InitializeComponent();
            goPlay();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = (Graphics)e.Graphics;
            for (int a = 0; a < 9; a++)
            {
                for (int b = 0; b < 7; b++)
                {
                    if((a >= 3 && a <= 5) && (b == 1 || b == 2 || b == 4 || b == 5))
                    {
                        g.FillRectangle(new SolidBrush(Color.Blue), 20 + (b * 60), 20 + (a * 60), 61, 61);
                    }
                    else if ((a == 0 && (b == 2 || b == 4)) || (a == 1 && b == 3))
                    {
                        g.FillRectangle(new SolidBrush(Color.Magenta), 20 + (b * 60), 20 + (a * 60), 61, 61);
                    }
                    else if ((a == 8 && (b == 2 || b == 4)) || (a == 7 && b == 3))
                    {
                        g.FillRectangle(new SolidBrush(Color.Pink), 20 + (b * 60), 20 + (a * 60), 61, 61);
                    }

                    if(numofclick == 1)
                    {
                        if(a == clickedy && b == clickedx)
                        {
                            g.DrawRectangle(new Pen(Color.Red, 2), 20 + (b * 60) - 5, 20 + (a * 60) - 5, 61 + 10, 61 + 10);
                        }
                        g.DrawRectangle(new Pen(Color.Black, 2), 20 + (b * 60), 20 + (a * 60), 61, 61);
                    }
                    else
                    {
                        g.DrawRectangle(new Pen(Color.Black, 2), 20 + (b * 60), 20 + (a * 60), 61, 61);
                    }

                    if (pemain[a,b] != 0)
                    {
                        g.DrawString(hewan[a,b].ToUpper(), new Font("Arial", 7), new SolidBrush(Color.Black), 
                            20 + (b * 60) + 5, 20 + (a * 60) + 10);
                    }
                }
            }

            foreach (var item in dataHewan)
            {
                String data = item.ToString();
                String[] sp = data.Split('-');
                for (int i = 0; i < sp.Length; i++)
                {
                    if (sp[0].Equals("tiger"))
                    {
                        g.DrawImage(Image.FromFile(@"C:\Users\hp\Desktop\AnimalChessFelix\AnimalChessFelix\Image\tiger.png"), 20 + (Convert.ToInt32(sp[2]) * 60), 20 + (Convert.ToInt32(sp[1]) * 60), 61, 61);
                    }
                    else if (sp[0].Equals("rat"))
                    {
                        g.DrawImage(Image.FromFile(@"C:\Users\hp\Desktop\AnimalChessFelix\AnimalChessFelix\Image\rat.png"), 20 + (Convert.ToInt32(sp[2]) * 60), 20 + (Convert.ToInt32(sp[1]) * 60), 61, 61);
                    }
                    else if (sp[0].Equals("wolf"))
                    {
                        g.DrawImage(Image.FromFile(@"C:\Users\hp\Desktop\AnimalChessFelix\AnimalChessFelix\Image\wolf.png"), 20 + (Convert.ToInt32(sp[2]) * 60), 20 + (Convert.ToInt32(sp[1]) * 60), 61, 61);
                    }
                    else if (sp[0].Equals("dog"))
                    {
                        g.DrawImage(Image.FromFile(@"C:\Users\hp\Desktop\AnimalChessFelix\AnimalChessFelix\Image\dog.png"), 20 + (Convert.ToInt32(sp[2]) * 60), 20 + (Convert.ToInt32(sp[1]) * 60), 61, 61);
                    }
                    else if (sp[0].Equals("leopard"))
                    {
                        g.DrawImage(Image.FromFile(@"C:\Users\hp\Desktop\AnimalChessFelix\AnimalChessFelix\Image\leopard.png"), 20 + (Convert.ToInt32(sp[2]) * 60), 20 + (Convert.ToInt32(sp[1]) * 60), 61, 61);
                    }
                    else if (sp[0].Equals("lion"))
                    {
                        g.DrawImage(Image.FromFile(@"C:\Users\hp\Desktop\AnimalChessFelix\Image\lion.png"), 20 + (Convert.ToInt32(sp[2]) * 60), 20 + (Convert.ToInt32(sp[1]) * 60), 61, 61);
                    }
                    else if (sp[0].Equals("elepant"))
                    {
                        g.DrawImage(Image.FromFile(@"C:\Users\hp\Desktop\AnimalChessFelix\AnimalChessFelix\Image\elephant.png"), 20 + (Convert.ToInt32(sp[2]) * 60), 20 + (Convert.ToInt32(sp[1]) * 60), 61, 61);
                    }
                    else if (sp[0].Equals("cat"))
                    {
                        g.DrawImage(Image.FromFile(@"C:\Users\hp\Desktop\AnimalChessFelix\AnimalChessFelix\Image\cat.png"), 20 + (Convert.ToInt32(sp[2]) * 60), 20 + (Convert.ToInt32(sp[1]) * 60), 61, 61);
                    }
                }
            }
        }

        private void changeturn()
        {
            giliran += 1;
            if (giliran == 3) {
                giliran = 1;
            }
        }

        private void swap(int y1, int x1, int y2, int x2)
        {
            int t = pemain[y1, x1];
            pemain[y1, x1] = pemain[y2, x2];
            pemain[y2, x2] = t;

            String u = hewan[y1, x1];
            hewan[y1, x1] = hewan[y2, x2];
            hewan[y2, x2] = u;
        }

        public int bobot(string thewan)
        {
            if(thewan == "rat") { return 1; }
            else if (thewan == "cat") { return 2; }
            else if (thewan == "wolf") { return 3; }
            else if (thewan == "dog") { return 4; }
            else if (thewan == "leopard") { return 5; }
            else if (thewan == "tiger") { return 6; }
            else if (thewan == "lion") { return 7; }
            else if (thewan == "elephant") { return 8; }
            else { return 0; }
        }

        public bool bolehMelangkah(int tpemain1, string thewan1, int y1, int x1, int y2, int x2, int tpemain2, string thewan2)
        {
            bool boleh = false;
            int sy = Math.Abs(y1 - y2);
            int sx = Math.Abs(x1 - x2); 
            if((sy == 1 && sx == 0) || (sy == 0 && sy == 1))
            {
                if(y2 >= 3 && y2 <= 5 && (x2 == 1 || x2 == 2 || x2 == 4 || x2 == 5))
                {
                    if(thewan1 == "rat")
                    {
                        boleh = true; 
                    }
                }
                else {
                    if (bobot(thewan1) >= bobot(thewan2)) { boleh = true; }
                    else if(thewan1 == "rat" && thewan2 == "elephant") { boleh = true; }
                }
            }
            else if((sy == 0 && sx == 3 && (x1 == 0 || x1 == 3 || x1 == 6)) ||
                   (sy == 4 && sx == 0 && (y1 == 2 || x1 == 6)))
            {
                if(thewan1 == "tiger" || thewan1 == "lion")
                {
                    if (bobot(thewan1) >= bobot(thewan2)) {
                        if (sx == 3)    // horiz
                        {
                            if(x1 < x2)
                            {
                                int adaRat = 0; 
                                for(int k = x1 + 1; k < x2; k++)
                                {
                                    if(hewan[y1, k] == "rat")
                                    { adaRat += 1; }
                                }
                                if(adaRat == 0) { boleh = true; }
                            }
                            else
                            {
                                int adaRat = 0;
                                for (int k = x1 - 1; k > x2; k--)
                                {
                                    if (hewan[y1, k] == "rat")
                                    { adaRat += 1; }
                                }
                                if (adaRat == 0) { boleh = true; }
                            }
                        }
                        else        // vertical
                        {
                            if (y1 < y2)
                            {
                                int adaRat = 0;
                                for (int k = y1 + 1; k < y2; k++)
                                {
                                    if (hewan[k, x1] == "rat")
                                    { adaRat += 1; }
                                }
                                if (adaRat == 0) { boleh = true; }
                            }
                            else
                            {
                                int adaRat = 0;
                                for (int k = y1 - 1; k > y2; k--)
                                {
                                    if (hewan[k, x1] == "rat")
                                    { adaRat += 1; }
                                }
                                if (adaRat == 0) { boleh = true; }
                            }
                        }
                    }
                }
            }

            return boleh;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            int arry = (e.Y - 20) / 61;
            int arrx = (e.X - 20) / 61;
            
            if(numofclick == 0)
            {
                if (pemain[arry, arrx] == giliran)
                {
                    clickedy = arry;
                    clickedx = arrx;
                    numofclick = 1;
                    refreshlayar(); 
                }
                else { MessageBox.Show("Wrong turn"); }
            }
            else
            {
                if(pemain[arry, arrx] == giliran) { MessageBox.Show("Wrong Place"); numofclick = 0; }
                else
                {
                    if (bolehMelangkah(pemain[clickedy, clickedx], hewan[clickedy, clickedx], 
                        clickedy, clickedx, arry, arrx, pemain[arry, arrx], hewan[arry, arrx]) == true)
                    {
                        swap(clickedy, clickedx, arry, arrx);
                        numofclick = 0;
                        changeturn();
                    }
                    else {
                        MessageBox.Show("Wrong Place");
                        numofclick = 0;
                    }
                }
                refreshlayar(); 
            }
        }
    }
}
