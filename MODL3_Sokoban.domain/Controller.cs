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
					maze.character.move(direction);
					maze.drawMazeArray();
					Console.WriteLine(maze.character.loc.xPosition + "," + maze.character.loc.yPosition);
				}
			}
		}

		public bool checkMove(Location l, Direction d)
		{
			Location nextLoc = maze.getNextLoc(d, l);
			if (nextLoc.role.Equals(Symbol.dot) || nextLoc.role.Equals(Symbol.x))
			{
				return true;
			}
			if (nextLoc.role.Equals(Symbol.o) || nextLoc.role.Equals(Symbol.zero))
			{
				if (l.role.Equals(Symbol.at))
				{
					if (checkMove(maze.getNextLoc(d, l), d))
					{
						return true;
					}
				}
			}
			return false;
		}
	}
}
