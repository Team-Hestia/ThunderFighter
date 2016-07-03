namespace ThunderFighter.Sidebar
{
    using System;
    using System.Collections.Generic;
    using static ScreenBuffer;
    internal class Menu
    {
        private Field field;
        private Engine engine;

        public Menu(Field field, Engine engine)
        {
            this.engine = engine;
            this.Field = field;
        }

        public void CreateBase()
        {
            /*
            WriteSymb(field.Width, 0, '╔', ConsoleColor.DarkGray);
            WriteSymb(field.Width + Constants.MenuWidth - 2, 0, '╗', ConsoleColor.DarkGray);
            WriteSymb(field.Width, field.Height - 1, '╚', ConsoleColor.DarkGray);
            WriteSymb(field.Width + Constants.MenuWidth - 2 , field.Height - 1, '╝', ConsoleColor.DarkGray);

            for (int i = 1; i < Constants.MenuWidth - 2; i++)
            {
                WriteSymb(field.Width + i, 0, '═', ConsoleColor.DarkGray);
                WriteSymb(field.Width + i, field.Height - 1, '═', ConsoleColor.DarkGray);
            }
            for (int i = 1; i < field.Height - 1; i++)
            {
                WriteSymb(field.Width, i, '║', ConsoleColor.DarkGray);
                WriteSymb(field.Width + Constants.MenuWidth - 2, i, '║', ConsoleColor.DarkGray);
            }*/

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.SetCursorPosition(field.Width + 2, 1);
            Console.WriteLine(new String('*', Constants.MenuWidth - 5));
            Console.SetCursorPosition(field.Width + 2, 2);
            Console.WriteLine("*                     *");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(field.Width + 6, 2);
            Console.WriteLine("THUNDER FIGHTER");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.SetCursorPosition(field.Width + 2, 3);
            Console.WriteLine(new String('*', Constants.MenuWidth - 5));
            Console.SetCursorPosition(field.Width + 2, 4);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("by Team - Hestia");

            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(field.Width + 2, 10);
            Console.WriteLine("Your score:");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(field.Width + 19, 10);
            Console.WriteLine(string.Format("{0:00000}", engine.scoreBoard.Score));
        }

        private static void WriteSymb(int x, int y, char w, ConsoleColor color)
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
