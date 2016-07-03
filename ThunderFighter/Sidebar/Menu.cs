namespace ThunderFighter.Sidebar
{
    using System;
    using System.Collections.Generic;
    using static ScreenBuffer;
    internal class Menu
    {
        private Field field;

        public Menu(Field field)
        {
            this.Field = field;
        }

        public void CreateBase()
        {
            WriteSumb(field.Width, 0, '╔', ConsoleColor.DarkGray);
            WriteSumb(field.Width + Constants.MenuWidth - 2, 0, '╗', ConsoleColor.DarkGray);
            WriteSumb(field.Width, field.Height - 1, '╚', ConsoleColor.DarkGray);
            WriteSumb(field.Width + Constants.MenuWidth - 2 , field.Height - 1, '╝', ConsoleColor.DarkGray);

            for (int i = 1; i < Constants.MenuWidth - 2; i++)
            {
                WriteSumb(field.Width + i, 0, '═', ConsoleColor.DarkGray);
                WriteSumb(field.Width + i, field.Height - 1, '═', ConsoleColor.DarkGray);
            }
            for (int i = 1; i < field.Height - 1; i++)
            {
                WriteSumb(field.Width, i, '║', ConsoleColor.DarkGray);
                WriteSumb(field.Width + Constants.MenuWidth - 2, i, '║', ConsoleColor.DarkGray);
            }

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.SetCursorPosition(field.Width + 2, 1);
            Console.WriteLine(new String('▄', Constants.MenuWidth - 5));
            Console.SetCursorPosition(field.Width + 2, 2);
            Console.WriteLine("█▓▒░                      ░▒▓█");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(field.Width + 9, 2);
            Console.WriteLine("THUNDER FIGHTER");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.SetCursorPosition(field.Width + 2, 3);
            Console.WriteLine(new String('▀', Constants.MenuWidth - 5));
            Console.SetCursorPosition(field.Width + 2, 4);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("by Team - Hestia");


        }

        private static void WriteSumb(int x, int y, char w, ConsoleColor color)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            Console.Write(w);
        }

        public Field Field
        {
            get
            {
                return this.field;
            }

            private set
            {
                this.field = value;
            }
        }
    }
}
