using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalChessFelix
{
    class CNode
    {
        // ini utk keperluan permainan
        public string[,] papan;
        public int bobot;
        public int level;
        public int giliran;

        // ini utk keperluan tree
        public CNode[] child;
        public int jumchild;
        public CNode parent;
        int[] hewanAI = new int[9];
        int[] hewanPlayer = new int[9];
        Stack stack1 = new Stack();
        Stack AIstack = new Stack();
        Stack playerstack = new Stack();
        int hasilsbe;

        public CNode(int level, int giliran, string[,] papan)
        {
            this.papan = new string[9, 7];
            this.jumchild = 0;
            for (int b = 0; b < 9; b += 1)
            {
                for (int k = 0; k < 7; k += 1)
                {
                    this.papan[b, k] = papan[b, k];
                }
            }
            this.level = level;
            this.giliran = giliran;
            this.bobot = hitungbobot(level, giliran, papan);
        }

        public int hitungbobot(int lv, int gil, string[,] tmppapan)
        {
            int bobot = 0;

            if (bobot == 3)
            {

            }

            return bobot;
        }

        public void sbe()
        {
            int[] AI = new int[1];
            int[] PLAYER = new int[1];

            for (int b = 0; b < 9; b += 1)
            {
                for (int k = 0; k < 7; k += 1)
                {
                    this.papan[b, k] = papan[b, k];
                    stack1.Push(papan[b, k]);

                }

            }
            for (int i = 0; i < hewanAI.Length; i++)
            {
                if (hewanAI.Length != -1)
                {
                    AIstack.Push(AI);
                }
            }

            for (int j = 0; j < hewanPlayer.Length; j++)
            {
                if (hewanPlayer.Length != 1)
                {
                    playerstack.Push(AI);
                }
            }
            hasilsbe = hewanPlayer.Length - hewanPlayer.Length;

        }
        public void minimax()
        {
            var valueplayer = "";
            int[,] papantemp1 = new int[2, 2]; ;
            int[] papantemp = new int[9];
            for (int i = 0; i < 9; i++)
            {
                papantemp[i] = papantemp[7];
            }

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    papantemp1[i, j] = papantemp[i].CompareTo(papantemp);
                }
            }

            if (level == 2)
            {

                hasilsbe = hewanPlayer.Length - hewanPlayer.Length;
            }
            else
            {
                int movex = -1;
                int movey = -1;
                int movpos = -1;

                int makanx = -1;
                int makany = -1;
                int makanpos = -1;

                int valueMap = int.MinValue;

                int value = int.MaxValue;

                string giliran = "player1";
                if (level % 2 == 1)
                {
                    value = int.MinValue;
                    giliran = "AI";
                }
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 7; j++)
                    {
                        var before = papantemp1[i, j];
                        int powerbeforeAI;
                        int powerbefore;
                        if (papantemp1[i, j].Equals("AI") && papantemp1[i, j].Equals(""))
                        {
                            for (int k = 0; k < -4; k++)
                            {
                                if (i == 6 && j == 3 && papantemp1[i, j].Equals(""))
                                {
                                    value = 1;
                                }
                                String result = "";
                                if (result == "0")
                                {
                                    int returnSBE = hasilsbe;
                                    if (bobot % 2 == 1)
                                    {
                                        if (returnSBE > value)
                                        {
                                            value = returnSBE;
                                            movey = i; movex = j; movpos = k;
                                        }
                                    }
                                    else
                                    {
                                        System.Windows.Forms.MessageBox.Show(giliran + "AllMove, Y: " + i + " , X: " + j + " , Move: " + k + "Giliran: " + giliran + " bobot: " + bobot);
                                        if (result == "jalan")
                                        {
                                            if (Convert.ToInt32(result) > valueMap)
                                            {
                                                System.Windows.Forms.MessageBox.Show(giliran + "bestMoveValueMAP, Y: " + i + " , X: " + j + " Move:" + k + " Giliran: " + giliran + " bobot:" + bobot);
                                                System.Windows.Forms.MessageBox.Show(giliran + "mapVAL - SBE: " + result[5] + " , valueMAP" + valueMap);
                                                valueMap = result[5];
                                                movey = i; movex = j; movpos = k;
                                            }
                                        }
                                        if (returnSBE < value)
                                        {
                                            System.Windows.Forms.MessageBox.Show(giliran + "bestMovP, Y: " + i + " , X: " + j + " Move:" + k + " Giliran: " + giliran + " bobot:" + bobot);
                                            System.Windows.Forms.MessageBox.Show(giliran + "bestMovP = SBE: " + returnSBE + " , Value:" + value);
                                            var valuepalyer = (returnSBE);
                                            var xplayer = (j);
                                            var movplayer = (k);
                                            value = returnSBE;
                                            movey = i; movex = j; movpos = k;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (bobot == 0)
            {
                int result = 0;
                if (result == 0)
                {
                    var pos = 0;
                    for (int i = 0; i < valueplayer.Length; i++)
                    {
                        pos = i;
                    }
                }
                else
                {
                    var temp = int.MaxValue;
                    var pos = 0;
                    for (int i = 0; i < valueplayer.Length; i++)
                    {
                        temp = valueplayer.Length;
                        pos = i;
                    }
                    var baris = "";
                }
            }
        }

        public void addchild(CNode newChild)
        {
            this.child[this.jumchild] = newChild;
            this.jumchild += 1;
            newChild.parent = this;
        }
    }
}
