using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODL3_Sokoban.domain
{
	class Character
	{
        Location loc;

        public Character(Location loc)
        {
            this.loc = loc;
        }

        public void move(Direction input)
        {
            switch (input)
            {
                case Direction.up:
                    this.loc.yPosition++;
                    break;
                case Direction.right:
                    this.loc.xPosition++;
                    break;
                case Direction.left:
                    this.loc.xPosition--;
                    break;
                case Direction.down:
                    this.loc.yPosition--;
                    break;
            }

        }

	}
}
