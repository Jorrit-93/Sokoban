using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODL3_Sokoban.domain
{
	public class Controller
	{
		public Maze _maze;
		public Controller()
		{

		}
		public void loadMaze(int mazeNumber)
		{
			_maze = new Maze();
			string[] lines;
			lines = System.IO.File.ReadAllLines(@"doolhof" + mazeNumber + ".txt");
			int xIndex = 0;
			int yIndex = 0;
			foreach (string line in lines)
			{
				foreach (char c in line)
				{
					Location newLoc = new Location(xIndex, yIndex, filterChar(c));
					xIndex++;
				}
				xIndex = 0;
				yIndex++;
			}
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
				return Symbol.dot;
			}
			else if (c == '~')
			{
				return Symbol.wave;
			}
			else if (c == 'z')
			{
				return Symbol.z;
			}
			else if (c == '$')
			{
				return Symbol.dollar;
			}
			else
			{
				return Symbol.whitespace;
			}
		}
	}
}
