using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalChessFelix
{
    public class Hewan
    {
        protected String name;
        protected int posX, posY;
        public Hewan(String name,int posX, int posY)
        {
            this.name = name;
            this.posX = posX;
            this.posY = posY;
        }

        public String getName()
        {
            return this.name;
        }

        public int getposX()
        {
            return this.posX;
        }

        public int getposY()
        {
            return this.posY;
        }

    }

    //public class Tiger : Hewan
    //{
    //    public Tiger(String name, int posX, int posY)
    //    {
    //        super(name,posX,posY);
    //    }
    //}

}
