namespace ThunderFighter
{
    using Sidebar;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using ThunderFighter.Controls;
    using ThunderFighter.Screens;

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

        private ulong counter;

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

            this.counter = 0;

            this.welcomeScreen = new WelcomeScreen(this);
            this.pauseScreen = new PauseScreen(this);
            this.gameOverScreen = new GameOverScreen(this);
            
            ConsoleKeyboardHandler.Instance.KeyDown += this.Instance_KeyDown;
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

            this.counter++;
        }

        private void Clear()
        {
            this.Player.Clear();
            this.EnemiesClear();
            this.BuildingsClear();
            this.BulletsClear();
            this.BombsClear();
            // TODO: this.MissilesClear();
        }

        private void Move()
        {
            this.Player.Move();
            this.EnemiesMove();
            this.BuildingsMove();
            this.BulletsMove();
            this.BombsMove();
            // TODO: this.MissilesMove();
        }

        private void CollisionDetection()
        {
            // TODO: this.DetectPlayerBulletCollisions();
            this.DetectPlayerEnemyCollisions();

            this.DetectEnemyBulletCollisions();
            // TODO: this.DetectEnemyMissileCollisions();

            this.DetectBuildingBombCollisions();
        }

        private void Draw()
        {
            this.PlayerDraw();
            this.EnemiesDraw();
            this.BuildingsDraw();
            this.BulletsDraw();
            this.BombsDraw();
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
                    if (this.enemies[i].State == (int)EntityState.Strong &&
                        this.Player.Bullets[j].State == (int)EntityState.Strong &&
                        this.enemies[i].Body
                            .Exists(enemyPixel => this.Player.Bullets[j].Body.Exists(bulletPixel =>
                                enemyPixel.Coordinate.Y == bulletPixel.Coordinate.Y &&
                                0 <= (bulletPixel.Coordinate.X - enemyPixel.Coordinate.X) &&
                                (bulletPixel.Coordinate.X - enemyPixel.Coordinate.X) <= this.Player.Bullets[j].DeltaX)))
                    {
                        this.enemies[i].State = (int)EntityState.HalfDestroyed;
                        this.enemies[i].DeltaX = 0;
                        this.enemies[i].DeltaY = 0;
                        this.enemies[i].IsShootingEnabled = false;

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

        private void DetectBuildingBombCollisions()
        {
            for (int i = 0; i < this.buildings.Count; i++)
            {
                for (int j = 0; j < this.Player.Bombs.Count; j++)
                {
                    if (this.buildings[i].State == (int)EntityState.Strong &&
                        this.Player.Bombs[j].State == (int)EntityState.Strong &&
                        this.buildings[i].Body
                            .Exists(buildingPixel => this.Player.Bombs[j].Body.Exists(bombPixel =>
                                (buildingPixel.Coordinate.X == bombPixel.Coordinate.X &&
                                0 <= (bombPixel.Coordinate.Y - buildingPixel.Coordinate.Y) &&
                                (bombPixel.Coordinate.Y - buildingPixel.Coordinate.Y) <= this.buildings[i].Height))))
                    {
                        this.buildings[i].State = (int)EntityState.HalfDestroyed;

                        this.Player.Bombs[j].State = (int)EntityState.HalfDestroyed;
                        this.Player.Bombs[j].DeltaY = 0;

                        break;
                    }
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
                    if (this.enemies[i].Bullets.All(bullet => bullet.Body.All(pixel => pixel.Coordinate.X < 0)))
                    {
                        Enemy.BulletsEngaged -= (uint)this.enemies[i].Bullets.Count;

                        this.enemies.RemoveAt(i);
                        i--; 
                    }
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

            // TODO: use gameLevel instead of 3
            while (this.enemies.Count < 3)
            {
                // TODO: use enemy width and height
                int x = RandomProvider.Instance.Next(this.Field.Width, 2 * this.Field.Width);
                int y = RandomProvider.Instance.Next(2, this.Field.Height - 10);

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

        private void BuildingsClear()
        {
            for (int i = 0; i < this.buildings.Count; i++)
            {
                this.buildings[i].Clear();

                if (this.buildings[i].IsDestroyed)
                {
                    this.buildings.RemoveAt(i);
                    i--;
                }
            }
        }

        private void BuildingsMove()
        {
            for (int i = 0; i < this.buildings.Count; i++)
            {
                this.buildings[i].Move();

                if (this.buildings[i].Body.All(pixel => pixel.Coordinate.X < 0))
                {
                    this.buildings.RemoveAt(i);
                    i--;
                }
            }

            this.SpawnNewBuilding();
        }

        private void BuildingsDraw()
        {
            for (int i = 0; i < this.buildings.Count; i++)
            {
                this.buildings[i].Draw();
            }
        }

        private void SpawnNewBuilding()
        {
            int indexOfRandomBuildingClass = RandomProvider.Instance.Next(0, this.BuildingClassTypes.Count());

            // TODO: use some constant or enum instead of 5
            while (this.buildings.Count < 5 && this.counter % (ulong)Math.Ceiling(1 / Math.Abs(Building.DeltaX)) == 1)
            {
                // TODO: use building width
                int x = RandomProvider.Instance.Next(
                    this.Field.Width,
                    this.Field.Width + (int)(0.5 * this.Field.Width));
                int y = this.Field.Height - 1;

                var randomBuilding = (
                    Building)Activator.CreateInstance(
                    this.BuildingClassTypes[indexOfRandomBuildingClass],
                    this.Field,
                    new Point2D(x, y),
                    EntityState.Strong);

                if (this.buildings.Exists(building => building.Body.Exists(pixel => randomBuilding.Body.Exists(newBuildingPixel => (newBuildingPixel.Coordinate.Y == pixel.Coordinate.Y) && (newBuildingPixel.Coordinate.X - pixel.Coordinate.X) <= 0))))
                {
                    break;
                }
                else
                {
                    this.buildings.Add(randomBuilding);
                    indexOfRandomBuildingClass = RandomProvider.Instance.Next(0, this.BuildingClassTypes.Count());
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
                }
            }

            for (int i = 0; i < this.enemies.Count; i++)
            {
                for (int j = 0; j < this.enemies[i].Bullets.Count; j++)
                {
                    this.enemies[i].Bullets[j].Clear();

                    if (this.enemies[i].Bullets[j].IsDestroyed)
                    {
                        this.enemies[i].Bullets.RemoveAt(j);
                        j--;

                        Enemy.BulletsEngaged--;
                    }
                }
            }
        }

        private void BulletsMove()
        {
            for (int i = 0; i < this.Player.Bullets.Count; i++)
            {
                this.Player.Bullets[i].Move();

                if (this.Player.Bullets[i].Body.All(pixel => pixel.Coordinate.X >= this.Field.Width))
                {
                    this.Player.Bullets.RemoveAt(i);
                    i--;
                }
            }

            for (int i = 0; i < this.enemies.Count; i++)
            {
                for (int j = 0; j < this.enemies[i].Bullets.Count; j++)
                {
                    this.enemies[i].Bullets[j].Move();

                    if (this.enemies[i].Bullets[j].Body.All(pixel => pixel.Coordinate.X < 0))
                    {
                        this.enemies[i].Bullets.RemoveAt(j);
                        j--;

                        Enemy.BulletsEngaged--;
                    }
                }
            }
        }

        private void BulletsDraw()
        {
            for (int i = 0; i < this.Player.Bullets.Count; i++)
            {
                this.Player.Bullets[i].Draw();
            }

            for (int i = 0; i < this.enemies.Count; i++)
            {
                for (int j = 0; j < this.enemies[i].Bullets.Count; j++)
                {
                    this.enemies[i].Bullets[j].Draw();
                }
            }
        }

        private void BombsClear()
        {
            for (int i = 0; i < this.Player.Bombs.Count; i++)
            {
                this.Player.Bombs[i].Clear();

                if (this.Player.Bombs[i].IsDestroyed)
                {
                    this.Player.Bombs.RemoveAt(i);
                    i--;
                }
            }
        }

        private void BombsMove()
        {
            for (int i = 0; i < this.Player.Bombs.Count; i++)
            {
                this.Player.Bombs[i].Move();

                if (this.Player.Bombs[i].Body.All(pixel => pixel.Coordinate.Y >= this.Field.Height || pixel.Coordinate.X >= this.Field.Width))
                {
                    this.Player.Bombs.RemoveAt(i);
                    i--;
                }
            }
        }

        private void BombsDraw()
        {
            for (int i = 0; i < this.Player.Bombs.Count; i++)
            {
                this.Player.Bombs[i].Draw();
            }
        }
    }
}
