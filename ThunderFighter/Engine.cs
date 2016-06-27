namespace ThunderFighter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    internal class Engine
    {
        private MessageBox welcomeMessageBox;
        private MessageBox gameOverMessageBox;
        private MessageBox pauseMessageBox;

        private Field field;
        private Fighter player;
        private GameLevel gameLevel;

        private Type[] playerClassTypes;
        private Type[] enemyClassTypes;
        private Type[] buildingClassTypes;

        private List<Fighter> players;
        private List<Enemy> enemies;
        private List<Building> buildings;

        public Engine(Field field, Fighter player, GameLevel gameLevel)
        {
            this.Field = field;
            this.Player = player;
            this.GameLevel = gameLevel;
            this.GameStatus = GameStatus.Welcome;

            this.PlayerClassTypes = ReflectiveArray.GetTypeOfDerivedClasses<Fighter>();
            this.EnemyClassTypes = ReflectiveArray.GetTypeOfDerivedClasses<Enemy>();
            this.BuildingClassTypes = ReflectiveArray.GetTypeOfDerivedClasses<Building>();

            this.players = new List<Fighter>();
            this.enemies = new List<Enemy>();
            this.buildings = new List<Building>();

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

        public GameStatus GameStatus { get; private set; }

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

        public Type[] PlayerClassTypes
        {
            get
            {
                return this.playerClassTypes;
            }

            private set
            {
                this.playerClassTypes = value;
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

        public Type[] BuildingClassTypes
        {
            get
            {
                return this.buildingClassTypes;
            }

            private set
            {
                this.buildingClassTypes = value;
            }
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

                Thread.Sleep(50);
            }
        }

        private void Welcome()
        {
            this.Clear();

            this.enemies.Clear();
            this.buildings.Clear();

            this.Player = new Fighters.ThunderFighterOne(this.Field, new Point2D(10, 5), EntityState.Strong);

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

                    ScreenBuffer.DrawScreen();
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
            this.Clear();
            this.Move();
            this.CollisionDetection();
            this.Draw();
        }

        private void Clear()
        {
            this.Player.Clear();
            this.EnemiesClear();
            // TODO: this.BuildingsClear();
            this.BulletsClear();
            // TODO: this.BombsClear();
            // TODO: this.MissilesClear();
        }

        private void Move()
        {
            // TODO: The code for keyboard handling should not be in this method. There should be a central KeyboardHandler class.
            this.Player.Move();
            this.EnemiesMove();
            // TODO: this.BuildingsMove();
            this.BulletsMove();
            // TODO: this.BombsMove();
            // TODO: this.MissilesMove();
        }

        private void CollisionDetection()
        {
            // TODO: this.DetectPlayerBulletCollisions();
            this.DetectPlayerEnemyCollisions();

            this.DetectEnemyBulletCollisions();
            // TODO: this.DetectEnemyMissileCollisions();

            // TODO: this.DetectBombBuildingCollisions();
        }

        private void Draw()
        {
            // Draw:
            this.PlayerDraw();
            this.EnemiesDraw();
            // TODO: this.BuildingsDraw();
            this.BulletsDraw();
            // TODO: this.BombsDraw();
            // TODO: this.MissilesDraw();
        }

        // TODO: handle pausing
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

                ScreenBuffer.ClearScreen();

                this.GameStatus = GameStatus.Welcome;
            }
        }

        private void DetectEnemyBulletCollisions()
        {
            for (int i = 0; i < this.enemies.Count; i++)
            {
                for (int j = 0; j < this.Player.Bullets.Count; j++)
                {
                    if (this.enemies[i].State == (int)EntityState.Strong &&
                        this.enemies[i].State == (int)EntityState.Strong &&
                        this.enemies[i].Body
                            .Exists(enemyPixel => this.Player.Bullets[j].Body.Exists(bulletPixel =>
                                enemyPixel.Coordinate.Y == bulletPixel.Coordinate.Y &&
                                0 <= (bulletPixel.Coordinate.X - enemyPixel.Coordinate.X) &&
                                (bulletPixel.Coordinate.X - enemyPixel.Coordinate.X) <= this.Player.Bullets[j].DeltaX)))
                    {
                        this.enemies[i].State = (int)EntityState.HalfDestroyed;
                        this.enemies[i].DeltaX = 0;
                        this.enemies[i].DeltaY = 0;

                        this.Player.Bullets[j].State = (int)EntityState.HalfDestroyed;
                        this.Player.Bullets[j].DeltaX = 0;
                        this.Player.Bullets[j].DeltaY = 0;

                        break;
                    }
                }
            }
        }

        private void DetectPlayerEnemyCollisions()
        {
            for (int i = 0; i < this.enemies.Count; i++)
            {
                if (this.Player.State == (int)EntityState.Strong &&
                    this.enemies[i].State == (int)EntityState.Strong &&
                    this.enemies[i].Body
                        .Exists(enemyPixel => this.Player.Body.Exists(playerPixel =>
                                enemyPixel.Coordinate.Y == playerPixel.Coordinate.Y &&
                                0 <= (playerPixel.Coordinate.X - enemyPixel.Coordinate.X) &&
                                (playerPixel.Coordinate.X - enemyPixel.Coordinate.X) <= Math.Abs(this.enemies[i].DeltaX))))
                {
                    this.Player.State = (int)EntityState.HalfDestroyed;

                    this.enemies[i].State = (int)EntityState.HalfDestroyed;
                    this.enemies[i].DeltaX = 0;
                    this.enemies[i].DeltaY = 0;

                    break;
                }
            }
        }

        private void PlayerDraw()
        {
            this.Player.Draw();

            if (this.Player.IsDestroyed)
            {
                this.GameStatus = GameStatus.GameOver;
            }
        }

        private void EnemiesClear()
        {
            for (int i = 0; i < this.enemies.Count; i++)
            {
                this.enemies[i].Clear();

                if (this.enemies[i].IsDestroyed)
                {
                    this.enemies.RemoveAt(i);
                    i--;

                    ScreenBuffer.DrawScreen();
                }
            }
        }

        private void EnemiesMove()
        {
            for (int i = 0; i < this.enemies.Count; i++)
            {
                this.enemies[i].Move();

                if (this.enemies[i].Body.All(pixel => pixel.Coordinate.X < 0))
                {
                    this.enemies.RemoveAt(i);
                    i--;
                }
            }

            this.SpawnNewEnemy();
        }

        private void EnemiesDraw()
        {
            for (int i = 0; i < this.enemies.Count; i++)
            {
                this.enemies[i].Draw();
            }
        }

        private void SpawnNewEnemy()
        {
            int indexOfRandomEnemyClass = RandomProvider.Instance.Next(0, this.EnemyClassTypes.Count());

            // TODO: use gameLevel instead of 7
            while (this.enemies.Count < 7)
            {
                // TODO: use enemy width and height
                int x = RandomProvider.Instance.Next(this.Field.Width, 2 * this.Field.Width);
                int y = RandomProvider.Instance.Next(2, this.Field.Height - 3);

                var randomEnemy = (Enemy)Activator.CreateInstance(
                    this.EnemyClassTypes[indexOfRandomEnemyClass],
                    this.Field,
                    new Point2D(x, y),
                    EntityState.Strong);

                if (this.enemies.Exists(enemy => enemy.Body.Exists(pixel => randomEnemy.Body.Exists(newEnemyPixel => newEnemyPixel.Coordinate == pixel.Coordinate))))
                {
                    continue;
                }
                else
                {
                    this.enemies.Add(randomEnemy);
                    indexOfRandomEnemyClass = RandomProvider.Instance.Next(0, this.EnemyClassTypes.Count());
                }
            }
        }

        private void BulletsClear()
        {
            for (int i = 0; i < this.Player.Bullets.Count; i++)
            {
                this.Player.Bullets[i].Clear();

                if (this.Player.Bullets[i].IsDestroyed)
                {
                    this.Player.Bullets.RemoveAt(i);
                    i--;

                    ScreenBuffer.DrawScreen();
                }
            }
        }

        private void BulletsMove()
        {
            for (int i = 0; i < this.Player.Bullets.Count; i++)
            {
                this.Player.Bullets[i].Move();

                if (this.Player.Bullets[i].Body.All(pixel => pixel.Coordinate.X > this.Field.Width - 1))
                {
                    this.Player.Bullets.RemoveAt(i);
                    i--;
                }
            }
        }

        private void BulletsDraw()
        {
            for (int i = 0; i < this.Player.Bullets.Count; i++)
            {
                this.Player.Bullets[i].Draw();
            }
        }
    }
}
