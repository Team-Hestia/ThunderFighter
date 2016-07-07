namespace ThunderFighter
{
    using System;

    public class Theme
    {
        public Theme(ThemeColor color)
        {
            this.Color = color;
            if (color == ThemeColor.White)
            {
                Theme.BackGround = ConsoleColor.White;
                Theme.Contrast = ConsoleColor.Black;
                Theme.Light = ConsoleColor.Gray;
                Theme.Red = ConsoleColor.DarkRed;
                Theme.Green = ConsoleColor.DarkGreen;
                Theme.Blue = ConsoleColor.Blue;
            }
            else if (color == ThemeColor.Black)
            {
                Theme.BackGround = ConsoleColor.Black;
                Theme.Contrast = ConsoleColor.White;
                Theme.Light = ConsoleColor.DarkGray;
                Theme.Red = ConsoleColor.Red;
                Theme.Green = ConsoleColor.Green;
                Theme.Blue = ConsoleColor.Cyan;
            }
            else if (color == ThemeColor.Blue)
            {
                Theme.BackGround = ConsoleColor.DarkBlue;
                Theme.Contrast = ConsoleColor.Yellow;
                Theme.Light = ConsoleColor.DarkGray;
                Theme.Red = ConsoleColor.Red;
                Theme.Green = ConsoleColor.DarkMagenta;
                Theme.Blue = ConsoleColor.Magenta;
            }
        }

        public static ConsoleColor BackGround { get; set; }

        public static ConsoleColor Contrast { get; set; }

        public static ConsoleColor Light { get; set; }

        public static ConsoleColor Red { get; set; }

        public static ConsoleColor Green { get; set; }

        public static ConsoleColor Blue { get; set; }

        public ThemeColor Color { get; set; }
    }
}
