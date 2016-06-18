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
        private static Random rand = new Random();

        private Field field;
        private Fighter player;
        private GameLevel gameLevel;

        /* Enemies info */
        private static List<Enemy> enemies = new List<Enemy>();

        /* Bullets info */
        public static List<Bullet> bullets = new List<Bullet>();

        public Engine(Field field, Fighter player, GameLevel gameLevel)
        {
            this.Field = field;
            this.Player = player;
            this.GameLevel = gameLevel;

            while (true)
            {
                // Clear:
                this.player.Clear();
                this.EnemiesClear();
                this.BulletsClear();
                // clear bombs
                // clear missiles

                // Collision Detection:
                // check Enemies-Bullets collisions
                // check Enemies-Missiles collisions
                // check Enemies-Player collisions
                // check Bombs-Buildings collisions

                // Update:
                this.player.Move();
                this.EnemiesMove();
                this.BulletsMove();
                // update bombs
                // update missiles

                // Draw:
                this.player.Draw();
                this.EnemiesDraw();
                this.BulletsDraw();
                // draw bombs
                // draw missiles

                Thread.Sleep(90);
            }
        }

        private void EnemiesClear()
        {
            foreach (var enemy in Engine.enemies)
            {
                enemy.Clear();
            }
        }

        private void EnemiesMove()
        {
            for (int i = 0; i < Engine.enemies.Count; i++)
            {
                Engine.enemies[i].Move();
                if (Engine.enemies[i].Body.All(pixel => pixel.Coordinate.X < 0))
                {
                    Engine.enemies.RemoveAt(i);
                    i--;
                }
            }

            this.SpawnNewEnemy();
        }

        private void EnemiesDraw()
        {
            foreach (var enemy in Engine.enemies)
            {
                enemy.Draw();
            }
        }

        private void SpawnNewEnemy()
        {
            while (Engine.enemies.Count < 7) //TODO: use gameLevel
            {
                // TODO: use enemy width and height
                int x = rand.Next(this.Field.Width, 2 * this.Field.Width);
                int y = rand.Next(2, this.Field.Height - 3);

                var newEnemy = new KillerWingEnemy(this.Field, new Point2D(x, y));

                if (Engine.enemies.Exists(enemy => enemy.Body.Exists(pixel => newEnemy.Body.Exists(newEnemyPixel => newEnemyPixel.Coordinate == pixel.Coordinate))))
                {
                    continue;
                }
                else
                {
                    enemies.Add(newEnemy);
                    break;
                }
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

        public GameLevel GameLevel
        {
            get
            {
                return this.gameLevel;
            }

            private set
            {
                this.gameLevel = value;
            }
        }
    }
}
