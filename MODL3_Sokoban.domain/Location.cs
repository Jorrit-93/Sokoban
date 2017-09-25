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
        private int x;
        private int y;

        public int xPosition { get; set; }
		public int yPosition { get; set; }

		public Location(int x, int y, Symbol role)
		{
            this.role = role;
			xPosition = x;
			yPosition = y;
		}

        public Location(int x, int y)
        {
            this.x = x;
            this.y = y;
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
			return null;
		}
	}
}
