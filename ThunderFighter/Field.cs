namespace ThunderFighter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading.Tasks;

    class Field : IDraw, IClear
    {
        private int width;
        private int height;
        /*
        const int SWP_NOZORDER = 0x4;
        const int SWP_NOACTIVATE = 0x10;

        [DllImport("kernel32")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        public static extern IntPtr SetWindowPos(
            IntPtr hWnd, 
            int hWndInsertAfter, 
            int x, 
            int Y, 
            int cx, 
            int cy, 
            uint wFlags);
            */
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

        public Field(int windowWidth = 60, int windowHeight = 60)
        {
            this.Width = Math.Min(Console.LargestWindowWidth, windowWidth);
            this.Height = Math.Min(Console.LargestWindowHeight, windowHeight);

            // The code moves the console window to the top left of your screen
            //SetWindowPos(GetConsoleWindow(), 0, 0, 0, 0, 0, SWP_NOZORDER | SWP_NOACTIVATE);

            Console.WindowWidth = this.Width;
            Console.WindowHeight = this.Height;
            Console.BufferWidth = this.Width;
            Console.BufferHeight = this.Height;

            Console.Title = "ThunderFighter by Team Hestia";
            Console.BackgroundColor = ConsoleColor.White;
            Console.CursorVisible = false;
            Console.Clear();
        }

        public void Draw()
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            Console.Clear();
        }
    }
}
