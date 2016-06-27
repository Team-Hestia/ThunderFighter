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
            ScreenBuffer.Clear(x, y);
        }

        public static void Clear(int x, int y, string text)
        {
            ScreenBuffer.Clear(x, y, text);
        }

        public static void Draw(int x, int y, char symbol, ConsoleColor foregroundColor)
        {
            ScreenBuffer.Draw(x, y, symbol, foregroundColor);
        }

        public static void Draw(int x, int y, string text, ConsoleColor foregroundColor)
        {
            ScreenBuffer.Draw(x, y, text, foregroundColor);
        }

        public void Clear()
        {
            ScreenBuffer.Clear(this.Coordinate.X, this.Coordinate.Y);
        }

        public void Draw()
        {
            ScreenBuffer.Draw(this.Coordinate.X, this.Coordinate.Y, this.Symbol, this.Color);
        }
    }
}
