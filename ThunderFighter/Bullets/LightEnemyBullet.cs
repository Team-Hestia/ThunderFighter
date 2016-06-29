namespace ThunderFighter.Bullets
{
    using System;
    using System.Collections.Generic;

    internal class LightEnemyBullet : Bullet
    {
        public LightEnemyBullet(Field field, Point2D position) :
            this(field, position, EntityState.Strong)
        {
        }

        public LightEnemyBullet(Field field, Point2D position, EntityState entityState) :
            this(field, position, LightEnemyBullet.BodyStates(), entityState)
        {
        }

        public LightEnemyBullet(Field field, Point2D position, List<List<Pixel>> bodyStates, EntityState entityState) :
            base(field, position, bodyStates, entityState)
        {
            // defines bullet movement direction
            this.DeltaX = -3;
            this.DeltaY = 0;
        }

        private static List<List<Pixel>> BodyStates()
        {
            List<List<Pixel>> bodyStates = new List<List<Pixel>>();

            List<Pixel> strongBody = new List<Pixel>();
            strongBody.Add(new Pixel(-1, 0, '~', ConsoleColor.Red));

            List<Pixel> halfDestroyedBody = new List<Pixel>();
            halfDestroyedBody.Add(new Pixel(-1, 2, '*', ConsoleColor.Yellow));
            halfDestroyedBody.Add(new Pixel(0, 1, '*', ConsoleColor.Yellow));
            halfDestroyedBody.Add(new Pixel(1, 4, '*', ConsoleColor.Yellow));
            halfDestroyedBody.Add(new Pixel(2, 3, '*', ConsoleColor.Yellow));
            halfDestroyedBody.Add(new Pixel(1, 4, '*', ConsoleColor.Yellow));
            halfDestroyedBody.Add(new Pixel(0, 5, '*', ConsoleColor.Yellow));
            halfDestroyedBody.Add(new Pixel(-1, 4, '*', ConsoleColor.Yellow));
            halfDestroyedBody.Add(new Pixel(-2, 3, '*', ConsoleColor.Yellow));

            List<Pixel> destroyedBody = new List<Pixel>();
            destroyedBody.Add(new Pixel(-2, 1, '+', ConsoleColor.Red));
            destroyedBody.Add(new Pixel(2, 1, '+', ConsoleColor.Red));
            destroyedBody.Add(new Pixel(2, 5, '+', ConsoleColor.Red));
            destroyedBody.Add(new Pixel(-2, 5, '+', ConsoleColor.Red));

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
