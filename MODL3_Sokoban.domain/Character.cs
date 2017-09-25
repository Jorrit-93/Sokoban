using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODL3_Sokoban.domain
{
	class Character
	{
        public Location loc { get; set; }

        public Character(Location loc)
        {
            this.loc = loc;
        }
	}
}
