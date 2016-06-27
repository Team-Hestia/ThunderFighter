namespace ThunderFighter.Buildings
{
    using System;
    using System.Collections.Generic;

    internal class ShootingTower : Building, IBulletShooter
    {
        public ShootingTower(Field field, Point2D position) :
            this(field, position, EntityState.Strong)
        {
        }

        public ShootingTower(Field field, Point2D position, EntityState entityState) :
            this(field, position, ShootingTower.BodyStates(), entityState)
        {
        }

        public ShootingTower(Field field, Point2D position, List<List<Pixel>> bodyStates, EntityState entityState) :
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
            strongBody.Add(new Pixel(0, 0, '*', ConsoleColor.Black));

            List<Pixel> halfDestroyedBody = new List<Pixel>();

            List<Pixel> destroyedBody = new List<Pixel>();

            bodyStates.Add(strongBody);        // EntityState.Strong
            bodyStates.Add(halfDestroyedBody); // EntityState.HalfDestroyed
            bodyStates.Add(destroyedBody);     // EntityState.Destroyed

            return bodyStates;
        }
    }
}
