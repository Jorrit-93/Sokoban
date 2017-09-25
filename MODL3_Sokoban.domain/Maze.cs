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

        public Maze(int num)
        {
            determineArraySize(num);
            locList = new Location[arraySize];
        }

        string[] lines;
        int xIndex = 0;
        int yIndex = 0;
        int listIndex = 0;
        int arraySize = 0;
        public void loadMaze(int mazeNumber)
        {
            lines = System.IO.File.ReadAllLines(@"doolhof" + mazeNumber + ".txt");
            foreach (string line in lines)
            {
                foreach (char c in line)
                {
                    locList[listIndex] = new Location(xIndex, yIndex, filterChar(c));
                    xIndex++;
                    listIndex++;
                }
                xIndex = 0;
                yIndex++;
            }
        }

		public void drawMazeArray()
		{
			Console.Clear();
			int index = 0; ;
			for (int i = 0; i < height; i++)
			{
				for (int j = 0; j < width; j++)
				{
					Console.Write(filterSymbol(locList[index].symbol));
					index++;
				}
				Console.WriteLine("\b");
			}
			index = 0;
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
                return Symbol.x;
            }
            else if (c == '@')
            {
                character = new Character(new Location(xIndex, yIndex, Symbol.at));
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

		public char filterSymbol(Symbol s)
		{
			if (s == Symbol.hashtag)
			{
				return '█';
			}
			else if (s == Symbol.dot)
			{
				return '.';
			}
			else if (s == Symbol.o)
			{
				return 'o';
			}
			else if (s == Symbol.zero)
			{
				return '0';
			}
			else if (s == Symbol.x)
			{
				return 'x';
			}
			else if (s == Symbol.at)
			{
				return '@';
			}
			else if (s == Symbol.whitespace)
			{
				return ' ';
			}
			else
			{
				return ' ';
			}
		}

		public void determineArraySize(int mazeNumber)
        {
            string[] templines = System.IO.File.ReadAllLines(@"doolhof" + mazeNumber + ".txt");
            foreach (string line in templines)
            {
                height++;
                foreach (char c in line)
                {
                    arraySize++;
                }
            }
            width = arraySize / height;
        }
	}
}
