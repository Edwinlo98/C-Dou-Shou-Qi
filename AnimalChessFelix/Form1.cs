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
        int widthBoard = 7, heightBoard = 9;
        int[,] pemain = new int[9,7];
        string[,] hewan  = new string[9, 7];
        char[,] board;
        int giliran;
        int numofclick;
        int clickedy, clickedx;
        int lx=0, ly=0;
        public string modePlay;
        ArrayList dataHewan = new ArrayList();


        public void goPlay()
        {
            // E = elephant
            // I = tiger
            // C = cat
            // W = wolf
            // O = leopard
            // G = dog
            // R = rat
            // L = lion
            board = new char[9,7]
            {
                {'l','.','t','d','t','.','i'},
                {'.','g','.','t','.','c','.'},
                {'r','.','o','.','w','.','e'},
                {'.','-','-','.','-','-','.'},
                {'.','-','-','.','-','-','.'},
                {'.','-','-','.','-','-','.'},
                {'E','.','W','.','O','.','R'},
                {'.','C','.','T','.','G','.'},
                {'I','.','T','D','T','.','L'},
            };
            numofclick = 0;
            clickedy = 0;
            clickedx = 0; 
            giliran = 1;
            //for(int a = 0; a < 9; a++)
            //{
            //    for(int b = 0; b < 7; b++)
            //    {
            //        pemain[a, b] = 0;
            //        hewan[a, b] = ""; 

            //        if(a == 8 && b == 0)
            //        {
            //            pemain[a, b] = 1;
            //            hewan[a, b] = "tiger";
            //            dataHewan.Add("tiger-"+a.ToString()+"-"+b.ToString());
            //        }
            //        else if (a == 6 && b == 0)
            //        {
            //            pemain[a, b] = 2;
            //            hewan[a, b] = "rat";
            //            dataHewan.Add("rat-" + a.ToString() + "-" + b.ToString());
            //        }
            //        else if (a == 6 && b == 2)
            //        {
            //            pemain[a, b] = 3;
            //            hewan[a, b] = "wolf";
            //            dataHewan.Add("wolf-" + a.ToString() + "-" + b.ToString());
            //        }
            //        else if (a == 6 && b == 3)
            //        {
            //            pemain[a, b] = 4;
            //            hewan[a, b] = "dog";
            //            dataHewan.Add("dog-" + a.ToString() + "-" + b.ToString());
            //        }
            //        else if (a == 6 && b == 5)
            //        {
            //            pemain[a, b] = 5;
            //            hewan[a, b] = "leopard";
            //            dataHewan.Add("leopard-" + a.ToString() + "-" + b.ToString());
            //        }
            //        else if (a == 7 && b ==6)
            //        {
            //            pemain[a, b] = 6;
            //            hewan[a, b] = "lion";
            //            dataHewan.Add("lion-" + a.ToString() + "-" + b.ToString());
            //        }
            //        else if (a == 8 && b == 1)
            //        {
            //            pemain[a, b] = 7;
            //            hewan[a, b] = "elepant";
            //            dataHewan.Add("elepant-" + a.ToString() + "-" + b.ToString());
            //        }
            //        else if (a == 7 && b == 4)
            //        {
            //            pemain[a, b] = 8;
            //            hewan[a, b] = "cat";
            //            dataHewan.Add("cat-" + a.ToString() + "-" + b.ToString());
            //        }
            //    }
            //}
            for (int i = 0; i < heightBoard; i++)
            {
                for (int j = 0; j < widthBoard; j++)
                {
                    if (board[i,j]!='.'&& board[i, j] != '-'&& board[i, j] != 'd'&& board[i, j] != 'D'&& board[i, j] != 't'&& board[i, j] != 'T')
                    {
                        dataHewan.Add(board[i, j] + "-" + i + "-" + j);
                    }
                }
            }

            //foreach (var item in dataHewan)
            //{
            //    MessageBox.Show(item+"");
            //}
            root = new CNode(0, giliran, hewan);

            refreshlayar(); 
        }

        public void refreshlayar()
        {
            if(giliran == 1) { lblgiliran.Text = "Giliran : Player 1"; }
            else { lblgiliran.Text = "Giliran : Player 2"; }
            numofclick = 0;
            clickedx = 0;
            label3.Text = clickedx.ToString();
            clickedy = 0;
            label4.Text = clickedy.ToString();
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
            //for (int a = 0; a < 9; a++)
            //{
            //    for (int b = 0; b < 7; b++)
            //    {
            //        if((a >= 3 && a <= 5) && (b == 1 || b == 2 || b == 4 || b == 5))
            //        {
            //            g.FillRectangle(new SolidBrush(Color.Blue), 20 + (b * 60), 20 + (a * 60), 61, 61);
            //        }
            //        else if ((a == 0 && (b == 2 || b == 4)) || (a == 1 && b == 3))
            //        {
            //            g.FillRectangle(new SolidBrush(Color.Magenta), 20 + (b * 60), 20 + (a * 60), 61, 61);
            //        }
            //        else if ((a == 8 && (b == 2 || b == 4)) || (a == 7 && b == 3))
            //        {
            //            g.FillRectangle(new SolidBrush(Color.Pink), 20 + (b * 60), 20 + (a * 60), 61, 61);
            //        }

            //        if(numofclick == 1)
            //        {
            //            if(a == clickedy && b == clickedx)
            //            {
            //                g.DrawRectangle(new Pen(Color.Red, 2), 20 + (b * 60) - 5, 20 + (a * 60) - 5, 61 + 10, 61 + 10);
            //            }
            //            g.DrawRectangle(new Pen(Color.Black, 2), 20 + (b * 60), 20 + (a * 60), 61, 61);
            //        }
            //        else
            //        {
            //            g.DrawRectangle(new Pen(Color.Black, 2), 20 + (b * 60), 20 + (a * 60), 61, 61);
            //        }

            //        if (pemain[a,b] != 0)
            //        {
            //            g.DrawString(hewan[a,b].ToUpper(), new Font("Arial", 7), new SolidBrush(Color.Black), 
            //                20 + (b * 60) + 5, 20 + (a * 60) + 10);
            //            if (pemain[a,b]==1)
            //            {
            //                //for
            //            }
            //        }
            //    }
            //}

            for (int i = 0; i < heightBoard; i++)
            {
                for (int j = 0; j < widthBoard; j++)
                {
                    if (board[i, j] == 'E')
                    {
                        g.DrawImage(Image.FromFile(@"C:\Users\hp\Desktop\AnimalChessFelix\AnimalChessFelix\Image\Player\elephant.png"), 20 + (j * 60), 20 + (i * 60), 61, 61);
                    }
                    if (board[i, j] == 'I')
                    {
                        g.DrawImage(Image.FromFile(@"C:\Users\hp\Desktop\AnimalChessFelix\AnimalChessFelix\Image\Player\tiger.png"), 20 + (j * 60), 20 + (i * 60), 61, 61);
                    }
                    if (board[i, j] == 'C')
                    {
                        g.DrawImage(Image.FromFile(@"C:\Users\hp\Desktop\AnimalChessFelix\AnimalChessFelix\Image\Player\cat.png"), 20 + (j * 60), 20 + (i * 60), 61, 61);
                    }
                    if (board[i, j] == 'W')
                    {
                        g.DrawImage(Image.FromFile(@"C:\Users\hp\Desktop\AnimalChessFelix\AnimalChessFelix\Image\Player\wolf.png"), 20 + (j * 60), 20 + (i * 60), 61, 61);
                    }
                    if (board[i, j] == 'O')
                    {
                        g.DrawImage(Image.FromFile(@"C:\Users\hp\Desktop\AnimalChessFelix\AnimalChessFelix\Image\Player\leopard.png"), 20 + (j * 60), 20 + (i * 60), 61, 61);
                    }
                    if (board[i, j] == 'G')
                    {
                        g.DrawImage(Image.FromFile(@"C:\Users\hp\Desktop\AnimalChessFelix\AnimalChessFelix\Image\Player\dog.png"), 20 + (j * 60), 20 + (i * 60), 61, 61);
                    }
                    if (board[i, j] == 'R')
                    {
                        g.DrawImage(Image.FromFile(@"C:\Users\hp\Desktop\AnimalChessFelix\AnimalChessFelix\Image\Player\rat.png"), 20 + (j * 60), 20 + (i * 60), 61, 61);
                    }
                    if (board[i, j] == 'L')
                    {
                        g.DrawImage(Image.FromFile(@"C:\Users\hp\Desktop\AnimalChessFelix\AnimalChessFelix\Image\Player\lion.png"), 20 + (j * 60), 20 + (i * 60), 61, 61);
                    }
                    if (board[i, j] == 'e')
                    {
                        g.DrawImage(Image.FromFile(@"C:\Users\hp\Desktop\AnimalChessFelix\AnimalChessFelix\Image\Enemy\elephant.png"), 20 + (j * 60), 20 + (i * 60), 61, 61);
                    }
                    if (board[i, j] == 'i')
                    {
                        g.DrawImage(Image.FromFile(@"C:\Users\hp\Desktop\AnimalChessFelix\AnimalChessFelix\Image\Enemy\tiger.png"), 20 + (j * 60), 20 + (i * 60), 61, 61);
                    }
                    if (board[i, j] == 'c')
                    {
                        g.DrawImage(Image.FromFile(@"C:\Users\hp\Desktop\AnimalChessFelix\AnimalChessFelix\Image\Enemy\cat.png"), 20 + (j * 60), 20 + (i * 60), 61, 61);
                    }
                    if (board[i, j] == 'w')
                    {
                        g.DrawImage(Image.FromFile(@"C:\Users\hp\Desktop\AnimalChessFelix\AnimalChessFelix\Image\Enemy\wolf.png"), 20 + (j * 60), 20 + (i * 60), 61, 61);
                    }
                    if (board[i, j] == 'o')
                    {
                        g.DrawImage(Image.FromFile(@"C:\Users\hp\Desktop\AnimalChessFelix\AnimalChessFelix\Image\Enemy\leopard.png"), 20 + (j * 60), 20 + (i * 60), 61, 61);
                    }
                    if (board[i, j] == 'g')
                    {
                        g.DrawImage(Image.FromFile(@"C:\Users\hp\Desktop\AnimalChessFelix\AnimalChessFelix\Image\Enemy\dog.png"), 20 + (j * 60), 20 + (i * 60), 61, 61);
                    }
                    if (board[i, j] == 'r')
                    {
                        g.DrawImage(Image.FromFile(@"C:\Users\hp\Desktop\AnimalChessFelix\AnimalChessFelix\Image\Enemy\rat.png"), 20 + (j * 60), 20 + (i * 60), 61, 61);
                    }
                    if (board[i, j] == 'l')
                    {
                        g.DrawImage(Image.FromFile(@"C:\Users\hp\Desktop\AnimalChessFelix\AnimalChessFelix\Image\Enemy\lion.png"), 20 + (j * 60), 20 + (i * 60), 61, 61);
                    }                    
                    if (board[i, j] == 'D')
                    {
                        g.DrawImage(Image.FromFile(@"C:\Users\hp\Desktop\AnimalChessFelix\AnimalChessFelix\Image\denPlayer.png"), 20 + (j * 60), 20 + (i * 60), 61, 61);
                    }
                    if (board[i, j] == 'd')
                    {
                        g.DrawImage(Image.FromFile(@"C:\Users\hp\Desktop\AnimalChessFelix\AnimalChessFelix\Image\denEnemy.png"), 20 + (j * 60), 20 + (i * 60), 61, 61);
                    }
                    if (board[i, j] == 't' || board[i, j] == 'T')
                    {
                        g.DrawImage(Image.FromFile(@"C:\Users\hp\Desktop\AnimalChessFelix\AnimalChessFelix\Image\traps.png"), 20 + (j * 60), 20 + (i * 60), 61, 61);
                    }
                    if (board[i, j] == '-')
                    {
                        g.FillRectangle(new SolidBrush(Color.LightBlue), 20 + (j * 60), 20 + (i * 60), 61, 61);
                    }
                    if (board[i, j] == '.')
                    {
                        g.FillRectangle(new SolidBrush(Color.Green), 20 + (j * 60), 20 + (i * 60), 61, 61);
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
            ModeGame(modePlay);
        }
        private bool randomarah(int x,int y)
        {
            int move= new Random().Next(4);
            if (move==0)
            {
                y -= 1;
            }
            else if (move==1)
            {
                x += 1;
            }
            else if (move==2)
            {
                y += 1;
            }
            else if (move==3)
            {
                x -= 1;
            }
            if (x < 0 || x > widthBoard - 1 && y < 0 || y > heightBoard - 1)
            {
                return false;
            }
            else {
                return true;
            }
        }
        int xmusuh, ymusuh;
        char cmusuh;
        private void ModeGame(String mode)
        {
            if (mode.Equals("Easy"))
            {
                int random = new Random().Next(8);
                if (random==0)
                {
                    for (int i = 0; i < heightBoard; i++)
                    {
                        for (int j = 0; j < widthBoard; j++)
                        {
                            if (board[i, j] == 'r')
                            {
                                cmusuh = 'r';
                                ymusuh = i;
                                xmusuh = j;
                            }
                        }
                    }
                    int xm=0, ym=0;
                    int move = new Random().Next(4);
                    if (move == 0)
                    {
                        //ym -= 1;
                        ym = ymusuh - 1;
                    }
                    else if (move == 1)
                    {
                        //xm += 1;
                        xm = xmusuh + 1;
                    }
                    else if (move == 2)
                    {
                        //ym += 1;
                        ym = ymusuh + 1;
                    }
                    else if (move == 3)
                    {
                        //xm -= 1;
                        xm = xmusuh - 1;
                    }
                    board[ym, xm] = cmusuh;
                    board[ymusuh, xmusuh] = '.';
                    //MessageBox.Show(cmusuh+"");
                    //MessageBox.Show(ymusuh+"");
                    //MessageBox.Show(xmusuh + "");

                    //do
                    //{
                    //    MessageBox.Show("false");
                    //} while (randomarah(xmusuh, ymusuh));
                    //int xm, ym;
                    //do
                    //{
                    //    xm = xmusuh;
                    //    ym = ymusuh;
                    //    board[ym, xm] = cmusuh;
                    //    board[ymusuh, xmusuh] = '.';
                    //    //MessageBox.Show(xm+""); MessageBox.Show(ym + "");
                    //} while (randomarah(xmusuh, ymusuh));

                }
                else if (random==1)
                {
                    for (int i = 0; i < heightBoard; i++)
                    {
                        for (int j = 0; j < widthBoard; j++)
                        {
                            if (board[i, j] == 'l')
                            {
                                cmusuh = 'l';
                                ymusuh = i;
                                xmusuh = j;
                            }
                        }
                    }
                    int xm = 0, ym = 0;
                    int move = new Random().Next(4);
                    if (move == 0)
                    {
                        //ym -= 1;
                        ym = ymusuh - 1;
                    }
                    else if (move == 1)
                    {
                        //xm += 1;
                        xm = xmusuh + 1;
                    }
                    else if (move == 2)
                    {
                        //ym += 1;
                        ym = ymusuh + 1;
                    }
                    else if (move == 3)
                    {
                        //xm -= 1;
                        xm = xmusuh - 1;
                    }
                    board[ym, xm] = cmusuh;
                    board[ymusuh, xmusuh] = '.';
                }
                else if (random==2)
                {
                    for (int i = 0; i < heightBoard; i++)
                    {
                        for (int j = 0; j < widthBoard; j++)
                        {
                            if (board[i, j] == 'g')
                            {
                                cmusuh = 'g';
                                ymusuh = i;
                                xmusuh = j;
                            }
                        }
                    }
                    int xm = 0, ym = 0;
                    int move = new Random().Next(4);
                    if (move == 0)
                    {
                        //ym -= 1;
                        ym = ymusuh - 1;
                    }
                    else if (move == 1)
                    {
                        //xm += 1;
                        xm = xmusuh + 1;
                    }
                    else if (move == 2)
                    {
                        //ym += 1;
                        ym = ymusuh + 1;
                    }
                    else if (move == 3)
                    {
                        //xm -= 1;
                        xm = xmusuh - 1;
                    }
                    board[ym, xm] = cmusuh;
                    board[ymusuh, xmusuh] = '.';
                }
                else if (random == 3)
                {
                    for (int i = 0; i < heightBoard; i++)
                    {
                        for (int j = 0; j < widthBoard; j++)
                        {
                            if (board[i, j] == 'o')
                            {
                                cmusuh = 'o';
                                ymusuh = i;
                                xmusuh = j;
                            }
                        }
                    }
                    int xm = 0, ym = 0;
                    int move = new Random().Next(4);
                    if (move == 0)
                    {
                        //ym -= 1;
                        ym = ymusuh - 1;
                    }
                    else if (move == 1)
                    {
                        //xm += 1;
                        xm = xmusuh + 1;
                    }
                    else if (move == 2)
                    {
                        //ym += 1;
                        ym = ymusuh + 1;
                    }
                    else if (move == 3)
                    {
                        //xm -= 1;
                        xm = xmusuh - 1;
                    }
                    board[ym, xm] = cmusuh;
                    board[ymusuh, xmusuh] = '.';
                }
                else if (random == 4)
                {
                    for (int i = 0; i < heightBoard; i++)
                    {
                        for (int j = 0; j < widthBoard; j++)
                        {
                            if (board[i, j] == 'w')
                            {
                                cmusuh = 'w';
                                ymusuh = i;
                                xmusuh = j;
                            }
                        }
                    }
                    int xm = 0, ym = 0;
                    int move = new Random().Next(4);
                    if (move == 0)
                    {
                        //ym -= 1;
                        ym = ymusuh - 1;
                    }
                    else if (move == 1)
                    {
                        //xm += 1;
                        xm = xmusuh + 1;
                    }
                    else if (move == 2)
                    {
                        //ym += 1;
                        ym = ymusuh + 1;
                    }
                    else if (move == 3)
                    {
                        //xm -= 1;
                        xm = xmusuh - 1;
                    }
                    board[ym, xm] = cmusuh;
                    board[ymusuh, xmusuh] = '.';
                }
                else if (random == 5)
                {
                    for (int i = 0; i < heightBoard; i++)
                    {
                        for (int j = 0; j < widthBoard; j++)
                        {
                            if (board[i, j] == 'w')
                            {
                                cmusuh = 'w';
                                ymusuh = i;
                                xmusuh = j;
                            }
                        }
                    }
                    int xm = 0, ym = 0;
                    int move = new Random().Next(4);
                    if (move == 0)
                    {
                        //ym -= 1;
                        ym = ymusuh - 1;
                    }
                    else if (move == 1)
                    {
                        //xm += 1;
                        xm = xmusuh + 1;
                    }
                    else if (move == 2)
                    {
                        //ym += 1;
                        ym = ymusuh + 1;
                    }
                    else if (move == 3)
                    {
                        //xm -= 1;
                        xm = xmusuh - 1;
                    }
                    board[ym, xm] = cmusuh;
                    board[ymusuh, xmusuh] = '.';
                }
                else if (random == 6)
                {
                    for (int i = 0; i < heightBoard; i++)
                    {
                        for (int j = 0; j < widthBoard; j++)
                        {
                            if (board[i, j] == 'c')
                            {
                                cmusuh = 'c';
                                ymusuh = i;
                                xmusuh = j;
                            }
                        }
                    }
                    int xm = 0, ym = 0;
                    int move = new Random().Next(4);
                    if (move == 0)
                    {
                        //ym -= 1;
                        ym = ymusuh - 1;
                    }
                    else if (move == 1)
                    {
                        //xm += 1;
                        xm = xmusuh + 1;
                    }
                    else if (move == 2)
                    {
                        //ym += 1;
                        ym = ymusuh + 1;
                    }
                    else if (move == 3)
                    {
                        //xm -= 1;
                        xm = xmusuh - 1;
                    }
                    board[ym, xm] = cmusuh;
                    board[ymusuh, xmusuh] = '.';
                }
                else if (random == 7)
                {
                    for (int i = 0; i < heightBoard; i++)
                    {
                        for (int j = 0; j < widthBoard; j++)
                        {
                            if (board[i, j] == 'i')
                            {
                                cmusuh = 'i';
                                ymusuh = i;
                                xmusuh = j;
                            }
                        }
                    }
                    int xm = 0, ym = 0;
                    int move = new Random().Next(4);
                    if (move == 0)
                    {
                        //ym -= 1;
                        ym = ymusuh - 1;
                    }
                    else if (move == 1)
                    {
                        //xm += 1;
                        xm = xmusuh + 1;
                    }
                    else if (move == 2)
                    {
                        //ym += 1;
                        ym = ymusuh + 1;
                    }
                    else if (move == 3)
                    {
                        //xm -= 1;
                        xm = xmusuh - 1;
                    }
                    board[ym, xm] = cmusuh;
                    board[ymusuh, xmusuh] = '.';
                }
                else if (random == 8)
                {
                    for (int i = 0; i < heightBoard; i++)
                    {
                        for (int j = 0; j < widthBoard; j++)
                        {
                            if (board[i, j] == 'e')
                            {
                                cmusuh = 'e';
                                ymusuh = i;
                                xmusuh = j;
                            }
                        }
                    }
                    int xm = 0, ym = 0;
                    int move = new Random().Next(4);
                    if (move == 0)
                    {
                        //ym -= 1;
                        ym = ymusuh - 1;
                    }
                    else if (move == 1)
                    {
                        //xm += 1;
                        xm = xmusuh + 1;
                    }
                    else if (move == 2)
                    {
                        //ym += 1;
                        ym = ymusuh + 1;
                    }
                    else if (move == 3)
                    {
                        //xm -= 1;
                        xm = xmusuh - 1;
                    }
                    board[ym, xm] = cmusuh;
                    board[ymusuh, xmusuh] = '.';
                }
            }
            this.Invalidate();
        }

        private bool cekClick(char c,int x,int y)
        {
            if (c != '.' && c != '-' && c != 'd' && c != 'D' && c != 't' && c != 'T'&& c != 'l' && c != 'i' && c != 'g' 
                && c != 'c' && c != 'r' && c != 'o' && c != 'w' && c != 'e')
            {
                return true;
            }
            return false;
        } 

        private bool cekMove(char c,int xp,int yp,int xn, int yn)
        {
            if (c == 'R')
            {
                if (yn - yp == -1 && xn - xp == 0 || yn - yp == 0 && xn - xp == 1 || yn - yp == 1 && xn - xp == 0 || yn - yp == 0 && xn - xp == -1)
                {
                    if (board[yn,xn]=='.'|| board[yn, xn] == '-')
                    {
                        return true;
                    }
                }
            }
            else if (c=='C'||c=='W'||c=='O'||c=='G'||c=='E')
            {
                if (board[yn, xn] == '.')
                {
                    return true;
                }
            }
            else if (c == 'I' || c == 'L')
            {
                if (xp == 1 && yp == 2 || xp == 2 && yp == 2 || xp == 4 && yp == 2 || xp == 5 && yp == 2)
                {
                    if (xn == 1 && yn == 6 || xn == 2 && yn == 6 || xn == 4 && yn == 6 || xn == 5 && yn == 6)
                    {
                        return true;
                    }
                }
                else if (xp == 1 && yp == 6 || xp == 2 && yp == 6 || xp == 4 && yp == 6 || xp == 5 && yp == 6)
                {
                    if (xn == 1 && yn == 2 || xn == 2 && yn == 2 || xn == 4 && yn == 2 || xn == 5 && yn == 2)
                    {
                        return true;
                    }
                }
                else if (xp == 0 && yp == 3 || xp == 0 && yp == 4 || xp == 0 && yp == 5 || xp == 6 && yp == 3 || xp == 6 && yp == 4 || xp == 6 && yp == 5)
                {
                    if (xn == 3 && yn == 3 || xn == 3 && yn == 4 || xn == 3 && yn == 5)
                    {
                        return true;
                    }
                }
                else if (xp == 3 && yp == 3 || xp == 3 && yp == 4 || xp == 3 && yp == 5)
                {
                    if (xn == 0 && yn == 3 || xn == 0 && yn == 4 || xn == 0 && yn == 5 || xn == 6 && yn == 3 || xn == 6 && yn == 4 || xn == 6 && yn == 5)
                    {
                        return true;
                    }
                }
                else
                {
                    if (yn - yp == -1 && xn - xp == 0 || yn - yp == 0 && xn - xp == 1 || yn - yp == 1 && xn - xp == 0 || yn - yp == 0 && xn - xp == -1)
                    {
                        if (board[yn,xn]=='.')
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            int arry = (e.Y - 20) / 61;
            int arrx = (e.X - 20) / 61;
            //tiger (I)
            //MessageBox.Show(arry + "");//8
            //MessageBox.Show(arrx + "");//0

            if (arrx >= 0 && arrx < widthBoard && arry >= 0 && arry < heightBoard)
            {
                if (numofclick == 0)
                {
                    if (!cekClick(board[arry, arrx], arrx, arry))
                    {
                        MessageBox.Show("Choose Player Character");
                    }
                    else
                    {
                        numofclick = 1;
                        clickedx = arrx;
                        label3.Text = clickedx.ToString();
                        clickedy = arry;
                        label4.Text = clickedy.ToString();
                    }
                }
                else
                {
                    if (!cekMove(board[clickedy, clickedx] ,clickedx, clickedy, arrx, arry))
                    {
                        MessageBox.Show("Invalid Move");
                    }
                    else
                    {
                        //if (RuleCharacter(board[clickedy, clickedx], clickedx, clickedy, arrx, arry))
                        //{
                            foreach (var item in dataHewan)
                            {
                                String[] sp = item.ToString().Split('-');
                                if (sp[0].Equals(board[clickedy, clickedx].ToString()))
                                {
                                    sp[1] = arry.ToString();
                                    sp[2] = arrx.ToString();
                                    board[arry, arrx] = board[clickedy, clickedx];
                                    if ((clickedy >= 3 && clickedy <= 5) && (clickedx == 1 || clickedx == 2 || clickedx == 4 || clickedx == 5))
                                    {
                                        board[clickedy, clickedx] = '-';
                                    }
                                    else if ((clickedy == 0 && (clickedx == 2 || clickedx == 4)) || (clickedy == 1 && clickedx == 3))
                                    {
                                        board[clickedy, clickedx] = 't';
                                    }
                                    else if ((clickedy == 8 && (clickedx == 2 || clickedx == 4)) || (clickedy == 7 && clickedx == 3))
                                    {
                                        board[clickedy, clickedx] = 'T';
                                    }
                                    else if (clickedy == 0 && clickedx == 3)
                                    {
                                        board[clickedy, clickedx] = 'd';
                                    }
                                    else if (clickedy == 8 && clickedx == 3)
                                    {
                                        board[clickedy, clickedx] = 'D';
                                    }
                                    else
                                    {
                                        board[clickedy, clickedx] = '.';
                                    }
                                }
                            }
                        ModeGame(modePlay);
                        //}
                    }
                    refreshlayar();
                }
            }
            this.Invalidate();            
        }

    }
}
