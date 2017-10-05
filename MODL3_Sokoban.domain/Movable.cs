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
		public void getNextLoc(Location l, Direction d)
		{
			switch (d)
			{
				case Direction.left:
					l = l.leftLoc;
					break;
				case Direction.right:
					l = l.rightLoc;
					break;
				case Direction.up:
					l = l.upLoc;
					break;
				case Direction.down:
					l = l.downLoc;
					break;
			}
			if(checkMove(l, d))
			{
				Move(l);
			}
		}

		public bool checkMove(Location l, Direction d)
        {
			if (l.drawLoc().Equals('.') || l.drawLoc().Equals('x') || l.drawLoc().Equals('~'))
			{
				return true;
            }
			if ((l.drawLoc().Equals('o') || l.drawLoc().Equals('0')) && currentLoc.drawLoc().Equals('@'))
			{
				BaseFloor crateFloor = (BaseFloor)l;
				crateFloor._movable.getNextLoc(l, d);
				return true;
			}
			return false;
		}
		public virtual void Move(Location l)
		{
			BaseFloor temp;
			temp = (BaseFloor)l;
			temp._movable = this;
			temp = (BaseFloor)currentLoc;
			temp._movable = null;
			currentLoc = l;
		}
	}
}
