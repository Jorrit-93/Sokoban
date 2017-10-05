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

		public Direction RandomDirection()
        {
            int rnd = random.Next(1,5);
            switch (rnd)
            {
                case 1:
                    return Direction.left;
                case 2:
					return Direction.right;
				case 3:
					return Direction.up;
				case 4:
					return Direction.down;
			}
			return 0;
        }

        public new void ChangeSymbol()
        {
            if (this.symbol == '$')
                this.symbol = 'z';
            else
                this.symbol = '$';
        }

        public Direction WorkerStatusUpdate()
        {
            if (this.symbol == '$')
			{
				int rnd = random.Next(1, 5);
				if (rnd == 1)
				{
					ChangeSymbol();
				}
			}
			else if (this.symbol == 'z')
			{
				int rnd = random.Next(1, 11);
				if (rnd == 1)
				{
					ChangeSymbol();
				}
			}
			if (this.symbol == '$')
			{
				return RandomDirection();
			}
			return 0;
		}
    }
}
