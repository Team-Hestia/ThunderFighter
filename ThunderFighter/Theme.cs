namespace ThunderFighter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Theme
    {
        public ThemeColor Color { get; set; }

        public static ConsoleColor backGround { get; set; }
        public static ConsoleColor contrast { get; set; }
        public static ConsoleColor light { get; set; }
        public static ConsoleColor red { get; set; }
        public static ConsoleColor green { get; set; }
        public static ConsoleColor blue { get; set; }

        public Theme()
        {
        }

        public Theme(ThemeColor color)
        {
            this.Color = color;
            if (color == ThemeColor.white)
            {
                backGround = ConsoleColor.White;
                contrast = ConsoleColor.Black;
                light = ConsoleColor.Gray;
                red = ConsoleColor.DarkRed;
                green = ConsoleColor.DarkGreen;
                blue = ConsoleColor.Blue;
            }
            else if (color == ThemeColor.black)
            {
                backGround = ConsoleColor.Black;
                contrast = ConsoleColor.White;
                light = ConsoleColor.DarkGray;
                red = ConsoleColor.Red;
                green = ConsoleColor.Green;
                blue = ConsoleColor.Cyan;
            }
            else if (color == ThemeColor.blue)
            {
                backGround = ConsoleColor.DarkBlue;
                contrast = ConsoleColor.Yellow;
                light = ConsoleColor.DarkGray;
                red = ConsoleColor.Red;
                green = ConsoleColor.DarkMagenta;
                blue = ConsoleColor.Magenta;
            }
        }
    }
}
