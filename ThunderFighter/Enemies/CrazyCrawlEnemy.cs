namespace ThunderFighter.Enemies
{
    using ThunderFighter.Bullets;
    using System;
    using System.Collections.Generic;

    internal class CrazyCrawlEnemy : Enemy, IBulletShooter
    {
        public CrazyCrawlEnemy(Field field, Point2D position) :
            this(field, position, EntityState.Strong)
        {
        }

        public CrazyCrawlEnemy(Field field, Point2D position, EntityState entityState) :
            this(field, position, CrazyCrawlEnemy.BodyStates(), entityState)
        {
        }

        public CrazyCrawlEnemy(Field field, Point2D position, List<List<Pixel>> bodyStates, EntityState entityState) :
            base(field, position, bodyStates, entityState)
        {
            // defines badShooter movement direction
            this.DeltaX = 0;
            this.DeltaY = 0;
        }

        public override void Move()
        {
            this.Position.X += this.DeltaX - 1;
            this.Position.Y += this.DeltaY;
            int direction = RandomProvider.Instance.Next(-1, 2);
            if (this.Position.X < this.Field.Width / 1.5)
            {
                this.Position.X += this.DeltaX + direction - 1;
                this.Position.Y += this.DeltaY + direction;
            }
        }

        public override void BulletShoot()
        {
            throw new NotImplementedException();
        }

        private static List<List<Pixel>> BodyStates()
        {
            List<List<Pixel>> bodyStates = new List<List<Pixel>>();

            List<Pixel> strongBody = new List<Pixel>();
            strongBody.Add(new Pixel(0, 0, 'O', ConsoleColor.Black));
            strongBody.Add(new Pixel(1, -1, '(', ConsoleColor.DarkRed));
            strongBody.Add(new Pixel(2, -1, '(', ConsoleColor.DarkRed));
            strongBody.Add(new Pixel(2, 1, '(', ConsoleColor.DarkRed));
            strongBody.Add(new Pixel(1, 1, '(', ConsoleColor.DarkRed));
            strongBody.Add(new Pixel(1, 0, 'O', ConsoleColor.Black));
            strongBody.Add(new Pixel(2, 0, 'O', ConsoleColor.Black));
            strongBody.Add(new Pixel(3, 0, '<', ConsoleColor.Red));

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
