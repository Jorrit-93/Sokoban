using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODL3_Sokoban.domain
{
	public class Controller
	{
		Presentation pres = new Presentation();
		Maze maze;

		public Controller()
		{
			pres.showInfo();
			maze = pres.maze;
			moveCharacter();
		}
		
		public void moveCharacter()
		{
			bool input = true;
			ConsoleKey key = 0;
			while (input)
			{
				key = Console.ReadKey().Key;
				if (key == ConsoleKey.LeftArrow || key == ConsoleKey.RightArrow || key == ConsoleKey.UpArrow || key == ConsoleKey.DownArrow)
				{
					Direction direction = 0;
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
					if(checkMove(maze.character.loc, direction))
					{
						maze.character.move(getNextLoc(direction, maze.character.loc));
						maze.drawMazeArray();
					}
					Console.WriteLine(maze.character.loc.xPosition + "," + maze.character.loc.yPosition);
				}
			}
		}
		public bool checkMove(Location l, Direction d)
		{
			Location nextLoc = getNextLoc(d, l);
			if (nextLoc.symbol.Equals(Symbol.dot) || nextLoc.symbol.Equals(Symbol.x))
			{
				return true;
			}
			if (nextLoc.symbol.Equals(Symbol.o) || nextLoc.symbol.Equals(Symbol.zero))
			{
				if (l.symbol.Equals(Symbol.at))
				{
					if (checkMove(getNextLoc(d, l), d))
					{
						return true;
					}
				}
			}
			return false;
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
					break;
				case Direction.right:
					if (l.xPosition < maze.width)
					{
						x = x + 1;
					}
					break;
				case Direction.up:
					if (l.yPosition > 0)
					{
						y = y - 1;
					}
					break;
				case Direction.down:
					if (l.yPosition < maze.height)
					{
						y = y + 1;
					}
					break;
			}

			foreach (Location element in maze.locList)
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
