using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODL3_Sokoban.domain
{
	class Controller
	{
		public bool checkMove(Location l, Direction d, Maze m)
		{
			Location nextLoc = m.getNextLoc(d, l);
			if (nextLoc.role.Equals(Symbol.dot) || nextLoc.role.Equals(Symbol.x))
			{
				return true;
			}
			if (nextLoc.role.Equals(Symbol.o) || nextLoc.role.Equals(Symbol.zero))
			{
				if (checkMove(m.getNextLoc(d, l), d, m))
				{
					return true;
				}
			}
			return false;
		}
	}
}
