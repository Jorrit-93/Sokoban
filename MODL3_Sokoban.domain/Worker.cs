using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODL3_Sokoban.domain
{
    public class Worker : Movable
    {
        Random random = new Random();

		public Worker(char symbol) : base(symbol)
		{
		}

		public new void Move()
        {
            int rnd = random.Next(1,5);

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
            if (this.symbol == '$')
                this.symbol = 'z';
            else
                this.symbol = '$';
        }

        public void WorkerStatusUpdate()
        {
            if (this.symbol == '$')
            {
                TriggerSleep();
            }
            else if (this.symbol == 'z')
            {
                TriggerWakeUp();
            }
            else
                return;
        }

        public void TriggerSleep()
        {
            int rnd = random.Next(1, 5);

            if (rnd == 1)
            {
                this.symbol = 'z';
            }
            else
            {
                Move();
            }
        }

        public void TriggerWakeUp()
        {
            int rnd = random.Next(1, 11);

            if (rnd == 1)
            {
                this.symbol = '$';
                Move();
            }
        }
    }
}
