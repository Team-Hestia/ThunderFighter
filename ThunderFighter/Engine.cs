namespace ThunderFighter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    class Engine
    {
        private Field field;
        private Fighter player;

        public Engine(Field field, Fighter player)
        {
            this.Field = field;
            this.Player = player;

            while (true)
            {
                // Clear:
                // clear player
                // clear enemies
                // clear bullets
                // clear bombs
                player.Clear();

                // Collision Detection:
                // check Enemies-Bullets collisions
                // check Enemies-Player collisions
                // check Bombs-Buildings collisions

                // Update:
                // update player
                // update enemies
                // update bullets
                // update bombs
                player.Move();

                // Draw:
                // draw player
                // draw enemies
                // draw bullets
                // draw bombs
                player.Draw();

                Thread.Sleep(90);
            }
        }

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

        public Fighter Player
        {
            get
            {
                return this.player;
            }

            private set
            {
                this.player = value;
            }
        }
    }
}
