namespace MODL3_Sokoban.domain
{
	internal class Trap : BaseFloor
	{
        public int stepCounter { get; set; }

		public Trap(int x, int y, char symbol) : base(x, y, symbol)
		{
            stepCounter = 0;
		}

        public void DropCrate()
        {
            if (_movable.currentLoc.xPosition == xPosition && _movable.currentLoc.yPosition == yPosition)
            {
                if (_movable.symbol == 'o')
                {
                    _movable = null;
                }
            }
        }
        
        public void RaiseStepCounter()
        {
            if (_movable.currentLoc.xPosition == xPosition && _movable.currentLoc.yPosition == yPosition)
            {
                if (_movable.symbol == '@')
                {
                    stepCounter++;
                    if (stepCounter == 3)
                    {
                        symbol = ' ';
                        DropCrate();
                    }
                }
            }                      
        }
	}
}