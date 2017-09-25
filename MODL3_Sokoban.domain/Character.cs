using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODL3_Sokoban.domain
{
	class Character
	{
		Symbol temp = Symbol.dot;
        public Location loc { get; set; }

        public Character(Location loc)
        {
            this.loc = loc;
        }

		public void move(Location l)
		{
			loc.symbol = temp;
			temp = l.symbol;
			loc = l;
			l.symbol = Symbol.at;
        }
	}
}
