namespace ThunderFighter.Enemies
{
    using System;
    using System.Collections.Generic;
    using ThunderFighter.Bullets;

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
            // you can override here initial bomb movement direction values set in base constructor
            this.DeltaX = -2;
            this.DeltaY = 0;
        }

        public override void Move()
        {
            // moves normally and when reach 1/2 of field start moving in a crazy way
            if (this.Position.X < this.Field.PlayWidth / 2)
            {
                this.DeltaX = RandomProvider.Instance.Next(-2, 1);
                this.DeltaY = RandomProvider.Instance.Next(-1, 2);
            }

            this.EnemyPositionX += this.DeltaX;
            this.EnemyPositionY += this.DeltaY;

            this.Position.X = (int)this.EnemyPositionX;
            this.Position.Y = (int)this.EnemyPositionY;
        }

        public override void BulletShoot()
        {
            throw new NotImplementedException();
        }

        private static List<List<Pixel>> BodyStates()
        {
            List<List<Pixel>> bodyStates = new List<List<Pixel>>();

            List<Pixel> strongBody = new List<Pixel>();
            strongBody.Add(new Pixel(0, 0, 'O', Theme.Contrast));
            strongBody.Add(new Pixel(1, -1, '(', Theme.Red));
            strongBody.Add(new Pixel(2, -1, '(', Theme.Red));
            strongBody.Add(new Pixel(2, 1, '(', Theme.Red));
            strongBody.Add(new Pixel(1, 1, '(', Theme.Red));
            strongBody.Add(new Pixel(1, 0, 'O', Theme.Contrast));
            strongBody.Add(new Pixel(2, 0, 'O', Theme.Contrast));
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

            List<Pixel> disappearedBody = new List<Pixel>();
            disappearedBody.Add(new Pixel(0, 0, ' ', Console.BackgroundColor));

            bodyStates.Add(strongBody);        // EntityState.Strong
            bodyStates.Add(halfDestroyedBody); // EntityState.HalfDestroyed
            bodyStates.Add(destroyedBody);     // EntityState.Destroyed
            bodyStates.Add(disappearedBody);   // EntityState.Disappeared

            return bodyStates;
        }
    }
}
