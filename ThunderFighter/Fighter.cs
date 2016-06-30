namespace ThunderFighter
{
    using System;
    using System.Collections.Generic;
    using ThunderFighter.Controls;

    internal abstract class Fighter : Entity, IMovable, IBulletShooter, IBomber
    {
        private List<Bullet> bullets;
        private List<Bomb> bombs;
        private List<Missile> missiles;

        private MoveDirection lastMove;

        protected Fighter(Field field, Point2D position, List<List<Pixel>> bodyStates, EntityState entityState) :
            base(field, position, bodyStates, entityState)
        {
            this.bullets = new List<Bullet>();
            this.bombs = new List<Bomb>();
            this.missiles = new List<Missile>();

            this.lastMove = MoveDirection.OnHold;

            ConsoleKeyboardHandler.Instance.KeyDown += this.Instance_KeyDown;
        }

        internal List<Bullet> Bullets
        {
            get
            {
                return this.bullets;
            }

            set
            {
                this.bullets = value;
            }
        }

        internal List<Bomb> Bombs
        {
            get
            {
                return this.bombs;
            }

            set
            {
                this.bombs = value;
            }
        }

        internal List<Missile> Missiles
        {
            get
            {
                return this.missiles;
            }

            set
            {
                this.missiles = value;
            }
        }

        public virtual void Move()
        {
            if (this.lastMove == MoveDirection.Left && this.Body.Exists(pixel => pixel.Coordinate.X > this.Width))
            {
                this.Position.X--;
            }
            else if (this.lastMove == MoveDirection.Right && this.Body.Exists(pixel => pixel.Coordinate.X + this.Width < this.Field.Width - (this.Field.Width / 3)))
            {
                this.Position.X++;
            }
            else if (this.lastMove == MoveDirection.Down && this.Body.Exists(pixel => pixel.Coordinate.Y + this.Height < this.Field.Height - 1))
            {
                this.Position.Y++;
            }
            else if (this.lastMove == MoveDirection.Up && this.Body.Exists(pixel => pixel.Coordinate.Y > this.Height))
            {
                this.Position.Y--;
            }

            this.lastMove = MoveDirection.OnHold;
        }

        public abstract void BulletShoot();

        public abstract void ThrowBomb();

        protected virtual void HandleKeyDown(ConsoleKeyDownEventArgs args)
        {
            if (args.KeyInfo.Key == ConsoleKey.Spacebar)
            {
                this.BulletShoot();
            }
            else if (args.KeyInfo.Key == ConsoleKey.B)
            {
                this.ThrowBomb();
            }
            else if (args.KeyInfo.Key == ConsoleKey.LeftArrow)
            {
                this.lastMove = MoveDirection.Left;
            }
            else if (args.KeyInfo.Key == ConsoleKey.RightArrow)
            {
                this.lastMove = MoveDirection.Right;
            }
            else if (args.KeyInfo.Key == ConsoleKey.DownArrow)
            {
                this.lastMove = MoveDirection.Down;
            }
            else if (args.KeyInfo.Key == ConsoleKey.UpArrow)
            {
                this.lastMove = MoveDirection.Up;
            }
        }

        private void Instance_KeyDown(object sender, ConsoleKeyDownEventArgs e)
        {
            this.HandleKeyDown(e);
        }
    }
}