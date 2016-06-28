namespace ThunderFighter.Enemies
{
    using ThunderFighter.Bullets;
    using System;
    using System.Collections.Generic;

    internal class BadShooterEnemy : Enemy, IBulletShooter
    {
        public BadShooterEnemy(Field field, Point2D position) :
            this(field, position, EntityState.Strong)
        {
        }

        public BadShooterEnemy(Field field, Point2D position, EntityState entityState) :
            this(field, position, BadShooterEnemy.BodyStates(), entityState)
        {
        }

        public BadShooterEnemy(Field field, Point2D position, List<List<Pixel>> bodyStates, EntityState entityState) :
            base(field, position, bodyStates, entityState)
        {
            // defines badShooter movement direction
            this.DeltaX = 0;
            int yMove = new int();
            if (this.Position.Y <= this.Field.Height/2)
            {
                yMove = 1;
            }
            else
            {
                yMove = -1;
            }

            this.DeltaY = yMove;
        }

        public override void Move()
        {
            // after they reach certain part of the field they stop and move only sideways and shoot
            int tollerance = RandomProvider.Instance.Next(-10, 10);
            if (Position.X > this.Field.Width / 2 + tollerance)
            {
                this.Position.X += this.DeltaX - 2;
            }
            else
            {
                this.Position.Y += this.DeltaY;
            }

            // shooting frequency - should depend on level
            int bulletEngage = RandomProvider.Instance.Next(0, 21);
            if (bulletEngage < Constants.EasyEnemyBulletsMaxCount)
            {
                this.BulletShoot();
            }
        }

        public override void BulletShoot()
        {
            var bullet = new LightEnemyBullet(this.Field, new Point2D(this.Position));

            // redefines bullet speed and direction
            bullet.DeltaX = -3;
            bullet.DeltaY = 0;

            this.Bullets.Add(bullet);
        }

        private static List<List<Pixel>> BodyStates()
        {
            List<List<Pixel>> bodyStates = new List<List<Pixel>>();

            List<Pixel> strongBody = new List<Pixel>();
            strongBody.Add(new Pixel(0, 0, ':', ConsoleColor.Black));
            strongBody.Add(new Pixel(1, -1, '<', ConsoleColor.DarkGreen));
            strongBody.Add(new Pixel(2, -1, '|', ConsoleColor.DarkGreen));
            strongBody.Add(new Pixel(2, 1, '|', ConsoleColor.DarkGreen));
            strongBody.Add(new Pixel(1, 1, '<', ConsoleColor.DarkGreen));
            strongBody.Add(new Pixel(1, 0, 'X', ConsoleColor.Black));
            strongBody.Add(new Pixel(2, 0, 'X', ConsoleColor.Black));
            strongBody.Add(new Pixel(3, 0, ':', ConsoleColor.Green));

            List<Pixel> halfDestroyedBody = new List<Pixel>();
            halfDestroyedBody.Add(new Pixel(0, 0, '*', ConsoleColor.DarkMagenta));
            halfDestroyedBody.Add(new Pixel(-1, 1, '*', ConsoleColor.DarkMagenta));
            halfDestroyedBody.Add(new Pixel(0, 1, '*', ConsoleColor.DarkMagenta));
            halfDestroyedBody.Add(new Pixel(1, 1, '*', ConsoleColor.DarkMagenta));
            halfDestroyedBody.Add(new Pixel(0, 2, '*', ConsoleColor.DarkMagenta));

            List<Pixel> destroyedBody = new List<Pixel>();
            destroyedBody.Add(new Pixel(0, -1, '+', ConsoleColor.DarkYellow));
            destroyedBody.Add(new Pixel(2, -1, '+', ConsoleColor.DarkYellow));
            destroyedBody.Add(new Pixel(-1, 1, '+', ConsoleColor.DarkYellow));
            destroyedBody.Add(new Pixel(2, 0, '+', ConsoleColor.DarkYellow));
            destroyedBody.Add(new Pixel(1, -2, '+', ConsoleColor.DarkYellow));
            destroyedBody.Add(new Pixel(2, 2, '+', ConsoleColor.DarkYellow));

            bodyStates.Add(strongBody);        // EntityState.Strong
            bodyStates.Add(halfDestroyedBody); // EntityState.HalfDestroyed
            bodyStates.Add(destroyedBody);     // EntityState.Destroyed

            return bodyStates;
        }
    }
}
