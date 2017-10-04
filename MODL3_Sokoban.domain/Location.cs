using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODL3_Sokoban.domain
{
	public class Location
	{
		public Symbol symbol { get; set; }

		public int xPosition { get; set; }
		public int yPosition { get; set; }

		public Location leftLoc { get; set; }
		public Location rightLoc { get; set; }
		public Location upLoc { get; set; }
		public Location downLoc { get; set; }

		public Location(int x, int y, Symbol symbol)
		{
            this.symbol = symbol;
			this.xPosition = x;
			this.yPosition = y;
		}

		public Location(int x, int y)
		{
			this.xPosition = x;
			this.yPosition = y;
		}

		public Symbol drawLoc()
		{
			return symbol;
		}
	}
}
