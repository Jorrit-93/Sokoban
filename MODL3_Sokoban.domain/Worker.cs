using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODL3_Sokoban.domain
{
    public class Worker : Movable
    {
        Random randomLoc = new Random();
        public Worker()
        {

        }
        public new void Move()
        {
            int rnd = randomLoc.Next(1,5);

            switch (rnd)
            {
                case 1:
                    this.currentLoc = currentLoc.leftLoc;
                    break;
                case 2:
                    this.currentLoc = currentLoc.rightLoc;
                    break;
                case 3:
                    this.currentLoc = currentLoc.upLoc;
                    break;
                case 4:
                    this.currentLoc = currentLoc.downLoc;
                    break;
            }
            
        }

        public new void ChangeSymbol()
        {
            if (this.symbol == Symbol.dollar)
                this.symbol = Symbol.z;
            else
                this.symbol = Symbol.dollar;
        }
    }
}
