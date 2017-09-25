﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODL3_Sokoban.domain
{
    class Presentation
    {
        public Maze maze { get; set; }
        public void showInfo()
        {
            Console.WriteLine("┌────────────────────────────────────────────────────┐");
            Console.WriteLine("| Welkom bij Sokoban                                 |");
            Console.WriteLine("|                                                    |");
            Console.WriteLine("| betekenis van de symbolen   |   doel van het spel  |");
            Console.WriteLine("|                             |                      |");
            Console.WriteLine("| spatie : outerspace         |   duw met de truck   |");
            Console.WriteLine("|      █ : muur               |   de krat(ten)       |");
            Console.WriteLine("|      · : vloer              |   naar de bestemming |");
            Console.WriteLine("|      O : krat               |                      |");
            Console.WriteLine("|      0 : krat op bestemming |                      |");
            Console.WriteLine("|      x : bestemming         |                      |");
            Console.WriteLine("|      @ : truck              |                      |");
            Console.WriteLine("└────────────────────────────────────────────────────┘");
            Console.WriteLine("");
            askMazeNumber();
        }

        public int askMazeNumber()
        {
            int num = 0;
            char c = '?';
            while ((num < 1 || num > 4) && c != 's')
            {
                Console.WriteLine("> Kies een doolhof (1 - 4), s = stop");
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
                c = consoleKeyInfo.KeyChar;
                Console.WriteLine();
                if (c >= '1' && c <= '4')
                {
                    string value = char.ToString(consoleKeyInfo.KeyChar);
                    num = Convert.ToInt32(value);
                    maze = new Maze(num);
                    maze.loadMaze(num);
					maze.drawMazeArray();
                }
                else if (c != 's')
                {
                    Console.WriteLine("> ?");
                }
            }
            if (c == 's')
            {
                num = -1;
            }
            return num;
        }
    }
}
