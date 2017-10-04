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
				if (loc.xPosition < width)
				{
					lastLoc.rightLoc = loc;
					loc.leftLoc = lastLoc;
				}
				else if (loc.yPosition != 1)
				{
					Location temp = secondRowLoc;
					for (int index = 1; index < width; index++)
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
					secondRowLoc = loc;
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
