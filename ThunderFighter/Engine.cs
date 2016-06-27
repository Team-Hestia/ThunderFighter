using ThunderFighter.Controls;

namespace ThunderFighter
{
    using Screens;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;

    internal class Engine
    {
        private readonly ConsoleKeyboardHandler keyboardHandler;

        private readonly WelcomeScreen welcomeScreen;
        private readonly PauseScreen pauseScreen;
        private readonly GameOverScreen gameOverScreen;

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
            this.keyboardHandler = new ConsoleKeyboardHandler();

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

            this.welcomeScreen = new WelcomeScreen(this);
            this.pauseScreen = new PauseScreen(this);
            this.gameOverScreen = new GameOverScreen(this);

            ConsoleKeyboardHandler.Instance.KeyDown += Instance_KeyDown;
        }

        private void Instance_KeyDown(object sender, ConsoleKeyDownEventArgs e)
        {
            if (this.GameStatus == GameStatus.Play)
            {
                if (e.KeyInfo.Key == ConsoleKey.P)
                {
                    this.GameStatus = GameStatus.Pause;
                }
            }
        }

        public GameStatus GameStatus { get; internal set; }

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
                ConsoleKeyboardHandler.Instance.HandleKeys();

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
            this.ResetGame();
            this.welcomeScreen.Show();
        }

        private void ResetGame()
        {
            this.enemies.Clear();
            this.buildings.Clear();
            this.Player = new Fighters.ThunderFighterOne(this.Field, new Point2D(10, 5), EntityState.Strong);
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

        private void Pause()
        {
            this.pauseScreen.Show();
        }

        private void GameOver()
        {
            this.gameOverScreen.Show();
        }

        private void DetectEnemyBulletCollisions()
        {
            for (int i = 0; i < this.enemies.Count; i++)
            {
                for (int j = 0; j < this.Player.Bullets.Count; j++)
                {
                    if (this.enemies[i].State == (int) EntityState.Strong &&
                        this.enemies[i].State == (int) EntityState.Strong &&
                        this.enemies[i].Body
                            .Exists(enemyPixel => this.Player.Bullets[j].Body.Exists(bulletPixel =>
                                enemyPixel.Coordinate.Y == bulletPixel.Coordinate.Y &&
                                0 <= (bulletPixel.Coordinate.X - enemyPixel.Coordinate.X) &&
                                (bulletPixel.Coordinate.X - enemyPixel.Coordinate.X) <= this.Player.Bullets[j].DeltaX)))
                    {
                        this.enemies[i].State = (int) EntityState.HalfDestroyed;
                        this.enemies[i].DeltaX = 0;
                        this.enemies[i].DeltaY = 0;

                        this.Player.Bullets[j].State = (int) EntityState.HalfDestroyed;
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
                if (this.Player.State == (int) EntityState.Strong &&
                    this.enemies[i].State == (int) EntityState.Strong &&
                    this.enemies[i].Body
                        .Exists(enemyPixel => this.Player.Body.Exists(playerPixel =>
                                enemyPixel.Coordinate.Y == playerPixel.Coordinate.Y &&
                                0 <= (playerPixel.Coordinate.X - enemyPixel.Coordinate.X) &&
                                (playerPixel.Coordinate.X - enemyPixel.Coordinate.X) <= Math.Abs(this.enemies[i].DeltaX))))
                {
                    this.Player.State = (int) EntityState.HalfDestroyed;

                    this.enemies[i].State = (int) EntityState.HalfDestroyed;
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

                var randomEnemy = (Enemy) Activator.CreateInstance(
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