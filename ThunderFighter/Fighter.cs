namespace ThunderFighter
{
    using System;
    using System.Collections.Generic;
    using ThunderFighter.Controls;
    using ThunderFighter.Enums;

    internal abstract class Fighter : Entity, IMovable, IBulletShooter, IBomber
    {
        private string name; 
        private List<Bullet> bullets;
        private List<Bomb> bombs;
        private List<Missile> missiles;

        private MoveDirection moveDirection;

        protected Fighter(Field field, Point2D position, List<List<Pixel>> bodyStates, EntityState entityState) :
            base(field, position, bodyStates, entityState)
        {
            this.Name = Constants.NameNotSet; //this.GetType().Name.ToString();
            this.bullets = new List<Bullet>();
            this.bombs = new List<Bomb>();
            this.missiles = new List<Missile>();

            this.moveDirection = MoveDirection.OnHold;

            ConsoleKeyboardHandler.Instance.KeyDown += this.Instance_KeyDown;
        }

        internal string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (value.Length < 3 && value.Length >10)
                {
                    throw new NameFormatException(value);
                }
                this.name = value;
            }
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
            if (this.moveDirection == MoveDirection.Left && this.Body.Exists(pixel => pixel.Coordinate.X > this.Width))
            {
                this.Position.X--;
            }
            else if (this.moveDirection == MoveDirection.Right && this.Body.Exists(pixel => pixel.Coordinate.X + this.Width < this.Field.PlayWidth - (this.Field.PlayWidth / 3)))
            {
                this.Position.X++;
            }
            else if (this.moveDirection == MoveDirection.Down && this.Body.Exists(pixel => pixel.Coordinate.Y + this.Height < this.Field.PlayHeight - 1))
            {
                this.Position.Y++;
            }
            else if (this.moveDirection == MoveDirection.Up && this.Body.Exists(pixel => pixel.Coordinate.Y > this.Height))
            {
                this.Position.Y--;
            }

            this.moveDirection = MoveDirection.OnHold;
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
                this.moveDirection = MoveDirection.Left;
            }
            else if (args.KeyInfo.Key == ConsoleKey.RightArrow)
            {
                this.moveDirection = MoveDirection.Right;
            }
            else if (args.KeyInfo.Key == ConsoleKey.DownArrow)
            {
                this.moveDirection = MoveDirection.Down;
            }
            else if (args.KeyInfo.Key == ConsoleKey.UpArrow)
            {
                this.moveDirection = MoveDirection.Up;
            }
        }

        private void Instance_KeyDown(object sender, ConsoleKeyDownEventArgs e)
        {
            this.HandleKeyDown(e);
        }
    }
}