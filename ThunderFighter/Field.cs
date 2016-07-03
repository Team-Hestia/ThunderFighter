namespace ThunderFighter
{
    using System;
    using System.Runtime.InteropServices;

    public class Field
    {
        private const int SWP_NOACTIVATE = 0x0010;
        private const int SWP_NOSIZE = 0x0001;
        private const int SWP_NOZORDER = 0x0004;

        private int width;
        private int height;

        public Field(int windowWidth = 60, int windowHeight = 60)
        {
            this.Width = Math.Min(Console.LargestWindowWidth - Constants.MenuWidth, windowWidth);
            this.Height = Math.Min(Console.LargestWindowHeight, windowHeight);

            // The code moves the console window to the top left of your screen
            SetWindowPos(GetConsoleWindow(), 0, 0, 0, 0, 0, SWP_NOACTIVATE | SWP_NOSIZE | SWP_NOZORDER);
            
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            
            Console.WindowWidth = this.Width + Constants.MenuWidth;
            Console.WindowHeight = this.Height;
            Console.BufferWidth = this.Width + Constants.MenuWidth;
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

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        private static extern IntPtr SetWindowPos(
            IntPtr hWnd,
            int handleWndInsertAfter,
            int x,
            int y,
            int cx,
            int cy,
            uint wFlags);
    }
}
