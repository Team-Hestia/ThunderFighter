namespace ThunderFighter.Fighters
{
    using System;
    using System.Collections.Generic;

    internal class ThunderFighterOne : Fighter, IBulletShooter, IBomber
    {
        public ThunderFighterOne(Field field, Point2D position) :
            this(field, position, EntityState.Strong)
        {
        }

        public ThunderFighterOne(Field field, Point2D position, EntityState state) :
            this(field, position, ThunderFighterOne.BodyStates(), state)
        {
        }

        public ThunderFighterOne(Field field, Point2D position, List<List<Pixel>> bodies, EntityState state) :
            base(field, position, bodies, state)
        {
        }

        public override void BulletShoot()
        {
            var bullet = new Bullets.LightweightBullet(this.Field, new Point2D(this.Position));

            // redefines bullet speed and direction
            bullet.DeltaX = 3;
            bullet.DeltaY = 0;

            this.Bullets.Add(bullet);
        }

        public override void ThrowBomb()
        {
            throw new NotImplementedException();
        }

        private static List<List<Pixel>> BodyStates()
        {
            List<List<Pixel>> bodyStates = new List<List<Pixel>>();

            List<Pixel> strongBody = new List<Pixel>();
            strongBody.Add(new Pixel(0, 0, '=', ConsoleColor.Black));
            strongBody.Add(new Pixel(-1, 0, '>', ConsoleColor.Red));
            strongBody.Add(new Pixel(0, -2, '-', ConsoleColor.Black));
            strongBody.Add(new Pixel(0, -1, '\\', ConsoleColor.Black));
            strongBody.Add(new Pixel(0, 1, '/', ConsoleColor.Black));
            strongBody.Add(new Pixel(0, 2, '-', ConsoleColor.Black));
            strongBody.Add(new Pixel(1, -1, '\\', ConsoleColor.Black));
            strongBody.Add(new Pixel(1, 0, '=', ConsoleColor.Black));
            strongBody.Add(new Pixel(1, 1, '/', ConsoleColor.Black));
            strongBody.Add(new Pixel(2, 0, '=', ConsoleColor.Black));
            strongBody.Add(new Pixel(3, 0, '=', ConsoleColor.DarkCyan));
            strongBody.Add(new Pixel(4, 0, '>', ConsoleColor.DarkCyan));

            List<Pixel> halfDestroyedBody = new List<Pixel>();
            halfDestroyedBody.Add(new Pixel(0, 0, '=', ConsoleColor.Black));
            halfDestroyedBody.Add(new Pixel(-1, 0, '>', ConsoleColor.Red));
            halfDestroyedBody.Add(new Pixel(0, -2, '-', ConsoleColor.Black));
            halfDestroyedBody.Add(new Pixel(0, -1, '\\', ConsoleColor.Black));
            halfDestroyedBody.Add(new Pixel(0, 1, '/', ConsoleColor.Black));
            halfDestroyedBody.Add(new Pixel(0, 2, '-', ConsoleColor.Black));
            halfDestroyedBody.Add(new Pixel(1, -1, '\\', ConsoleColor.Black));
            halfDestroyedBody.Add(new Pixel(1, 0, '=', ConsoleColor.Black));
            halfDestroyedBody.Add(new Pixel(1, 1, '/', ConsoleColor.Black));
            halfDestroyedBody.Add(new Pixel(2, 0, '=', ConsoleColor.Black));
            halfDestroyedBody.Add(new Pixel(3, 0, '=', ConsoleColor.DarkCyan));
            halfDestroyedBody.Add(new Pixel(4, 0, '>', ConsoleColor.DarkCyan));

            List<Pixel> destroyedBody = new List<Pixel>();
            destroyedBody.Add(new Pixel(0, 0, '=', ConsoleColor.Black));
            destroyedBody.Add(new Pixel(-1, 0, '>', ConsoleColor.Red));
            destroyedBody.Add(new Pixel(0, -2, '-', ConsoleColor.Black));
            destroyedBody.Add(new Pixel(0, -1, '\\', ConsoleColor.Black));
            destroyedBody.Add(new Pixel(0, 1, '/', ConsoleColor.Black));
            destroyedBody.Add(new Pixel(0, 2, '-', ConsoleColor.Black));
            destroyedBody.Add(new Pixel(1, -1, '\\', ConsoleColor.Black));
            destroyedBody.Add(new Pixel(1, 0, '=', ConsoleColor.Black));
            destroyedBody.Add(new Pixel(1, 1, '/', ConsoleColor.Black));
            destroyedBody.Add(new Pixel(2, 0, '=', ConsoleColor.Black));
            destroyedBody.Add(new Pixel(3, 0, '=', ConsoleColor.DarkCyan));
            destroyedBody.Add(new Pixel(4, 0, '>', ConsoleColor.DarkCyan));

            bodyStates.Add(strongBody);        // EntityState.Strong
            bodyStates.Add(halfDestroyedBody); // EntityState.HalfDestroyed
            bodyStates.Add(destroyedBody);     // EntityState.Destroyed

            return bodyStates;
        }
    }
}
