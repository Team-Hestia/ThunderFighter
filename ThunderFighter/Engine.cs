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
        private FighterEnemy killerWing;

        /* Enemies info */
        private static List<Enemy> enemies = new List<Enemy>();

        /* Bullets info */
        public static List<Bullet> bullets = new List<Bullet>();

        public Engine(Field field, Fighter player, FighterEnemy killerWing)
        {
            this.Field = field;
            this.Player = player;
            this.KillerWing = killerWing; // bad shooter guy

            while (true)
            {
                // Clear:
                this.player.Clear();
                // clear enemies
                this.killerWing.Clear();
                this.BulletsClear();
                // clear bombs

                // Collision Detection:
                // check Enemies-Bullets collisions
                // check Enemies-Player collisions
                // check Bombs-Buildings collisions

                // Update:
                this.player.Move();
                // update enemies
                this.killerWing.Move();
                this.BulletsMove();
                // update bombs

                // Draw:
                this.player.Draw();
                // draw enemies
                this.killerWing.Draw();
                this.BulletsDraw();
                // draw bombs

                Thread.Sleep(90);
            }
        }

        private void BulletsClear()
        {
            foreach (var bullet in Engine.bullets)
            {
                bullet.Clear();
            }
        }

        private void BulletsMove()
        {
            for (int i = 0; i < Engine.bullets.Count; i++)
            {
                Engine.bullets[i].Move();
                if (Engine.bullets[i].Body.All(pixel => pixel.Coordinate.X > this.Field.Width - 1))
                {
                    Engine.bullets.RemoveAt(i);
                    i--;
                }
            }
        }

        private void BulletsDraw()
        {
            foreach (var bullet in Engine.bullets)
            {
                bullet.Draw();
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

        public FighterEnemy KillerWing
        {
            get
            {
                return this.killerWing;
            }

            private set
            {
                this.killerWing = value;
            }
        }
    }
}
