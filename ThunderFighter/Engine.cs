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
        public GameStatus GameStatus { get; set; }

        private MessageBox welcomeMessageBox;
        private MessageBox gameOverMessageBox;
        private MessageBox pauseMessageBox;

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

            this.welcomeMessageBox = new MessageBox(
                this.field,
                "Welcome to THUNDER FIGHTER!\nPress ENTER to start or ESC to exit...",
                MessageBoxDrawing.DrawCentered,
                MessageBoxTextAlignment.Center);

            this.pauseMessageBox = new MessageBox(
                this.field,
                "PAUSE!\nPress any key to continue...",
                MessageBoxDrawing.DrawCentered,
                MessageBoxTextAlignment.Center);

            this.gameOverMessageBox = new MessageBox(
                this.field,
                "GAME OVER!\nPress any key to continue...",
                MessageBoxDrawing.DrawCentered,
                MessageBoxTextAlignment.Center);
        }

        public void Start()
        {
            while (true)
            {
                switch (this.GameStatus)
                {
                    case GameStatus.Welcome:
                        this.Welcome();
                        break;

                    case GameStatus.Play:
                        this.Play();
                        break;

                    case GameStatus.Pause:
                        this.Pause();
                        break;

                    case GameStatus.GameOver:
                        this.GameOver();
                        break;

                    case GameStatus.TopScores:
                        break;

                    default:
                        break;
                }

                Thread.Sleep(90);
            }
        }

        private void Welcome()
        {
            this.player.Clear();
            this.EnemiesClear();
            this.BulletsClear();

            this.player = new Fighter(this.Field, new Point2D(10, 5));
            enemies.Clear();
            bullets.Clear();

            this.welcomeMessageBox.Draw();
            this.HandleWelcomeKeys();
        }

        private void HandleWelcomeKeys()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo userInput = Console.ReadKey();

                if (userInput.Key == ConsoleKey.Enter)
                {
                    this.welcomeMessageBox.Clear();
                    this.GameStatus = GameStatus.Play;
                }
                else if (userInput.Key == ConsoleKey.Escape)
                {
                    Console.WriteLine("\n\nIf you see this it is because you've run the application with a debuger attached! Run the exe file outside Visual Studio.");
                    Environment.Exit(0);
                }
            }
        }

        private void Play()
        {
            // Clear:
            this.player.Clear();
            this.EnemiesClear();
            this.BulletsClear();
            // clear bombs
            // clear missiles

            // Update:
            // TODO: The code for keyboard handling should not be in this method. There should be a central KeyboardHandler class.
            this.player.Move(); 
            this.EnemiesMove();
            this.BulletsMove();
            // update bombs
            // update missiles

            // Collision Detection:
            this.DetectEnemyBulletCollisions();
            this.DetectPlayerEnemyCollision();
            // check Enemies-Missiles collisions
            // check Enemies-Player collisions
            // check Bombs-Buildings collisions

            // Draw:
            this.player.Draw();
            this.EnemiesDraw();
            this.BulletsDraw();
            // draw bombs
            // draw missiles
        }

        // TODO:
        //private void HandlePausing()
        //{
        //    if (Console.KeyAvailable)
        //    {
        //        ConsoleKeyInfo userInput = Console.ReadKey(true);

        //        if (userInput.Key == ConsoleKey.P)
        //        {
        //            this.GameStatus = GameStatus.Pause;
        //        }
        //    }
        //}

        private void Pause()
        {
            this.pauseMessageBox.Draw();
            this.HandlePauseKeys();
        }

        private void HandlePauseKeys()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo userInput = Console.ReadKey(true);

                this.gameOverMessageBox.Clear();
                this.GameStatus = GameStatus.Play;
            }
        }

        private void GameOver()
        {
            this.gameOverMessageBox.Draw();
            this.HandleGameOverKeys();
        }

        private void HandleGameOverKeys()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo userInput = Console.ReadKey(true);

                this.gameOverMessageBox.Clear();
                this.GameStatus = GameStatus.Welcome;
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

        private void DetectPlayerEnemyCollision()
        {
            for (int i = 0; i < Engine.enemies.Count; i++)
            {
                if (Engine.enemies[i].Body
                        .Exists(enemyPixel => this.Player.Body.Exists(playerPixel =>
                            playerPixel.Coordinate == enemyPixel.Coordinate ||
                            (playerPixel.Coordinate.Y == enemyPixel.Coordinate.Y &&
                             (playerPixel.Coordinate.X - 1) == enemyPixel.Coordinate.X) ||
                            (playerPixel.Coordinate.Y == enemyPixel.Coordinate.Y &&
                             (playerPixel.Coordinate.X - 2) == enemyPixel.Coordinate.X))))
                {
                    Engine.enemies[i].IsDestroyed = true;

                    // TODO: refactor this (we need to draw crashed enemy)
                    Engine.enemies.RemoveAt(i);
                    i--;

                    this.Player.IsDestroyed = true;
                    this.GameStatus = GameStatus.GameOver;

                    break;
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

                var randomEnemy = (Enemy) Activator.CreateInstance(
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
