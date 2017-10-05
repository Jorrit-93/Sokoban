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
					switch (c)
					{
						case '@':
							newCharacter = new Character(c);
							newLoc = new BaseFloor(xIndex, yIndex, '.', newCharacter);
							newCharacter.currentLoc = newLoc;
							_maze.character = newCharacter;
							break;
						case 'o':
							newLoc = new BaseFloor(xIndex, yIndex, '.');
							newCrate = new Crate('o');
							newCrate.currentLoc = newLoc;
							_maze.crateList.Add(newCrate);
							break;
						case '0':
							newLoc = new BaseFloor(xIndex, yIndex, 'x');
							newCrate = new Crate('o');
							newCrate.currentLoc = newLoc;
							_maze.crateList.Add(newCrate);
							break;
						case '$':
							newLoc = new BaseFloor(xIndex, yIndex, '.');
							newWorker = new Worker('$');
							newWorker.currentLoc = newLoc;
							_maze.worker = newWorker;
							break;
						case 'z':
							newLoc = new BaseFloor(xIndex, yIndex, '.');
							newWorker = new Worker('z');
							newWorker.currentLoc = newLoc;
							_maze.worker = newWorker;
							break;
						case '.':
							newLoc = new BaseFloor(xIndex, yIndex, '.');
							break;
						case 'x':
							newLoc = new BaseFloor(xIndex, yIndex, 'x');
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
		public void drawMaze()
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
			Console.ReadLine();
		}
	}
}
