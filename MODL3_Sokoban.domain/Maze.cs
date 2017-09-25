using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODL3_Sokoban.domain
{
	class Maze
	{
		public Location[] locList { get; set; }
        public Character character { get; set; }
		public int height { get; set; }
		public int width { get; set; }

        string[] lines;
        int xIndex = 0;
        int yIndex = 0;
        int listIndex = 0;
        public void loadMaze(int mazeNumber)
        {
            lines = System.IO.File.ReadAllLines(@"P:\Avans\Desktop\Blok 5\PROG5\Sokoban\Doolhof\doolhof" + mazeNumber + ".txt");
            Console.Clear();
            foreach (string line in lines)
            {
                foreach (char c in line)
                {
                    locList[listIndex] = new Location(xIndex, yIndex, filterChar(c));
                    xIndex++;
                    listIndex++;
                    Console.Write(c);
                }
                Console.WriteLine("\b");
                xIndex = 0;
                yIndex++;
            }
            Console.ReadLine();
        }

        public Symbol filterChar(char c)
        {
            if (c == '#')
            {
                return Symbol.hashtag;
            }
            else if (c == '.')
            {
                return Symbol.dot;
            }
            else if (c == 'o')
            {
                return Symbol.o;
            }
            else if (c == '0')
            {
                return Symbol.zero;
            }
            else if (c == 'x')
            {
                return Symbol.zero;
            }
            else if (c == '@')
            {
                return Symbol.at;
            }
            else if (c == ' ')
            {
                return Symbol.whitespace;
            }
            else
            {
                return Symbol.whitespace;
            }
        }

		public Location getNextLoc(Direction d, Location l)
		{
			int x = l.xPosition;
			int y = l.yPosition;

			switch (d)
			{
				case Direction.left:
					if (l.xPosition > 0)
					{
						x = x - 1;
					}
					return null;
				case Direction.right:
					if (l.xPosition < width)
					{
						x = x + 1;
					}
					return null;
				case Direction.up:
					if (l.yPosition > 0)
					{
						y = y - 1;
					}
					return null;
				case Direction.down:
					if (l.yPosition < height)
					{
						y = y + 1;
					}
					return null;
			}

			foreach (Location element in locList)
			{
				if (element.xPosition == x && element.yPosition == y)
				{
					return element;
				}
			}

			return null;
		}
	}
}
