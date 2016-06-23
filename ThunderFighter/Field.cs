namespace ThunderFighter
{
    using System;
    using System.Runtime.InteropServices;

    public class Field : IClearable
    {
        private const int SWP_NOACTIVATE = 0x0010;
        private const int SWP_NOSIZE = 0x0001;
        private const int SWP_NOZORDER = 0x0004;

        private int width;
        private int height;

        public Field(int windowWidth = 60, int windowHeight = 60)
        {
            this.Width = Math.Min(Console.LargestWindowWidth, windowWidth);
            this.Height = Math.Min(Console.LargestWindowHeight, windowHeight);

            // The code moves the console window to the top left of your screen
            SetWindowPos(GetConsoleWindow(), 0, 0, 0, 0, 0, SWP_NOACTIVATE | SWP_NOSIZE | SWP_NOZORDER);

            Console.WindowWidth = this.Width;
            Console.WindowHeight = this.Height;
            Console.BufferWidth = this.Width;
            Console.BufferHeight = this.Height;

            Console.Title = "ThunderFighter by Team Hestia";
            Console.BackgroundColor = ConsoleColor.White;
            Console.CursorVisible = false;
            Console.Clear();
        }

        public int Width
        {
            get
            {
                return this.width;
            }

            private set
            {
                this.width = value;
            }
        }

        public int Height
        {
            get
            {
                return this.height;
            }

            private set
            {
                this.height = value;
            }
        }

        public Point2D Center
        {
            get
            {
                return new Point2D(this.Width / 2, this.Height / 2);
            }
        }

        public void Clear()
        {
            Console.Clear();
        }

        [DllImport("kernel32")]
        private static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        private static extern IntPtr SetWindowPos(
            IntPtr hWnd,
            int hWndInsertAfter,
            int x,
            int y,
            int cx,
            int cy,
            uint wFlags);
    }
}
