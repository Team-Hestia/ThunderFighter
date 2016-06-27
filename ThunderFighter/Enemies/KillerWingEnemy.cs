namespace ThunderFighter.Enemies
{
    using System;
    using System.Collections.Generic;

    internal class KillerWingEnemy : Enemy, IBulletShooter
    {
        public KillerWingEnemy(Field field, Point2D position) : 
            this(field, position, EntityState.Strong)
        {
        }

        public KillerWingEnemy(Field field, Point2D position, EntityState entityState) : 
            this(field, position, KillerWingEnemy.BodyStates(), entityState)
        {
        }

        public KillerWingEnemy(Field field, Point2D position, List<List<Pixel>> bodyStates, EntityState entityState) : 
            base(field, position, bodyStates, entityState)
        {
            // defines KillerWing movement direction
            this.DeltaX = -1;
            this.DeltaY = 0;
        }

        public override void BulletShoot()
        {
            throw new NotImplementedException();
        }

        private static List<List<Pixel>> BodyStates()
        {
            List<List<Pixel>> bodyStates = new List<List<Pixel>>();

            List<Pixel> strongBody = new List<Pixel>();
            strongBody.Add(new Pixel(0, 0, '<', ConsoleColor.Blue));
            strongBody.Add(new Pixel(1, -1, '=', ConsoleColor.Blue));
            strongBody.Add(new Pixel(1, 1, '=', ConsoleColor.Blue));
            strongBody.Add(new Pixel(2, 0, ':', ConsoleColor.Blue));
            strongBody.Add(new Pixel(2, -2, '/', ConsoleColor.DarkBlue));
            strongBody.Add(new Pixel(2, 2, '\\', ConsoleColor.DarkBlue));

            strongBody.Add(new Pixel(3, 0, '=', ConsoleColor.Blue));
            strongBody.Add(new Pixel(4, 0, '=', ConsoleColor.Blue));
            strongBody.Add(new Pixel(5, 0, '=', ConsoleColor.Blue));
            strongBody.Add(new Pixel(6, 0, '=', ConsoleColor.Blue));
            strongBody.Add(new Pixel(7, 0, '=', ConsoleColor.Blue));
            strongBody.Add(new Pixel(8, 0, '=', ConsoleColor.Blue));
            strongBody.Add(new Pixel(9, 0, '=', ConsoleColor.Blue));
            strongBody.Add(new Pixel(10, 0, '=', ConsoleColor.Blue));

            List<Pixel> halfDestroyedBody = new List<Pixel>();
            halfDestroyedBody.Add(new Pixel(0, 0, '<', ConsoleColor.DarkMagenta));
            halfDestroyedBody.Add(new Pixel(1, -1, '=', ConsoleColor.DarkMagenta));
            halfDestroyedBody.Add(new Pixel(1, 1, '=', ConsoleColor.DarkMagenta));
            halfDestroyedBody.Add(new Pixel(2, 0, ':', ConsoleColor.DarkMagenta));
            halfDestroyedBody.Add(new Pixel(2, -2, '/', ConsoleColor.DarkMagenta));
            halfDestroyedBody.Add(new Pixel(2, 2, '\\', ConsoleColor.DarkMagenta));

            List<Pixel> destroyedBody = new List<Pixel>();
            destroyedBody.Add(new Pixel(0, 0, '<', ConsoleColor.DarkYellow));
            destroyedBody.Add(new Pixel(1, -1, '=', ConsoleColor.DarkYellow));
            destroyedBody.Add(new Pixel(1, 1, '=', ConsoleColor.DarkYellow));
            destroyedBody.Add(new Pixel(2, 0, ':', ConsoleColor.DarkYellow));
            destroyedBody.Add(new Pixel(2, -2, '/', ConsoleColor.DarkYellow));
            destroyedBody.Add(new Pixel(2, 2, '\\', ConsoleColor.DarkYellow));

            bodyStates.Add(strongBody);        // EntityState.Strong
            bodyStates.Add(halfDestroyedBody); // EntityState.HalfDestroyed
            bodyStates.Add(destroyedBody);     // EntityState.Destroyed

            return bodyStates;
        }
    }
}
