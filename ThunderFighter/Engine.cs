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

        private Type[] enemyClassTypes;

        /* Enemies info */
        private static List<Enemy> enemies = new List<Enemy>();

        /* Bullets info */
        public static List<Bullet> bullets = new List<Bullet>();

        public Engine(Field field, Fighter player, GameLevel gameLevel)
        {
            this.Field = field;
            this.Player = player;
            this.GameLevel = gameLevel;

            this.EnemyClassTypes = ReflectiveArray.GetTypeOfDerivedClasses<Enemy>();

            while (true)
            {
                // Clear:
                this.player.Clear();
                this.EnemiesClear();
                this.BulletsClear();
                // clear bombs
                // clear missiles

                // Update:
                this.player.Move();
                this.EnemiesMove();
                this.BulletsMove();
                // update bombs
                // update missiles

                // Collision Detection:
                this.DetectEnemyBulletCollisions();
                // check Enemies-Missiles collisions
                // check Enemies-Player collisions
                // check Bombs-Buildings collisions

                // Draw:
                this.player.Draw();
                this.EnemiesDraw();
                this.BulletsDraw();
                // draw bombs
                // draw missiles

                Thread.Sleep(90);
            }
        }

        private void DetectEnemyBulletCollisions()
        {
            for (int i = 0; i < Engine.enemies.Count; i++)
            {
                for (int j = 0; j < Engine.bullets.Count; j++)
                {
                    if (Engine.enemies[i].Body
                        .Exists(enemyPixel => Engine.bullets[j].Body.Exists(bulletPixel =>
                            bulletPixel.Coordinate == enemyPixel.Coordinate ||
                            (bulletPixel.Coordinate.Y == enemyPixel.Coordinate.Y &&
                             (bulletPixel.Coordinate.X - 1) == enemyPixel.Coordinate.X) ||
                            (bulletPixel.Coordinate.Y == enemyPixel.Coordinate.Y &&
                             (bulletPixel.Coordinate.X - 2) == enemyPixel.Coordinate.X))))
                    {
                        Engine.enemies[i].IsDestroyed = true;
                        Engine.bullets[j].IsDestroyed = true;

                        // TODO: refactor this (we need to draw crashed enemy)
                        Engine.enemies.RemoveAt(i);
                        i--;
                        Engine.bullets.RemoveAt(j);
                        j--;

                        break;
                    }
                }
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
                if (!enemy.IsDestroyed) // TODO: Draw() must be refactored a lot
                {
                    enemy.Draw();
                }
            }
        }

        private void SpawnNewEnemy()
        {
            int indexOfRandomEnemyClass = rand.Next(0, this.EnemyClassTypes.Count());

            while (Engine.enemies.Count < 7) //TODO: use gameLevel
            {
                // TODO: use enemy width and height
                int x = rand.Next(this.Field.Width, 2 * this.Field.Width);
                int y = rand.Next(2, this.Field.Height - 3);

                var randomEnemy = (Enemy)Activator.CreateInstance(
                    this.EnemyClassTypes[indexOfRandomEnemyClass],
                    this.Field,
                    new Point2D(x, y));

                if (Engine.enemies.Exists(enemy => enemy.Body.Exists(pixel => randomEnemy.Body.Exists(newEnemyPixel => newEnemyPixel.Coordinate == pixel.Coordinate))))
                {
                    continue;
                }
                else
                {
                    enemies.Add(randomEnemy);
                    indexOfRandomEnemyClass = rand.Next(0, this.EnemyClassTypes.Count());
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
                if (!bullet.IsDestroyed) // TODO: Draw() must be refactored a lot
                {
                    bullet.Draw();
                }
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

        public Type[] EnemyClassTypes
        {
            get
            {
                return this.enemyClassTypes;
            }

            private set
            {
                this.enemyClassTypes = value;
            }
        }
    }
}
