using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODL3_Sokoban.domain
{
	class Location
	{
		public Location leftLoc;
		public Location rightLoc;
		public Location upLoc;
		public Location downLoc;
		public int xPosition { get; set; }
		public int yPosition { get; set; }

		public Location(int x, int y)
		{
			xPosition = x;
			yPosition = y;
		}

		public void createSurrounding(Maze maze)
		{

		}
	}
}
