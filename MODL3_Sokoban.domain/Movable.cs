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

		public bool checkMove(Location nextLoc, Direction direction)
        {
			if (nextLoc.drawLoc().Equals('.') || nextLoc.drawLoc().Equals('x') || nextLoc.drawLoc().Equals('~') || nextLoc.drawLoc().Equals(' '))
			{
				return true;
            }
			if ((nextLoc.drawLoc().Equals('o') || nextLoc.drawLoc().Equals('0')) && canMoveObject)
			{
				BaseFloor crateFloor = (BaseFloor)nextLoc;
				return crateFloor._movable.Move(direction);
			}
			return false;
		}
		public Location getNextLoc(Direction direction)
		{
			switch (direction)
			{
				case Direction.left:
					return currentLoc.leftLoc;
				case Direction.right:
					return currentLoc.rightLoc;
				case Direction.up:
					return currentLoc.upLoc;
				case Direction.down:
					return currentLoc.downLoc;
			}
			return null;
		}

		public bool Move(Direction direction)
		{
			Location nextLoc = getNextLoc(direction);
			if (checkMove(nextLoc, direction))
			{
				BaseFloor temp;
				temp = (BaseFloor)nextLoc;
				temp._movable = this;
				temp = (BaseFloor)currentLoc;
				temp._movable = null;
				currentLoc = nextLoc;
				return true;
			}
			return false;
		}
	}
}
