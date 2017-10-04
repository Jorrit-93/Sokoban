using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODL3_Sokoban.domain
{
	public class Crate : Movable
	{
		public Crate(Symbol symbol) : base(symbol)
		{
		}

		public void Move()
        {

        }

        public void ChangeSymbol()
        {
            this.symbol = Symbol.zero;
        }
	}
}
