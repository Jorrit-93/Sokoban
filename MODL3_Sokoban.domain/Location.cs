using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODL3_Sokoban.domain
{
	public class Location
	{
		private int x;
		private int y;

		public Symbol role { get; set; }
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
	}
}
