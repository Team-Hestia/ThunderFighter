namespace ThunderFighter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Pixel : IDraw, IClear
    {
        private Point2D coordinate;
        private char symbol;
        private ConsoleColor color;

        public Point2D Coordinate
        {
            get
            {
                return this.coordinate;
            }

            set
            {
                this.coordinate = value;
            }
        }

        public char Symbol
        {
            get
            {
                return this.symbol;
            }

            set
            {
                this.symbol = value;
            }
        }

        public ConsoleColor Color
        {
            get
            {
                return this.color;
            }

            set
            {
                this.color = value;
            }
        }

        public Pixel(int x, int y, char symbol, ConsoleColor color)
        {
            this.Coordinate = new Point2D(x, y);
            this.Symbol = symbol;
            this.Color = color;
        }

        public void Clear()
        {
            Pixel.Clear(this.Coordinate.X, this.Coordinate.Y);
        }

        public static void Clear(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(' ');
        }

        public static void Clear(int x, int y, string text)
        {
            Pixel.Draw(x, y, new String(' ', text.Length), ConsoleColor.Gray);
        }

        public void Draw()
        {
            Pixel.Draw(this.Coordinate.X, this.Coordinate.Y, this.Symbol, this.Color);
        }

        public static void Draw(int x, int y, char symbol, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(x, y);
            Console.Write(symbol);
        }

        public static void Draw(int x, int y, string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(x, y);
            Console.Write(text);
        }
    }
}
