namespace MODL3_Sokoban.domain
{
	public class Trap : BaseFloor
	{
        public int stepCounter { get; set; }

		public Trap(int x, int y, char symbol) : base(x, y, symbol)
		{
            stepCounter = 0;
		}

        public void DropCrate()
        {
            if (_movable.symbol == 'o')
            {
                _movable = null;
            }
        }
        
        public void RaiseStepCounter()
        {
			if (_movable != null)
			{
				if (_movable.symbol == '@')
				{
					stepCounter++;
				}
				if (stepCounter >= 3)
				{
					ChangeSymbol();
					DropCrate();
				}
			}
		}

        public void ChangeSymbol()
        {
            symbol = ' ';
        }

		public override char drawLoc()
		{
			RaiseStepCounter();
			if (_movable == null)
			{
				return symbol;
			}
			else
			{
				return _movable.symbol;
			}
		}
	}
}