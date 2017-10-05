using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODL3_Sokoban.domain
{
	public class Destination : BaseFloor
	{
		public Destination(int x, int y, char symbol) : base(x, y, symbol)
		{
		}
		public override char drawLoc()
		{
			if (_movable == null)
			{
				return symbol;
			}
			if(_movable.symbol.Equals('o'))
			{
				Crate temp = (Crate)_movable;
				temp.ChangeSymbol();
			}
			return _movable.symbol;
		}
	}
}
