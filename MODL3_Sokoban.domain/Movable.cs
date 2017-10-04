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
        public Symbol symbol { get; set; }
        public bool canMoveObject { get; set; }

        protected void Move()
        {

        }

        protected void ChangeSymbol()
        {

        }

        public bool checkMove(Location l, Direction d)
        {
            Location nextLoc = getNextLoc(d, l);
            if (nextLoc.symbol.Equals(Symbol.dot) || nextLoc.symbol.Equals(Symbol.x))
            {
                return true;
            }
            if (nextLoc.symbol.Equals(Symbol.o) || nextLoc.symbol.Equals(Symbol.zero))
            {
                if (l.symbol.Equals(Symbol.at))
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
