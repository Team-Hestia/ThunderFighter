namespace ThunderFighter.Sidebar
{
    using System;
    using System.Collections.Generic;

    internal class Menu
    {
        private Field field;
        private Engine engine;

        public Menu(Field field, Engine engine, ScoreBoard scores)
        {
            this.Engine = engine;
            this.Field = field;
            this.ScoreBoard = scores;
        } 

        public void CreateBase()
        {
            int right = this.field.PlayWidth + 2;

            // Heading
            ScreenBuffer.Draw(right, 1, new String('*', Constants.MenuWidth - 5), ConsoleColor.Gray);
            ScreenBuffer.Draw(right, 2, String.Format("*{0}*", new string(' ', Constants.MenuWidth - 7)), ConsoleColor.Gray);
            ScreenBuffer.Draw(right + 4, 2, "THUNDER FIGHTER", ConsoleColor.Blue);
            ScreenBuffer.Draw(right, 3, new String('*', Constants.MenuWidth - 5), ConsoleColor.Gray);
            ScreenBuffer.Draw(right, 4, "by Team - Hestia", ConsoleColor.DarkGray);

            // Game info
            ScreenBuffer.Draw(right, 7, "Game info:", ConsoleColor.Blue);
            for (int k = 9; k < 14; k++)
            {
                ScreenBuffer.Draw(right, k, "*", ConsoleColor.Gray);
                ScreenBuffer.Draw(right + Constants.MenuWidth - 6, k, "*", ConsoleColor.Gray);
            }
            ScreenBuffer.Draw(right, 8, new String('*', Constants.MenuWidth - 5), ConsoleColor.Gray);
            ScreenBuffer.Draw(right + 4, 9, "Lives:", ConsoleColor.Black);
            ScreenBuffer.Draw(right + 4, 11, "Score:", ConsoleColor.Black);
            ScreenBuffer.Draw(right + 4, 13, "Level:", ConsoleColor.Black);
            ScreenBuffer.Draw(right, 14, new String('*', Constants.MenuWidth - 5), ConsoleColor.Gray);

            // Controls block
            ScreenBuffer.Draw(right, 16, "Controls:", ConsoleColor.Blue);
            for (int k = 18; k < 26; k++)
            {
                ScreenBuffer.Draw(right, k, "*", ConsoleColor.Gray);
                ScreenBuffer.Draw(right + Constants.MenuWidth - 6, k, "*", ConsoleColor.Gray);
            }
            ScreenBuffer.Draw(right, 17, new String('*', Constants.MenuWidth - 5), ConsoleColor.Gray);
            ScreenBuffer.Draw(right + 4, 18, "<     - Left", ConsoleColor.Black);
            ScreenBuffer.Draw(right + 4, 19, ">     - Right", ConsoleColor.Black);
            ScreenBuffer.Draw(right + 4, 20, "^     - Up", ConsoleColor.Black);
            ScreenBuffer.Draw(right + 4, 21, "v     - Down", ConsoleColor.Black);
            ScreenBuffer.Draw(right + 2, 22, "Space   - Shoot", ConsoleColor.Black);
            ScreenBuffer.Draw(right + 4, 23, "B     - Bomb", ConsoleColor.Black);
            ScreenBuffer.Draw(right + 4, 24, "P     - Pause", ConsoleColor.Black);
            ScreenBuffer.Draw(right + 4, 25, "ESC   - Exit", ConsoleColor.Black);
            ScreenBuffer.Draw(right, 26, new String('*', Constants.MenuWidth - 5), ConsoleColor.Gray);

            // Statistics block
            ScreenBuffer.Draw(right, 28, "Statistics:", ConsoleColor.Blue);
            for (int k = 30; k < 38; k++)
            {
                ScreenBuffer.Draw(right, k, "*", ConsoleColor.Gray);
                ScreenBuffer.Draw(right + Constants.MenuWidth - 6, k, "*", ConsoleColor.Gray);
            }
            ScreenBuffer.Draw(right, 29, new String('*', Constants.MenuWidth - 5), ConsoleColor.Gray);
            ScreenBuffer.Draw(right + 2, 30, "Games played:", ConsoleColor.Black);
            ScreenBuffer.Draw(right + 2, 31, "High score:", ConsoleColor.Black);
            ScreenBuffer.Draw(right + 2, 32, "Total time:", ConsoleColor.Black);
            ScreenBuffer.Draw(right, 38, new String('*', Constants.MenuWidth - 5), ConsoleColor.Gray);
        }

        public void DisplayInfo()
        {
            ScreenBuffer.Draw(this.field.PlayWidth + 15, 9, string.Format("{0}", this.ScoreBoard.Lives), ConsoleColor.Red);
            ScreenBuffer.Draw(this.field.PlayWidth + 15, 11, string.Format("{0}", this.ScoreBoard.Score), ConsoleColor.Red);
            ScreenBuffer.Draw(this.field.PlayWidth + 15, 13, string.Format("{0}", this.Engine.GameLevel), ConsoleColor.DarkGreen);
            ScreenBuffer.Draw(this.field.PlayWidth + 18, 30, string.Format("{0}", this.Engine.GameCounter), ConsoleColor.DarkGreen);
            ScreenBuffer.Draw(this.field.PlayWidth + 18, 31, string.Format("{0}", this.ScoreBoard.HighScore), ConsoleColor.DarkGreen);
            ScreenBuffer.Draw(this.field.PlayWidth + 18, 32, string.Format("{0:00}:{1:00}", this.Engine.Timer.Minutes, this.Engine.Timer.Seconds), ConsoleColor.DarkGreen);
        }

        public void ClearInfo()
        {   // need to change numbers with variables/constants
            for (int i = 9; i < 13; i++)
            {
                for (int j = 15; j < 23; j++)
                {
                    ScreenBuffer.Clear(this.field.PlayWidth + j, i);
                    if (i + 21 < 33 && j < 21)
                    {
                        ScreenBuffer.Clear(this.field.PlayWidth + j + 2, i + 21);
                    }
                }
            }
        }

        public ScoreBoard ScoreBoard { get; set; }

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

        public Engine Engine
        {
            get
            {
                return this.engine;
            }

            private set
            {
                this.engine = value;
            }
        }
    }
}
