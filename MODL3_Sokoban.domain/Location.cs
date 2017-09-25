using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODL3_Sokoban.domain
{
	class Location
	{
		public Symbol role { get; set; }
		public Location leftLoc;
		public Location rightLoc;
		public Location upLoc;
		public Location downLoc;
		public int xPosition { get; set; }
		public int yPosition { get; set; }

		public Location(int x, int y, Symbol role)
		{
            this.role = role;
			xPosition = x;
			yPosition = y;
		}

		public Location getLeftLoc(Direction d, Maze m)
		{
			int x = xPosition;
			int y = yPosition;
			
			switch (d) {
				case Direction.left:
					x = x - 1;
					break;
				case Direction.right:
					x = x + 1;
					break;
				case Direction.up:
					y = y - 1;
					break;
				case Direction.down:
					y = y + 1;
					break;
			}

			foreach(Location l in m.locList) {
				if(l.xPosition == x && l.yPosition == y)
				{
					if(Maze.character)
					switch (l.role)
					{
						case Symbol.dot:
							return l;
						case Symbol.hashtag:
							return null;
						case Symbol.o:
							return l;
						case Symbol.zero:
							return l;
					}
				}
			}
			return null;
		}
	}
}
