using System;
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

        public void addchild(CNode newChild)
        {
            this.child[this.jumchild] = newChild;
            this.jumchild += 1;
            newChild.parent = this;
        }
    }
}
