using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODL3_Sokoban.domain
{
	public class Movable
	{
        public Location currentLoc { get; set; }
        public char symbol { get; set; }
        public bool canMoveObject { get; set; }

		public Movable(char symbol)
		{
			this.symbol = symbol;
			switch(symbol)
			{
				case 'z':
					canMoveObject = true;
					break;
				case '$':
					canMoveObject = true;
					break;
				case '@':
					canMoveObject = true;
					break;
				default:
					canMoveObject = false;
					break;
			}
		}

        protected void Move()
        {

        }

        protected void ChangeSymbol()
        {

        }

        public bool checkMove(Location l, Direction d)
        {
            Location nextLoc = getNextLoc(d, l);
            if (nextLoc.symbol.Equals('.') || nextLoc.symbol.Equals('x'))
            {
                return true;
            }
            if (nextLoc.symbol.Equals('o') || nextLoc.symbol.Equals('0'))
            {
                if (l.symbol.Equals('@'))
                {
                    if (checkMove(getNextLoc(d, l), d))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public Location getNextLoc(Direction d, Location l)
        {
            l = currentLoc;
            switch (d)
            {
                case Direction.left:
                    if (l.leftLoc.xPosition > 0)
                    {
                        return l.leftLoc;
                    }
                    break;
                case Direction.right:
                    if (l.rightLoc.xPosition == 0)
                    {
                        return l.rightLoc;
                    }
                    break;
                case Direction.up:
                    if (l.upLoc.xPosition > 0)
                    {
                        return l.upLoc;
                    }
                    break;
                case Direction.down:
                    if (l.downLoc.xPosition == 0)
                    {
                        return l.downLoc;
                    }
                    break;
            }
            return null;           
        }
    }
}
