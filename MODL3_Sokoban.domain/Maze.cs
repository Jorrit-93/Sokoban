using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODL3_Sokoban.domain
{
	public class Maze
	{
        public Character character { get; set; }
        public Worker worker { get; set; }
		public int height { get; set; }
		public int width { get; set; }

        public List<Crate> crateList;

		public Location firstLoc;
		public Location lastLoc;
		public Location firstRowLoc;
		public Location secondRowLoc;

		public Maze()
        {
			crateList = new List<Crate>();
        }
		
		public void addLoc(Location loc)
		{
			if(firstLoc != null)
			{
				if (loc.xPosition > 0 && loc.xPosition < width - 1)
				{
					lastLoc.rightLoc = loc;
					loc.leftLoc = lastLoc;
				}
				else if (loc.xPosition == 0)
				{
					secondRowLoc = loc;
				}
				else if (loc.yPosition > 0)
				{
					lastLoc.rightLoc = loc;
					loc.leftLoc = lastLoc;
					Location temp = secondRowLoc;
					for (int index = 0; index < width; index++)
					{
						firstRowLoc.downLoc = secondRowLoc;
						secondRowLoc.upLoc = firstRowLoc;
						firstRowLoc = firstRowLoc.rightLoc;
						secondRowLoc = secondRowLoc.rightLoc;
					}
					firstRowLoc = temp;
				}
				else
				{
					lastLoc.rightLoc = loc;
					loc.leftLoc = lastLoc;
				}
			}
			else
			{
				firstRowLoc = loc;
				firstLoc = loc;
			}
			lastLoc = loc;
		}
	}
}
