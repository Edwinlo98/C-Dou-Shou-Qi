using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnimalChessFelix
{
    public partial class FormEasy : Form
    {
        CNode root;
        int widthBoard = 7, heightBoard = 9;
        int[,] pemain = new int[9, 7];
        string[,] hewan = new string[9, 7];
        char[,] board;
        int giliran;
        int numofclick;
        int clickedy, clickedx;
        public string modePlay;
        ArrayList dataHewan = new ArrayList();
        //int[] arrbobot = new int[8];
        ArrayList arrbobot = new ArrayList();
        ArrayList arrchance = new ArrayList();

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
            board = new char[9, 7]
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

            for (int i = 0; i < heightBoard; i++)
            {
                for (int j = 0; j < widthBoard; j++)
                {
                    if (board[i, j] != '.' && board[i, j] != '-' && board[i, j] != 'd' && board[i, j] != 'D' && board[i, j] != 't' && board[i, j] != 'T')
                    {
                        dataHewan.Add(board[i, j] + "-" + i + "-" + j);
                    }
                }
            }

            cekConditionEnemy();

            //foreach (var item in dataHewan)
            //{
            //    MessageBox.Show(item+"");
            //}
            root = new CNode(0, giliran, hewan);

            refreshLayarPlayer();
        }

        public void refreshLayarPlayer()
        {
            if (giliran == 1) lblgiliran.Text = "Giliran : Player 1";
            else lblgiliran.Text = "Giliran : AI (" + modePlay + ")";
            numofclick = 0;
            clickedx = 0;
            label3.Text = clickedx.ToString();
            clickedy = 0;
            label4.Text = clickedy.ToString();
            this.Invalidate();
        }

        public FormEasy()
        {
            InitializeComponent();
            var basePath = System.AppDomain.CurrentDomain.BaseDirectory;
            SoundPlayer player = new SoundPlayer();
            player.SoundLocation = Path.Combine(basePath, @"C:\Users\hp\Desktop\AnimalChessFelix\AnimalChessFelix\bin\Debug\Sound\Warspear Music - Warlords Of Draenor.wav");
            player.Load();
            player.Play();
            goPlay();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = (Graphics)e.Graphics;
            for (int i = 0; i < heightBoard; i++)
            {
                for (int j = 0; j < widthBoard; j++)
                {
                    if (board[i, j] == 'E')
                    {
                        g.DrawImage(Image.FromFile("./Image/elephant.png"), 20 + (j * 60), 20 + (i * 60), 61, 61);
                    }
                    if (board[i, j] == 'I')
                    {
                        g.DrawImage(Image.FromFile("./Image/tiger.png"), 20 + (j * 60), 20 + (i * 60), 61, 61);
                    }
                    if (board[i, j] == 'C')
                    {
                        g.DrawImage(Image.FromFile("./Image/cat.png"), 20 + (j * 60), 20 + (i * 60), 61, 61);
                    }
                    if (board[i, j] == 'W')
                    {
                        g.DrawImage(Image.FromFile("./Image/wolf.png"), 20 + (j * 60), 20 + (i * 60), 61, 61);
                    }
                    if (board[i, j] == 'O')
                    {
                        g.DrawImage(Image.FromFile("./Image/leopard.jpg"), 20 + (j * 60), 20 + (i * 60), 61, 61);
                    }
                    if (board[i, j] == 'G')
                    {
                        g.DrawImage(Image.FromFile("./Image/dog.png"), 20 + (j * 60), 20 + (i * 60), 61, 61);
                    }
                    if (board[i, j] == 'R')
                    {
                        g.DrawImage(Image.FromFile("./Image/rat.png"), 20 + (j * 60), 20 + (i * 60), 61, 61);
                    }
                    if (board[i, j] == 'L')
                    {
                        g.DrawImage(Image.FromFile("./Image/lion.png"), 20 + (j * 60), 20 + (i * 60), 61, 61);
                    }
                    if (board[i, j] == 'e')
                    {
                        g.DrawImage(Image.FromFile("./Image/elephant.png"), 20 + (j * 60), 20 + (i * 60), 61, 61);
                    }
                    if (board[i, j] == 'i')
                    {
                        g.DrawImage(Image.FromFile("./Image/tiger.png"), 20 + (j * 60), 20 + (i * 60), 61, 61);
                    }
                    if (board[i, j] == 'c')
                    {
                        g.DrawImage(Image.FromFile("./Image/cat.png"), 20 + (j * 60), 20 + (i * 60), 61, 61);
                    }
                    if (board[i, j] == 'w')
                    {
                        g.DrawImage(Image.FromFile("./Image/wolf.png"), 20 + (j * 60), 20 + (i * 60), 61, 61);
                    }
                    if (board[i, j] == 'o')
                    {
                        g.DrawImage(Image.FromFile("./Image/leopard.jpg"), 20 + (j * 60), 20 + (i * 60), 61, 61);
                    }
                    if (board[i, j] == 'g')
                    {
                        g.DrawImage(Image.FromFile("./Image/dog.png"), 20 + (j * 60), 20 + (i * 60), 61, 61);
                    }
                    if (board[i, j] == 'r')
                    {
                        g.DrawImage(Image.FromFile("./Image/rat.png"), 20 + (j * 60), 20 + (i * 60), 61, 61);
                    }
                    if (board[i, j] == 'l')
                    {
                        g.DrawImage(Image.FromFile("./Image/lion.png"), 20 + (j * 60), 20 + (i * 60), 61, 61);
                    }
                    if (board[i, j] == 'D')
                    {
                        g.DrawImage(Image.FromFile("./Image/den.png"), 20 + (j * 60), 20 + (i * 60), 61, 61);
                    }
                    if (board[i, j] == 'd')
                    {
                        g.DrawImage(Image.FromFile("./Image/den.png"), 20 + (j * 60), 20 + (i * 60), 61, 61);
                    }
                    if (board[i, j] == 't' || board[i, j] == 'T')
                    {
                        g.DrawImage(Image.FromFile("./Image/traps.png"), 20 + (j * 60), 20 + (i * 60), 61, 61);
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

        public int bobot(char c)
        {
            if (c == 'r' || c == 'R') return 1;
            else if (c == 'c' || c == 'C') return 2;
            else if (c == 'w' || c == 'W') return 3;
            else if (c == 'g' || c == 'G') return 4;
            else if (c == 'o' || c == 'O') return 5;
            else if (c == 'i' || c == 'I') return 6;
            else if (c == 'l' || c == 'L') return 7;
            else if (c == 'e' || c == 'E') return 8;
            else return 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //ModeGame(modePlay);
        }

        private void clearAIBoard(int x, int y)
        {
            if ((y >= 3 && y <= 5) && (x == 1 || x == 2 || x == 4 || x == 5))
            {
                board[y, x] = '-';
            }
            else if ((y == 0 && (x == 2 || x == 4)) || (y == 1 && x == 3))
            {
                board[y, x] = 't';
            }
            else if ((y == 8 && (x == 2 || x == 4)) || (y == 7 && x == 3))
            {
                board[y, x] = 'T';
            }
            else if (y == 0 && x == 3)
            {
                board[y, x] = 'd';
            }
            else if (y == 8 && x == 3)
            {
                board[y, x] = 'D';
            }
            else
            {
                board[y, x] = '.';
            }
        }

        int chan = 0;
        private String EasyEnemyMove(char c, int x, int y)
        {
            arrchance.Clear();
            if (c == 'r')
            {
                if (x < 1 && y < 1)
                {
                    if (board[y, x + 1] == '.' || board[y, x + 1] == '-' || board[y, x + 1] == 'T' || board[y, x + 1] == 'D' || board[y, x + 1] == 't' || board[y, x + 1] == 'E')
                    {
                        arrchance.Add(1);
                    }
                    if (board[y + 1, x] == '.' || board[y + 1, x] == '-' || board[y + 1, x] == 'T' || board[y + 1, x] == 'D' || board[y + 1, x] == 't' || board[y + 1, x] == 'E')
                    {
                        arrchance.Add(2);
                    }
                }
                else if (x == widthBoard - 1 && y < 1)
                {
                    if (board[y, x - 1] == '.' || board[y, x - 1] == '-' || board[y, x - 1] == 'T' || board[y, x - 1] == 'D' || board[y, x - 1] == 't' || board[y, x - 1] == 'E')
                    {
                        arrchance.Add(3);
                    }
                    if (board[y + 1, x] == '.' || board[y + 1, x] == '-' || board[y + 1, x] == 'T' || board[y + 1, x] == 'D' || board[y + 1, x] == 't' || board[y + 1, x] == 'E')
                    {
                        arrchance.Add(2);
                    }
                }
                else if (x == widthBoard - 1 && y == heightBoard - 1)
                {
                    if (board[y, x - 1] == '.' || board[y, x - 1] == '-' || board[y, x - 1] == 'T' || board[y, x - 1] == 'D' || board[y, x - 1] == 't' || board[y, x - 1] == 'E')
                    {
                        arrchance.Add(3);
                    }
                    if (board[y - 1, x] == '.' || board[y - 1, x] == '-' || board[y - 1, x] == 'T' || board[y - 1, x] == 'D' || board[y - 1, x] == 't' || board[y - 1, x] == 'E')
                    {
                        arrchance.Add(0);
                    }
                }
                else if (x < 1 && y == heightBoard - 1)
                {
                    if (board[y, x + 1] == '.' || board[y, x + 1] == '-' || board[y, x + 1] == 'T' || board[y, x + 1] == 'D' || board[y, x + 1] == 't' || board[y, x + 1] == 'E')
                    {
                        arrchance.Add(1);
                    }
                    if (board[y - 1, x] == '.' || board[y - 1, x] == '-' || board[y - 1, x] == 'T' || board[y - 1, x] == 'D' || board[y - 1, x] == 't' || board[y - 1, x] == 'E')
                    {
                        arrchance.Add(0);
                    }
                }
                else if (x > 0 && x < widthBoard - 1 && y < 1)
                {
                    if (board[y, x + 1] == '.' || board[y, x + 1] == '-' || board[y, x + 1] == 'T' || board[y, x + 1] == 'D' || board[y, x + 1] == 't' || board[y, x + 1] == 'E')
                    {
                        arrchance.Add(1);
                    }
                    if (board[y + 1, x] == '.' || board[y + 1, x] == '-' || board[y + 1, x] == 'T' || board[y + 1, x] == 'D' || board[y + 1, x] == 't' || board[y + 1, x] == 'E')
                    {
                        arrchance.Add(2);
                    }
                    if (board[y, x - 1] == '.' || board[y, x - 1] == '-' || board[y, x - 1] == 'T' || board[y, x - 1] == 'D' || board[y, x - 1] == 't' || board[y, x - 1] == 'E')
                    {
                        arrchance.Add(3);
                    }
                }
                else if (y > 0 && y < heightBoard - 1 && x == widthBoard - 1)
                {
                    if (board[y - 1, x] == '.' || board[y - 1, x] == '-' || board[y - 1, x] == 'T' || board[y - 1, x] == 'D' || board[y - 1, x] == 't' || board[y - 1, x] == 'E')
                    {
                        arrchance.Add(0);
                    }
                    if (board[y + 1, x] == '.' || board[y + 1, x] == '-' || board[y + 1, x] == 'T' || board[y + 1, x] == 'D' || board[y + 1, x] == 't' || board[y + 1, x] == 'E')
                    {
                        arrchance.Add(2);
                    }
                    if (board[y, x - 1] == '.' || board[y, x - 1] == '-' || board[y, x - 1] == 'T' || board[y, x - 1] == 'D' || board[y, x - 1] == 't' || board[y, x - 1] == 'E')
                    {
                        arrchance.Add(3);
                    }
                }
                else if (x > 0 && x < widthBoard - 1 && y == heightBoard - 1)
                {
                    if (board[y - 1, x] == '.' || board[y - 1, x] == '-' || board[y - 1, x] == 'T' || board[y - 1, x] == 'D' || board[y - 1, x] == 't' || board[y - 1, x] == 'E')
                    {
                        arrchance.Add(0);
                    }
                    if (board[y, x + 1] == '.' || board[y, x + 1] == '-' || board[y, x + 1] == 'T' || board[y, x + 1] == 'D' || board[y, x + 1] == 't' || board[y, x + 1] == 'E')
                    {
                        arrchance.Add(1);
                    }
                    if (board[y, x - 1] == '.' || board[y, x - 1] == '-' || board[y, x - 1] == 'T' || board[y, x - 1] == 'D' || board[y, x - 1] == 't' || board[y, x - 1] == 'E')
                    {
                        arrchance.Add(3);
                    }
                }
                else if (y > 0 && y < heightBoard - 1 && x < 1)
                {
                    if (board[y - 1, x] == '.' || board[y - 1, x] == '-' || board[y - 1, x] == 'T' || board[y - 1, x] == 'D' || board[y - 1, x] == 't' || board[y - 1, x] == 'E')
                    {
                        arrchance.Add(0);
                    }
                    if (board[y, x + 1] == '.' || board[y, x + 1] == '-' || board[y, x + 1] == 'T' || board[y, x + 1] == 'D' || board[y, x + 1] == 't' || board[y, x + 1] == 'E')
                    {
                        arrchance.Add(1);
                    }
                    if (board[y + 1, x] == '.' || board[y + 1, x] == '-' || board[y + 1, x] == 'T' || board[y + 1, x] == 'D' || board[y + 1, x] == 't' || board[y + 1, x] == 'E')
                    {
                        arrchance.Add(2);
                    }
                }
                else if (x > 0 && x < widthBoard - 1 && y > 0 && y < heightBoard - 1)
                {
                    if (board[y - 1, x] == '.' || board[y - 1, x] == '-' || board[y - 1, x] == 'T' || board[y - 1, x] == 'D' || board[y - 1, x] == 't' || board[y - 1, x] == 'E')
                    {
                        arrchance.Add(0);
                    }
                    if (board[y, x + 1] == '.' || board[y, x + 1] == '-' || board[y, x + 1] == 'T' || board[y, x + 1] == 'D' || board[y, x + 1] == 't' || board[y, x + 1] == 'E')
                    {
                        arrchance.Add(1);
                    }
                    if (board[y + 1, x] == '.' || board[y + 1, x] == '-' || board[y + 1, x] == 'T' || board[y + 1, x] == 'D' || board[y + 1, x] == 't' || board[y + 1, x] == 'E')
                    {
                        arrchance.Add(2);
                    }
                    if (board[y, x - 1] == '.' || board[y, x - 1] == '-' || board[y, x - 1] == 'T' || board[y, x - 1] == 'D' || board[y, x - 1] == 't' || board[y, x - 1] == 'E')
                    {
                        arrchance.Add(3);
                    }
                }
            }
            else if (c == 'i' || c == 'l')
            {
                if (x < 1 && y < 1)
                {
                    if (board[y, x + 1] == '.' || board[y, x + 1] == '-' || board[y, x + 1] == 'T' || board[y, x + 1] == 'D' || board[y, x + 1] == 't')
                    {
                        arrchance.Add(1);
                    }
                    if (board[y + 1, x] == '.' || board[y + 1, x] == '-' || board[y + 1, x] == 'T' || board[y + 1, x] == 'D' || board[y + 1, x] == 't')
                    {
                        arrchance.Add(2);
                    }
                }
                else if (x == widthBoard - 1 && y < 1)
                {
                    if (board[y, x - 1] == '.' || board[y, x - 1] == '-' || board[y, x - 1] == 'T' || board[y, x - 1] == 'D' || board[y, x - 1] == 't')
                    {
                        arrchance.Add(3);
                    }
                    if (board[y + 1, x] == '.' || board[y + 1, x] == '-' || board[y + 1, x] == 'T' || board[y + 1, x] == 'D' || board[y + 1, x] == 't')
                    {
                        arrchance.Add(2);
                    }
                }
                else if (x == widthBoard - 1 && y == heightBoard - 1)
                {
                    if (board[y, x - 1] == '.' || board[y, x - 1] == '-' || board[y, x - 1] == 'T' || board[y, x - 1] == 'D' || board[y, x - 1] == 't')
                    {
                        arrchance.Add(3);
                    }
                    if (board[y - 1, x] == '.' || board[y - 1, x] == '-' || board[y - 1, x] == 'T' || board[y - 1, x] == 'D' || board[y - 1, x] == 't')
                    {
                        arrchance.Add(0);
                    }
                }
                else if (x < 1 && y == heightBoard - 1)
                {
                    if (board[y, x + 1] == '.' || board[y, x + 1] == '-' || board[y, x + 1] == 'T' || board[y, x + 1] == 'D' || board[y, x + 1] == 't')
                    {
                        arrchance.Add(1);
                    }
                    if (board[y - 1, x] == '.' || board[y - 1, x] == '-' || board[y - 1, x] == 'T' || board[y - 1, x] == 'D' || board[y - 1, x] == 't')
                    {
                        arrchance.Add(0);
                    }
                }
                else if (x > 0 && x < widthBoard - 1 && y < 1)
                {
                    if (board[y, x + 1] == '.' || board[y, x + 1] == '-' || board[y, x + 1] == 'T' || board[y, x + 1] == 'D' || board[y, x + 1] == 't')
                    {
                        arrchance.Add(1);
                    }
                    if (board[y + 1, x] == '.' || board[y + 1, x] == '-' || board[y + 1, x] == 'T' || board[y + 1, x] == 'D' || board[y + 1, x] == 't')
                    {
                        arrchance.Add(2);
                    }
                    if (board[y, x - 1] == '.' || board[y, x - 1] == '-' || board[y, x - 1] == 'T' || board[y, x - 1] == 'D' || board[y, x - 1] == 't')
                    {
                        arrchance.Add(3);
                    }
                }
                else if (y > 0 && y < heightBoard - 1 && x == widthBoard - 1)
                {
                    if (board[y - 1, x] == '.' || board[y - 1, x] == '-' || board[y - 1, x] == 'T' || board[y - 1, x] == 'D' || board[y - 1, x] == 't')
                    {
                        arrchance.Add(0);
                    }
                    if (board[y + 1, x] == '.' || board[y + 1, x] == '-' || board[y + 1, x] == 'T' || board[y + 1, x] == 'D' || board[y + 1, x] == 't')
                    {
                        arrchance.Add(2);
                    }
                    if (board[y, x - 1] == '.' || board[y, x - 1] == '-' || board[y, x - 1] == 'T' || board[y, x - 1] == 'D' || board[y, x - 1] == 't')
                    {
                        arrchance.Add(3);
                    }
                }
                else if (x > 0 && x < widthBoard - 1 && y == heightBoard - 1)
                {
                    if (board[y - 1, x] == '.' || board[y - 1, x] == '-' || board[y - 1, x] == 'T' || board[y - 1, x] == 'D' || board[y - 1, x] == 't')
                    {
                        arrchance.Add(0);
                    }
                    if (board[y, x + 1] == '.' || board[y, x + 1] == '-' || board[y, x + 1] == 'T' || board[y, x + 1] == 'D' || board[y, x + 1] == 't')
                    {
                        arrchance.Add(1);
                    }
                    if (board[y, x - 1] == '.' || board[y, x - 1] == '-' || board[y, x - 1] == 'T' || board[y, x - 1] == 'D' || board[y, x - 1] == 't')
                    {
                        arrchance.Add(3);
                    }
                }
                else if (y > 0 && y < heightBoard - 1 && x < 1)
                {
                    if (board[y - 1, x] == '.' || board[y - 1, x] == '-' || board[y - 1, x] == 'T' || board[y - 1, x] == 'D' || board[y - 1, x] == 't')
                    {
                        arrchance.Add(0);
                    }
                    if (board[y, x + 1] == '.' || board[y, x + 1] == '-' || board[y, x + 1] == 'T' || board[y, x + 1] == 'D' || board[y, x + 1] == 't')
                    {
                        arrchance.Add(1);
                    }
                    if (board[y + 1, x] == '.' || board[y + 1, x] == '-' || board[y + 1, x] == 'T' || board[y + 1, x] == 'D' || board[y + 1, x] == 't')
                    {
                        arrchance.Add(2);
                    }
                }
                else if (x > 0 && x < widthBoard - 1 && y > 0 && y < heightBoard - 1)
                {
                    if (board[y - 1, x] == '.' || board[y - 1, x] == '-' || board[y - 1, x] == 'T' || board[y - 1, x] == 'D' || board[y - 1, x] == 't')
                    {
                        arrchance.Add(0);
                    }
                    if (board[y, x + 1] == '.' || board[y, x + 1] == '-' || board[y, x + 1] == 'T' || board[y, x + 1] == 'D' || board[y, x + 1] == 't')
                    {
                        arrchance.Add(1);
                    }
                    if (board[y + 1, x] == '.' || board[y + 1, x] == '-' || board[y + 1, x] == 'T' || board[y + 1, x] == 'D' || board[y + 1, x] == 't')
                    {
                        arrchance.Add(2);
                    }
                    if (board[y, x - 1] == '.' || board[y, x - 1] == '-' || board[y, x - 1] == 'T' || board[y, x - 1] == 'D' || board[y, x - 1] == 't')
                    {
                        arrchance.Add(3);
                    }
                }
            }
            else
            {
                if (x < 1 && y < 1)
                {
                    if (board[y, x + 1] == '.' || board[y, x + 1] == 'T' || board[y, x + 1] == 'D' || board[y, x + 1] == 't')
                    {
                        arrchance.Add(1);
                    }
                    else if (board[y, x + 1] == 'E' || board[y, x + 1] == 'I' || board[y, x + 1] == 'C' || board[y, x + 1] == 'W' || board[y, x + 1] == 'O' || board[y, x + 1] == 'G' || board[y, x + 1] == 'R' || board[y, x + 1] == 'L')
                    {
                        char p = board[y, x + 1];
                        if (c != 'e')
                        {
                            if (bobot(c) > bobot(p))
                            {
                                arrchance.Add(1);
                            }
                        }
                        else
                        {
                            if (bobot(p) > 1)
                            {
                                arrchance.Add(1);
                            }
                        }
                    }
                    if (board[y + 1, x] == '.' || board[y + 1, x] == 'T' || board[y + 1, x] == 'D' || board[y + 1, x] == 't')
                    {
                        arrchance.Add(2);
                    }
                    else if (board[y + 1, x] == 'E' || board[y + 1, x] == 'I' || board[y + 1, x] == 'C' || board[y + 1, x] == 'W' || board[y + 1, x] == 'O' || board[y + 1, x] == 'G' || board[y + 1, x] == 'R' || board[y + 1, x] == 'L')
                    {
                        char p = board[y + 1, x];
                        if (c != 'e')
                        {
                            if (bobot(c) > bobot(p))
                            {
                                arrchance.Add(2);
                            }
                        }
                        else
                        {
                            if (bobot(p) > 1)
                            {
                                arrchance.Add(2);
                            }
                        }
                    }
                }
                else if (x == widthBoard - 1 && y < 1)
                {
                    if (board[y, x - 1] == '.' || board[y, x - 1] == 'T' || board[y, x - 1] == 'D' || board[y, x - 1] == 't')
                    {
                        arrchance.Add(3);
                    }
                    else if (board[y, x - 1] == 'E' || board[y, x - 1] == 'I' || board[y, x - 1] == 'C' || board[y, x - 1] == 'W' || board[y, x - 1] == 'O' || board[y, x - 1] == 'G' || board[y, x - 1] == 'R' || board[y, x - 1] == 'L')
                    {
                        char p = board[y, x - 1];
                        if (c != 'e')
                        {
                            if (bobot(c) > bobot(p))
                            {
                                arrchance.Add(3);
                            }
                        }
                        else
                        {
                            if (bobot(p) > 1)
                            {
                                arrchance.Add(3);
                            }
                        }
                    }
                    if (board[y + 1, x] == '.' || board[y + 1, x] == 'T' || board[y + 1, x] == 'D' || board[y + 1, x] == 't')
                    {
                        arrchance.Add(2);
                    }
                    else if (board[y + 1, x] == 'E' || board[y + 1, x] == 'I' || board[y + 1, x] == 'C' || board[y + 1, x] == 'W' || board[y + 1, x] == 'O' || board[y + 1, x] == 'G' || board[y + 1, x] == 'R' || board[y + 1, x] == 'L')
                    {
                        char p = board[y + 1, x];
                        if (c != 'e')
                        {
                            if (bobot(c) > bobot(p))
                            {
                                arrchance.Add(2);
                            }
                        }
                        else
                        {
                            if (bobot(p) > 1)
                            {
                                arrchance.Add(2);
                            }
                        }
                    }
                }
                else if (x == widthBoard - 1 && y == heightBoard - 1)
                {
                    if (board[y, x - 1] == '.' || board[y, x - 1] == 'T' || board[y, x - 1] == 'D' || board[y, x - 1] == 't')
                    {
                        arrchance.Add(3);
                    }
                    else if (board[y, x - 1] == 'E' || board[y, x - 1] == 'I' || board[y, x - 1] == 'C' || board[y, x - 1] == 'W' || board[y, x - 1] == 'O' || board[y, x - 1] == 'G' || board[y, x - 1] == 'R' || board[y, x - 1] == 'L')
                    {
                        char p = board[y, x - 1];
                        if (c != 'e')
                        {
                            if (bobot(c) > bobot(p))
                            {
                                arrchance.Add(3);
                            }
                        }
                        else
                        {
                            if (bobot(p) > 1)
                            {
                                arrchance.Add(3);
                            }
                        }
                    }
                    if (board[y - 1, x] == '.' || board[y - 1, x] == 'T' || board[y - 1, x] == 'D' || board[y - 1, x] == 't')
                    {
                        arrchance.Add(0);
                    }
                    else if (board[y - 1, x] == 'E' || board[y - 1, x] == 'I' || board[y - 1, x] == 'C' || board[y - 1, x] == 'W' || board[y - 1, x] == 'O' || board[y - 1, x] == 'G' || board[y - 1, x] == 'R' || board[y - 1, x] == 'L')
                    {
                        char p = board[y - 1, x];
                        if (c != 'e')
                        {
                            if (bobot(c) > bobot(p))
                            {
                                arrchance.Add(0);
                            }
                        }
                        else
                        {
                            if (bobot(p) > 1)
                            {
                                arrchance.Add(0);
                            }
                        }
                    }
                }
                else if (x < 1 && y == heightBoard - 1)
                {
                    if (board[y, x + 1] == '.' || board[y, x + 1] == 'T' || board[y, x + 1] == 'D' || board[y, x + 1] == 't')
                    {
                        arrchance.Add(1);
                    }
                    else if (board[y, x + 1] == 'E' || board[y, x + 1] == 'I' || board[y, x + 1] == 'C' || board[y, x + 1] == 'W' || board[y, x + 1] == 'O' || board[y, x + 1] == 'G' || board[y, x + 1] == 'R' || board[y, x + 1] == 'L')
                    {
                        char p = board[y, x + 1];
                        if (c != 'e')
                        {
                            if (bobot(c) > bobot(p))
                            {
                                arrchance.Add(1);
                            }
                        }
                        else
                        {
                            if (bobot(p) > 1)
                            {
                                arrchance.Add(1);
                            }
                        }
                    }
                    if (board[y - 1, x] == '.' || board[y - 1, x] == 'T' || board[y - 1, x] == 'D' || board[y - 1, x] == 't')
                    {
                        arrchance.Add(0);
                    }
                    else if (board[y - 1, x] == 'E' || board[y - 1, x] == 'I' || board[y - 1, x] == 'C' || board[y - 1, x] == 'W' || board[y - 1, x] == 'O' || board[y - 1, x] == 'G' || board[y - 1, x] == 'R' || board[y - 1, x] == 'L')
                    {
                        char p = board[y - 1, x];
                        if (c != 'e')
                        {
                            if (bobot(c) > bobot(p))
                            {
                                arrchance.Add(0);
                            }
                        }
                        else
                        {
                            if (bobot(p) > 1)
                            {
                                arrchance.Add(0);
                            }
                        }
                    }
                }
                else if (x > 0 && x < widthBoard - 1 && y < 1)
                {
                    if (board[y, x + 1] == '.' || board[y, x + 1] == 'T' || board[y, x + 1] == 'D' || board[y, x + 1] == 't')
                    {
                        arrchance.Add(1);
                    }
                    else if (board[y, x + 1] == 'E' || board[y, x + 1] == 'I' || board[y, x + 1] == 'C' || board[y, x + 1] == 'W' || board[y, x + 1] == 'O' || board[y, x + 1] == 'G' || board[y, x + 1] == 'R' || board[y, x + 1] == 'L')
                    {
                        char p = board[y, x + 1];
                        if (c != 'e')
                        {
                            if (bobot(c) > bobot(p))
                            {
                                arrchance.Add(1);
                            }
                        }
                        else
                        {
                            if (bobot(p) > 1)
                            {
                                arrchance.Add(1);
                            }
                        }
                    }
                    if (board[y + 1, x] == '.' || board[y + 1, x] == 'T' || board[y + 1, x] == 'D' || board[y + 1, x] == 't')
                    {
                        arrchance.Add(2);
                    }
                    else if (board[y + 1, x] == 'E' || board[y + 1, x] == 'I' || board[y + 1, x] == 'C' || board[y + 1, x] == 'W' || board[y + 1, x] == 'O' || board[y + 1, x] == 'G' || board[y + 1, x] == 'R' || board[y + 1, x] == 'L')
                    {
                        char p = board[y + 1, x];
                        if (c != 'e')
                        {
                            if (bobot(c) > bobot(p))
                            {
                                arrchance.Add(2);
                            }
                        }
                        else
                        {
                            if (bobot(p) > 1)
                            {
                                arrchance.Add(2);
                            }
                        }
                    }
                    if (board[y, x - 1] == '.' || board[y, x - 1] == 'T' || board[y, x - 1] == 'D' || board[y, x - 1] == 't')
                    {
                        arrchance.Add(3);
                    }
                    else if (board[y, x - 1] == 'E' || board[y, x - 1] == 'I' || board[y, x - 1] == 'C' || board[y, x - 1] == 'W' || board[y, x - 1] == 'O' || board[y, x - 1] == 'G' || board[y, x - 1] == 'R' || board[y, x - 1] == 'L')
                    {
                        char p = board[y, x - 1];
                        if (c != 'e')
                        {
                            if (bobot(c) > bobot(p))
                            {
                                arrchance.Add(3);
                            }
                        }
                        else
                        {
                            if (bobot(p) > 1)
                            {
                                arrchance.Add(3);
                            }
                        }
                    }
                }
                else if (y > 0 && y < heightBoard - 1 && x == widthBoard - 1)
                {
                    if (board[y - 1, x] == '.' || board[y - 1, x] == 'T' || board[y - 1, x] == 'D' || board[y - 1, x] == 't')
                    {
                        arrchance.Add(0);
                    }
                    else if (board[y - 1, x] == 'E' || board[y - 1, x] == 'I' || board[y - 1, x] == 'C' || board[y - 1, x] == 'W' || board[y - 1, x] == 'O' || board[y - 1, x] == 'G' || board[y - 1, x] == 'R' || board[y - 1, x] == 'L')
                    {
                        char p = board[y - 1, x];
                        if (c != 'e')
                        {
                            if (bobot(c) > bobot(p))
                            {
                                arrchance.Add(0);
                            }
                        }
                        else
                        {
                            if (bobot(p) > 1)
                            {
                                arrchance.Add(0);
                            }
                        }
                    }
                    if (board[y + 1, x] == '.' || board[y + 1, x] == 'T' || board[y + 1, x] == 'D' || board[y + 1, x] == 't')
                    {
                        arrchance.Add(2);
                    }
                    else if (board[y + 1, x] == 'E' || board[y + 1, x] == 'I' || board[y + 1, x] == 'C' || board[y + 1, x] == 'W' || board[y + 1, x] == 'O' || board[y + 1, x] == 'G' || board[y + 1, x] == 'R' || board[y + 1, x] == 'L')
                    {
                        char p = board[y + 1, x];
                        if (c != 'e')
                        {
                            if (bobot(c) > bobot(p)) arrchance.Add(2);
                        }
                        else
                        {
                            if (bobot(p) > 1) arrchance.Add(2);
                        }
                    }
                    if (board[y, x - 1] == '.' || board[y, x - 1] == 'T' || board[y, x - 1] == 'D' || board[y, x - 1] == 't')
                    {
                        arrchance.Add(3);
                    }
                    else if (board[y, x - 1] == 'E' || board[y, x - 1] == 'I' || board[y, x - 1] == 'C' || board[y, x - 1] == 'W' || board[y, x - 1] == 'O' || board[y, x - 1] == 'G' || board[y, x - 1] == 'R' || board[y, x - 1] == 'L')
                    {
                        char p = board[y, x - 1];
                        if (c != 'e')
                        {
                            if (bobot(c) > bobot(p))
                            {
                                arrchance.Add(3);
                            }
                        }
                        else
                        {
                            if (bobot(p) > 1)
                            {
                                arrchance.Add(3);
                            }
                        }
                    }
                }
                else if (x > 0 && x < widthBoard - 1 && y == heightBoard - 1)
                {
                    if (board[y - 1, x] == '.' || board[y - 1, x] == 'T' || board[y - 1, x] == 'D' || board[y - 1, x] == 't')
                    {
                        arrchance.Add(0);
                    }
                    else if (board[y - 1, x] == 'E' || board[y - 1, x] == 'I' || board[y - 1, x] == 'C' || board[y - 1, x] == 'W' || board[y - 1, x] == 'O' || board[y - 1, x] == 'G' || board[y - 1, x] == 'R' || board[y - 1, x] == 'L')
                    {
                        char p = board[y - 1, x];
                        if (c != 'e')
                        {
                            if (bobot(c) > bobot(p))
                            {
                                arrchance.Add(0);
                            }
                        }
                        else
                        {
                            if (bobot(p) > 1)
                            {
                                arrchance.Add(0);
                            }
                        }
                    }
                    if (board[y, x + 1] == '.' || board[y, x + 1] == 'T' || board[y, x + 1] == 'D' || board[y, x + 1] == 't')
                    {
                        arrchance.Add(1);
                    }
                    else if (board[y, x + 1] == 'E' || board[y, x + 1] == 'I' || board[y, x + 1] == 'C' || board[y, x + 1] == 'W' || board[y, x + 1] == 'O' || board[y, x + 1] == 'G' || board[y, x + 1] == 'R' || board[y, x + 1] == 'L')
                    {
                        char p = board[y, x + 1];
                        if (c != 'e')
                        {
                            if (bobot(c) > bobot(p))
                            {
                                arrchance.Add(1);
                            }
                        }
                        else
                        {
                            if (bobot(p) > 1)
                            {
                                arrchance.Add(1);
                            }
                        }
                    }
                    if (board[y, x - 1] == '.' || board[y, x - 1] == 'T' || board[y, x - 1] == 'D' || board[y, x - 1] == 't')
                    {
                        arrchance.Add(3);
                    }
                    else if (board[y, x - 1] == 'E' || board[y, x - 1] == 'I' || board[y, x - 1] == 'C' || board[y, x - 1] == 'W' || board[y, x - 1] == 'O' || board[y, x - 1] == 'G' || board[y, x - 1] == 'R' || board[y, x - 1] == 'L')
                    {
                        char p = board[y, x - 1];
                        if (c != 'e')
                        {
                            if (bobot(c) > bobot(p))
                            {
                                arrchance.Add(3);
                            }
                        }
                        else
                        {
                            if (bobot(p) > 1)
                            {
                                arrchance.Add(3);
                            }
                        }
                    }
                }
                else if (y > 0 && y < heightBoard - 1 && x < 1)
                {
                    if (board[y - 1, x] == '.' || board[y - 1, x] == 'T' || board[y - 1, x] == 'D' || board[y - 1, x] == 't')
                    {
                        arrchance.Add(0);
                    }
                    else if (board[y - 1, x] == 'E' || board[y - 1, x] == 'I' || board[y - 1, x] == 'C' || board[y - 1, x] == 'W' || board[y - 1, x] == 'O' || board[y - 1, x] == 'G' || board[y - 1, x] == 'R' || board[y - 1, x] == 'L')
                    {
                        char p = board[y - 1, x];
                        if (c != 'e')
                        {
                            if (bobot(c) > bobot(p))
                            {
                                arrchance.Add(0);
                            }
                        }
                        else
                        {
                            if (bobot(p) > 1)
                            {
                                arrchance.Add(0);
                            }
                        }
                    }
                    if (board[y, x + 1] == '.' || board[y, x + 1] == 'T' || board[y, x + 1] == 'D' || board[y, x + 1] == 't')
                    {
                        arrchance.Add(1);
                    }
                    else if (board[y, x + 1] == 'E' || board[y, x + 1] == 'I' || board[y, x + 1] == 'C' || board[y, x + 1] == 'W' || board[y, x + 1] == 'O' || board[y, x + 1] == 'G' || board[y, x + 1] == 'R' || board[y, x + 1] == 'L')
                    {
                        char p = board[y, x + 1];
                        if (c != 'e')
                        {
                            if (bobot(c) > bobot(p))
                            {
                                arrchance.Add(1);
                            }
                        }
                        else
                        {
                            if (bobot(p) > 1)
                            {
                                arrchance.Add(1);
                            }
                        }
                    }
                    if (board[y + 1, x] == '.' || board[y + 1, x] == 'T' || board[y + 1, x] == 'D' || board[y + 1, x] == 't')
                    {
                        arrchance.Add(2);
                    }
                    else if (board[y + 1, x] == 'E' || board[y + 1, x] == 'I' || board[y + 1, x] == 'C' || board[y + 1, x] == 'W' || board[y + 1, x] == 'O' || board[y + 1, x] == 'G' || board[y + 1, x] == 'R' || board[y + 1, x] == 'L')
                    {
                        char p = board[y + 1, x];
                        if (c != 'e')
                        {
                            if (bobot(c) > bobot(p)) arrchance.Add(2);
                        }
                        else
                        {
                            if (bobot(p) > 1) arrchance.Add(2);
                        }
                    }
                }
                else if (x > 0 && x < widthBoard - 1 && y > 0 && y < heightBoard - 1)
                {
                    if (board[y - 1, x] == '.' || board[y - 1, x] == 'T' || board[y - 1, x] == 'D' || board[y - 1, x] == 't')
                    {
                        arrchance.Add(0);
                    }
                    else if (board[y - 1, x] == 'E' || board[y - 1, x] == 'I' || board[y - 1, x] == 'C' || board[y - 1, x] == 'W' || board[y - 1, x] == 'O' || board[y - 1, x] == 'G' || board[y - 1, x] == 'R' || board[y - 1, x] == 'L')
                    {
                        char p = board[y - 1, x];
                        if (c != 'e')
                        {
                            if (bobot(c) > bobot(p))
                            {
                                arrchance.Add(0);
                            }
                        }
                        else
                        {
                            if (bobot(p) > 1)
                            {
                                arrchance.Add(0);
                            }
                        }
                    }
                    if (board[y, x + 1] == '.' || board[y, x + 1] == 'T' || board[y, x + 1] == 'D' || board[y, x + 1] == 't')
                    {
                        arrchance.Add(1);
                    }
                    else if (board[y, x + 1] == 'E' || board[y, x + 1] == 'I' || board[y, x + 1] == 'C' || board[y, x + 1] == 'W' || board[y, x + 1] == 'O' || board[y, x + 1] == 'G' || board[y, x + 1] == 'R' || board[y, x + 1] == 'L')
                    {
                        char p = board[y, x + 1];
                        if (c != 'e')
                        {
                            if (bobot(c) > bobot(p))
                            {
                                arrchance.Add(1);
                            }
                        }
                        else
                        {
                            if (bobot(p) > 1)
                            {
                                arrchance.Add(1);
                            }
                        }
                    }
                    if (board[y + 1, x] == '.' || board[y + 1, x] == 'T' || board[y + 1, x] == 'D' || board[y + 1, x] == 't')
                    {
                        arrchance.Add(2);
                    }
                    else if (board[y + 1, x] == 'E' || board[y + 1, x] == 'I' || board[y + 1, x] == 'C' || board[y + 1, x] == 'W' || board[y + 1, x] == 'O' || board[y + 1, x] == 'G' || board[y + 1, x] == 'R' || board[y + 1, x] == 'L')
                    {
                        char p = board[y + 1, x];
                        if (c != 'e')
                        {
                            if (bobot(c) > bobot(p))
                            {
                                arrchance.Add(2);
                            }
                        }
                        else
                        {
                            if (bobot(p) > 1)
                            {
                                arrchance.Add(2);
                            }
                        }
                    }
                    if (board[y, x - 1] == '.' || board[y, x - 1] == 'T' || board[y, x - 1] == 'D' || board[y, x - 1] == 't')
                    {
                        arrchance.Add(3);
                    }
                    else if (board[y, x - 1] == 'E' || board[y, x - 1] == 'I' || board[y, x - 1] == 'C' || board[y, x - 1] == 'W' || board[y, x - 1] == 'O' || board[y, x - 1] == 'G' || board[y, x - 1] == 'R' || board[y, x - 1] == 'L')
                    {
                        char p = board[y, x - 1];
                        if (c != 'e')
                        {
                            if (bobot(c) > bobot(p))
                            {
                                arrchance.Add(3);
                            }
                        }
                        else
                        {
                            if (bobot(p) > 1)
                            {
                                arrchance.Add(3);
                            }
                        }
                    }
                }
            }

            int move = new Random().Next(arrchance.Count);
            int solEasy = Convert.ToInt32(arrchance[move]);
            if (c == 'i' || c == 'l')
            {

            }
            else
            {

            }
            if (solEasy == 0) y -= 1;
            else if (solEasy == 1) x += 1;
            else if (solEasy == 2) y += 1;
            else if (solEasy == 3) x -= 1;
            return c + "-" + x + "-" + y;
        }

        private void cekConditionEnemy()
        {
            arrbobot.Clear();
            for (int i = 0; i < heightBoard; i++)
            {
                for (int j = 0; j < widthBoard; j++)
                {
                    if (board[i, j] == 'r')
                    {
                        arrbobot.Add(bobot('r'));
                    }
                    else if (board[i, j] == 'c')
                    {
                        arrbobot.Add(bobot('c'));
                    }
                    else if (board[i, j] == 'w')
                    {
                        arrbobot.Add(bobot('w'));
                    }
                    else if (board[i, j] == 'g')
                    {
                        arrbobot.Add(bobot('g'));
                    }
                    else if (board[i, j] == 'o')
                    {
                        arrbobot.Add(bobot('o'));
                    }
                    else if (board[i, j] == 'i')
                    {
                        arrbobot.Add(bobot('i'));
                    }
                    else if (board[i, j] == 'l')
                    {
                        arrbobot.Add(bobot('l'));
                    }
                    else if (board[i, j] == 'e')
                    {
                        arrbobot.Add(bobot('e'));
                    }
                }
            }
        }


        int xmusuh, ymusuh;
        char cmusuh;
        String PosMus;
        bool cekp = false;
        int rand;
        private void ModeGame(String mode)
        {
            if (mode.Equals("Easy"))
            {
                do
                {
                    rand = new Random().Next(8);
                    foreach (var item in arrbobot)
                    {
                        if (rand == Convert.ToInt32(item))
                        {
                            cekp = true;
                        }
                    }
                } while (!cekp);
                if (rand == 0)
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

                }
                else if (rand == 1)
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
                }
                else if (rand == 2)
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
                }
                else if (rand == 3)
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
                }
                else if (rand == 4)
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
                }
                else if (rand == 5)
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
                }
                else if (rand == 6)
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
                }
                else if (rand == 7)
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
                }
                else if (rand == 8)
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
                }
                PosMus = EasyEnemyMove(cmusuh, xmusuh, ymusuh);
                String[] pm = PosMus.Split('-');
                board[Convert.ToInt32(pm[2]), Convert.ToInt32(pm[1])] = cmusuh;

            }
            clearAIBoard(xmusuh, ymusuh);
            xmusuh = 0;
            ymusuh = 0;
            this.Invalidate();
        }

        private bool cekClick(char c, int x, int y)
        {
            if (c != '.' && c != '-' && c != 'd' && c != 'D' && c != 't' && c != 'T' && c != 'l' && c != 'i' && c != 'g'
                && c != 'c' && c != 'r' && c != 'o' && c != 'w' && c != 'e')
            {
                return true;
            }
            return false;
        }

        private bool cekMove(char c, int xp, int yp, int xn, int yn)
        {
            if (c == 'R')
            {
                if (yn - yp == -1 && xn - xp == 0 || yn - yp == 0 && xn - xp == 1 || yn - yp == 1 && xn - xp == 0 || yn - yp == 0 && xn - xp == -1)
                {
                    if (board[yn, xn] == '.' || board[yn, xn] == '-')
                    {
                        return true;
                    }
                }
            }
            else if (c == 'C' || c == 'W' || c == 'O' || c == 'G' || c == 'E')
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
                        if (board[yn, xn] == '.')
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
                    if (!cekMove(board[clickedy, clickedx], clickedx, clickedy, arrx, arry))
                    {
                        MessageBox.Show("Invalid Move");
                    }
                    else
                    {
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
                        cekConditionEnemy();
                        ModeGame(modePlay);
                    }
                    refreshLayarPlayer();
                }
            }
            this.Invalidate();
        }

    }
}
