using System;
using System.Linq;

namespace ThunderFighter.Controls
{
    public class ConsoleKeyboardHandler
    {
        private static readonly ConsoleKeyboardHandler instance;

        static ConsoleKeyboardHandler()
        {
            instance = new ConsoleKeyboardHandler();
        }

        public ConsoleKeyboardHandler()
        {
        }

        public static ConsoleKeyboardHandler Instance
        {
            get
            {
                return instance;
            }
        }

        public void HandleKeys()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                while (Console.KeyAvailable)
                {
                    Console.ReadKey(true);
                }

                this.OnKeyDown(new ConsoleKeyDownEventArgs(keyInfo));
            }
        }

        public event EventHandler<ConsoleKeyDownEventArgs> KeyDown;
        protected virtual void OnKeyDown(ConsoleKeyDownEventArgs args)
        {
            this.KeyDown?.Invoke(this, args);
        }
    }
}