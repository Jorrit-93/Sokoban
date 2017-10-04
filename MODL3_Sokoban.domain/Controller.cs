using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODL3_Sokoban.domain
{
	public class Controller
	{
		public Presentation _pres;
		public Maze _maze;
		public Controller()
		{
			_pres = new Presentation(this);
			_pres.showInfo();
			loadMaze(_pres.askMazeNumber());
			drawMaze();
		}

		public void loadMaze(int mazeNumber)
		{
			string[] lines;
			lines = System.IO.File.ReadAllLines(@"doolhof" + mazeNumber + ".txt");
			int xIndex = 0;
			int yIndex = 0;
			_maze = new Maze();
			_maze.width = lines[0].Length;
			_maze.height = lines.Length;
			foreach (string line in lines)
			{
				foreach (char c in line)
				{
					Location newLoc = null;
					Character newCharacter = null;
					Worker newWorker = null;
					Crate newCrate = null;
					switch (filterChar(c))
					{
						case Symbol.at:
							newLoc = new BaseFloor(xIndex, yIndex, Symbol.dot);
							newCharacter = new Character(Symbol.at);
							newCharacter.currentLoc = newLoc;
							_maze.character = newCharacter;
							break;
						case Symbol.o:
							newLoc = new BaseFloor(xIndex, yIndex, Symbol.dot);
							newCrate = new Crate(Symbol.o);
							newCrate.currentLoc = newLoc;
							_maze.crateList.Add(newCrate);
							break;
						case Symbol.zero:
							newLoc = new BaseFloor(xIndex, yIndex, Symbol.x);
							newCrate = new Crate(Symbol.o);
							newCrate.currentLoc = newLoc;
							_maze.crateList.Add(newCrate);
							break;
						case Symbol.dollar:
							newLoc = new BaseFloor(xIndex, yIndex, Symbol.dot);
							newWorker = new Worker(Symbol.dollar);
							newWorker.currentLoc = newLoc;
							_maze.worker = newWorker;
							break;
						case Symbol.z:
							newLoc = new BaseFloor(xIndex, yIndex, Symbol.dot);
							newWorker = new Worker(Symbol.z);
							newWorker.currentLoc = newLoc;
							_maze.worker = newWorker;
							break;
						case Symbol.dot:
							newLoc = new BaseFloor(xIndex, yIndex, Symbol.dot);
							break;
						case Symbol.x:
							newLoc = new BaseFloor(xIndex, yIndex, Symbol.x);
							break;
						case Symbol.wave:
							newLoc = new Trap(xIndex, yIndex, Symbol.wave);
							break;
						case Symbol.whitespace:
							newLoc = new Trap(xIndex, yIndex, Symbol.whitespace);
							break;
						default:
							newLoc = new Location(xIndex, yIndex, filterChar(c));
							break;
					}
					_maze.addLoc(newLoc);
					xIndex++;
				}
				xIndex = 0;
				yIndex++;
			}
		}
		public void drawMaze()
		{
			Console.Clear();
			_maze.firstRowLoc = _maze.firstLoc;
			_maze.secondRowLoc = _maze.firstLoc.downLoc;
			for (int i = 0; i < _maze.height; i++)
			{
				for (int j = 0; j < _maze.width; j++)
				{
					Console.Write(filterSymbol(_maze.firstRowLoc.symbol));
					_maze.firstRowLoc = _maze.firstRowLoc.rightLoc;
				}
				Console.WriteLine("\b");
				if(_maze.secondRowLoc != null)
				{
					_maze.firstRowLoc = _maze.secondRowLoc;
					_maze.secondRowLoc = _maze.firstRowLoc.downLoc;
				}
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
			else if (s == Symbol.wave)
			{
				return '~';
			}
			else if (s == Symbol.z)
			{
				return 'z';
			}
			else if (s == Symbol.dollar)
			{
				return '$';
			}
			else
			{
				return ' ';
			}
		}
	}
}
