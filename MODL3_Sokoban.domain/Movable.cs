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

        protected void Move()
        {

        }

        protected void ChangeSymbol()
        {

        }
	}
}
