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
			while (true)
			{
				_pres.showInfo();
				LoadMaze(_pres.askMazeNumber());
				DrawMaze();
				bool completed = false;
				while (!completed)
				{
					TakeTurn();
					DrawMaze();
					completed = true;
					foreach (Crate c in _maze.crateList)
					{
						if (c.symbol == 'o')
						{
							completed = false;
						}
					}
				}
				Console.WriteLine("YOU WIN!");
				Console.WriteLine("press 'enter' to continue");
				Console.ReadLine();
				Console.Clear();
			}
		}

		public void LoadMaze(int mazeNumber)
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
					BaseFloor newBase = null;
					Character newCharacter = null;
					Worker newWorker = null;
					Crate newCrate = null;
					switch (c)
					{
						case '@':
							newCharacter = new Character(c);
							newLoc = new BaseFloor(xIndex, yIndex, '.');
							newBase = (BaseFloor)newLoc;
							newBase._movable = newCharacter;
							newCharacter.currentLoc = newLoc;
							_maze.character = newCharacter;
							break;
						case 'o':
							newCrate = new Crate('o');
							newLoc = new BaseFloor(xIndex, yIndex, '.');
							newBase = (BaseFloor)newLoc;
							newBase._movable = newCrate;
							newCrate.currentLoc = newLoc;
							_maze.crateList.Add(newCrate);
							break;
						case '0':
							newCrate = new Crate('o');
							newLoc = new Destination(xIndex, yIndex, 'x');
							newBase = (BaseFloor)newLoc;
							newBase._movable = newCrate;
							newCrate.currentLoc = newLoc;
							_maze.crateList.Add(newCrate);
							break;
						case '$':
							newWorker = new Worker('$');
							newLoc = new BaseFloor(xIndex, yIndex, '.');
							newBase = (BaseFloor)newLoc;
							newBase._movable = newWorker;
							newWorker.currentLoc = newLoc;
							_maze.worker = newWorker;
							break;
						case 'z':
							newWorker = new Worker('z');
							newLoc = new BaseFloor(xIndex, yIndex, '.');
							newBase = (BaseFloor)newLoc;
							newBase._movable = newWorker;
							newWorker.currentLoc = newLoc;
							_maze.worker = newWorker;
							break;
						case '.':
							newLoc = new BaseFloor(xIndex, yIndex, '.');
							break;
						case 'x':
							newLoc = new Destination(xIndex, yIndex, 'x');
							break;
						case '~' :
							newLoc = new Trap(xIndex, yIndex, '~');
							break;
						case ' ':
							newLoc = new Location(xIndex, yIndex, ' ');
							break;
						case '#':
							newLoc = new Location(xIndex, yIndex, '█');
							break;
					}
					_maze.addLoc(newLoc);
					xIndex++;
				}
				xIndex = 0;
				yIndex++;
			}
		}
		public void DrawMaze()
		{
			Console.Clear();
			_maze.firstRowLoc = _maze.firstLoc;
			_maze.secondRowLoc = _maze.firstLoc.downLoc;
			for (int i = 0; i < _maze.height; i++)
			{
				for (int j = 0; j < _maze.width; j++)
				{
					Console.Write(_maze.firstRowLoc.drawLoc());
					_maze.firstRowLoc = _maze.firstRowLoc.rightLoc;
				}
				Console.WriteLine("\b");
				if(_maze.secondRowLoc != null)
				{
					_maze.firstRowLoc = _maze.secondRowLoc;
					_maze.secondRowLoc = _maze.firstRowLoc.downLoc;
				}
			}
		}

		public void TakeTurn()
		{
			bool input = false;
			ConsoleKey key = 0;
			Direction direction = 0;
			while (!input)
			{
				key = Console.ReadKey().Key;
				if (key == ConsoleKey.LeftArrow || key == ConsoleKey.RightArrow || key == ConsoleKey.UpArrow || key == ConsoleKey.DownArrow)
				{
					switch (key)
					{
						case ConsoleKey.LeftArrow:
							direction = Direction.left;
							break;
						case ConsoleKey.RightArrow:
							direction = Direction.right;
							break;
						case ConsoleKey.UpArrow:
							direction = Direction.up;
							break;
						case ConsoleKey.DownArrow:
							direction = Direction.down;
							break;
					}

					input = true;
				}
			}
			_maze.character.Move(direction);
			if (_maze.worker != null)
			{
				direction = _maze.worker.WorkerStatusUpdate();
				if (direction != 0)
				{
					_maze.worker.Move(direction);
				}
			}
		}
	}
}
