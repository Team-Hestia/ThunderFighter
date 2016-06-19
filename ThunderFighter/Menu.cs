using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThunderFighter
{
    public class Menu
    {
        private int points;
        private int lives;

        public int Lives
        {
            get { return lives; }
            set { lives = value; }
        }


        public int Points
        {
            get { return points; }
            set { points = value; }
        }

        public static void DrawBorders(int width, int height)
        {
            // border of play field with current dimentions
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.SetCursorPosition(0, 0);
            Console.Write('╔');
            Console.SetCursorPosition(0, height - 1);
            Console.Write('╚');
            Console.SetCursorPosition(width - Constants.MenuWidth, 0);
            Console.Write('╗');
            Console.SetCursorPosition(width - Constants.MenuWidth, height - 1);
            Console.Write('╝');
            for (int i = 1; i < width - Constants.MenuWidth; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write('═');
                Console.SetCursorPosition(i, height - 1);
                Console.Write('═');
            }
            for (int i = 1; i < height - 1; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write('║');
                Console.SetCursorPosition(width - Constants.MenuWidth, i);
                Console.Write('║');
            }
            // border of menu
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.SetCursorPosition(width - Constants.MenuWidth + 2, 0);
            Console.WriteLine(new String('▄', Constants.MenuWidth - 4));
            Console.SetCursorPosition(width - Constants.MenuWidth + 2, 1);
            Console.WriteLine("█▓▒░                       ░▒▓█");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(width - Constants.MenuWidth + 10, 1);
            Console.WriteLine("THUNDER FIGHTER");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.SetCursorPosition(width - Constants.MenuWidth + 2, 2);
            Console.WriteLine(new String('▀', Constants.MenuWidth - 4));
            Console.SetCursorPosition(width - Constants.MenuWidth + 2, 3);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("by Team - Hestia");
        }
    }
}
