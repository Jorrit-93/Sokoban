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
        public Symbol symbol { get; set; }
        public bool canMoveObject { get; set; }

		public Movable(Symbol symbol)
		{
			this.symbol = symbol;
			switch(symbol)
			{
				case Symbol.z:
					canMoveObject = true;
					break;
				case Symbol.dollar:
					canMoveObject = true;
					break;
				case Symbol.at:
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
	}
}
