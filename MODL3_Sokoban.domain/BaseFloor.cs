using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODL3_Sokoban.domain
{
	class BaseFloor : Location
	{
		public Movable _movable { get; set; }

		public BaseFloor(int x, int y, char symbol) : base(x, y, symbol)
		{
		}

		public override char drawLoc()
		{
			if (_movable == null)
			{
				return symbol;
			}
			else
			{
				return _movable.symbol;
			}
		}

		public Movable MoveFromThisField()
		{
			return _movable;
		}

		public void MoveToThisField(Movable obj)
		{
			this._movable = obj;
		}
	}
}
