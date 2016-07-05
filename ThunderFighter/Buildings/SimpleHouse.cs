namespace ThunderFighter.Buildings
{
    using System;
    using System.Collections.Generic;

    internal class SimpleHouse : Building, IBulletShooter
    {
        public SimpleHouse(Field field, Point2D position) :
            this(field, position, EntityState.Strong)
        {
        }

        public SimpleHouse(Field field, Point2D position, EntityState entityState) :
            this(field, position, SimpleHouse.BodyStates(), entityState)
        {
        }

        public SimpleHouse(Field field, Point2D position, List<List<Pixel>> bodyStates, EntityState entityState) :
            base(field, position, bodyStates, entityState)
        {
        }

        public void BulletShoot()
        {
            throw new NotImplementedException();
        }

        private static List<List<Pixel>> BodyStates()
        {
            List<List<Pixel>> bodyStates = new List<List<Pixel>>();

            List<Pixel> strongBody = new List<Pixel>();
            strongBody.Add(new Pixel(0, 0, '|', ConsoleColor.Black));
            strongBody.Add(new Pixel(0, -1, '/', ConsoleColor.DarkRed));
            strongBody.Add(new Pixel(1, 0, '[', ConsoleColor.DarkGreen));
            strongBody.Add(new Pixel(1, -2, '/', ConsoleColor.DarkRed));
            strongBody.Add(new Pixel(2, 0, ']', ConsoleColor.DarkGreen));
            strongBody.Add(new Pixel(2, -2, '\\', ConsoleColor.DarkRed));
            strongBody.Add(new Pixel(2, -3, '_', ConsoleColor.DarkRed));
            strongBody.Add(new Pixel(3, 0, '|', ConsoleColor.Black));
            strongBody.Add(new Pixel(3, -1, '\\', ConsoleColor.DarkRed));
            strongBody.Add(new Pixel(3, -3, '_', ConsoleColor.DarkRed));
            strongBody.Add(new Pixel(4, -1, '_', ConsoleColor.DarkRed));
            strongBody.Add(new Pixel(4, -3, '_', ConsoleColor.DarkRed));
            strongBody.Add(new Pixel(5, 0, '[', ConsoleColor.DarkGreen));
            strongBody.Add(new Pixel(5, -1, '_', ConsoleColor.DarkRed));
            strongBody.Add(new Pixel(5, -3, 'I', ConsoleColor.Black));
            strongBody.Add(new Pixel(6, 0, ']', ConsoleColor.DarkGreen));
            strongBody.Add(new Pixel(6, -1, '_', ConsoleColor.DarkRed));
            strongBody.Add(new Pixel(6, -3, '_', ConsoleColor.DarkRed));
            strongBody.Add(new Pixel(7, -1, '_', ConsoleColor.DarkRed));
            strongBody.Add(new Pixel(7, -2, '\\', ConsoleColor.DarkRed));
            strongBody.Add(new Pixel(8, 0, '|', ConsoleColor.Black));
            strongBody.Add(new Pixel(8, -1, '\\', ConsoleColor.DarkRed));

            List<Pixel> halfDestroyedBody = new List<Pixel>();
            halfDestroyedBody.Add(new Pixel(1, -1, '#', ConsoleColor.DarkRed));
            halfDestroyedBody.Add(new Pixel(2,  0, '#', ConsoleColor.DarkRed));
            halfDestroyedBody.Add(new Pixel(3, -1, '#', ConsoleColor.DarkRed));

            List<Pixel> destroyedBody = new List<Pixel>();
            destroyedBody.Add(new Pixel(0, -2, '#', ConsoleColor.Red));
            destroyedBody.Add(new Pixel(2, 0, '#', ConsoleColor.Red));
            destroyedBody.Add(new Pixel(4, -1, '#', ConsoleColor.Red));

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
