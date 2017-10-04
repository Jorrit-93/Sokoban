using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODL3_Sokoban.domain
{
	class BaseFloor : Location
	{
		private Movable _movable;

		public BaseFloor(int x, int y, Symbol symbol) : base(x, y, symbol)
		{
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
