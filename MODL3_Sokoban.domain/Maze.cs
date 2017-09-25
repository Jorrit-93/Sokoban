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
            string[] templines = System.IO.File.ReadAllLines(@"P:\Avans\Desktop\Blok 5\PROG5\Sokoban\Doolhof\doolhof" + mazeNumber + ".txt");
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
