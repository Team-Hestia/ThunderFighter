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
        private Enemy enemy;

        public Engine(Field field, Fighter player, Enemy enemy)
        {
            this.Field = field;
            this.Player = player;
            this.Enemy = enemy;

            while (true)
            {
                // Clear:
                // clear player
                enemy.Clear();
                // clear bullets
                // clear bombs
                player.Clear();

                // Collision Detection:
                // check Enemies-Bullets collisions
                // check Enemies-Player collisions
                // check Bombs-Buildings collisions

                // Update:
                // update player
                enemy.Move();
                // update bullets
                // update bombs
                player.Move();

                // Draw:
                // draw player
                enemy.Draw();
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

        public Enemy Enemy
        {
            get
            {
                return this.enemy;
            }

            private set
            {
                this.enemy = value;
            }
        }
    }
}
