namespace ThunderFighter
{
    using System;

    public class Pixel : IDrawable, IClearable
    {
        private Point2D coordinate;
        private char symbol;
        private ConsoleColor color;

        public Pixel(int x, int y, char symbol, ConsoleColor color)
        {
            this.Coordinate = new Point2D(x, y);
            this.Symbol = symbol;
            this.Color = color;
        }

        public Point2D Coordinate
        {
            get
            {
                return this.coordinate;
            }

            internal set
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

            internal set
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

            internal set
            {
                this.color = value;
            }
        }

        public static void Clear(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(' ');
        }

        public static void Clear(int x, int y, string text)
        {
            Pixel.Draw(x, y, new string(' ', text.Length), ConsoleColor.Gray);
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

        public void Clear()
        {
            Pixel.Clear(this.Coordinate.X, this.Coordinate.Y);
        }

        public void Draw()
        {
            Pixel.Draw(this.Coordinate.X, this.Coordinate.Y, this.Symbol, this.Color);
        }
    }
}
