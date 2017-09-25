﻿using System;
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

        public void drawMaze(int mazeNumber)
        {
            lines = System.IO.File.ReadAllLines(@"doolhof" + mazeNumber + ".txt");
            Console.Clear();
            foreach (string line in lines)
            {
                foreach (char c in line)
                {
                    Console.Write(c);
                }
                Console.WriteLine("\b");
            }
            Console.WriteLine(height + " " + width);
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
