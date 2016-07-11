﻿namespace ThunderFighter.Buildings
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

            int h = RandomProvider.Instance.Next(2, 12);

            List<Pixel> strongBody = new List<Pixel>();
            for (int i = 0; i < h; i++)
            {
                strongBody.Add(new Pixel(5, i * -1, '|', Theme.Magenta));
                strongBody.Add(new Pixel(0, i * -1, '|', Theme.Magenta));
            }

            for (int i = 2; i < h; i += 2)
            {
                strongBody.Add(new Pixel(2, i * -1, '[', Theme.Red));
                strongBody.Add(new Pixel(3, i * -1, ']', Theme.Red));
            }

            strongBody.Add(new Pixel(1, -h, '/', Theme.Magenta));
            strongBody.Add(new Pixel(2, -h - 1, '/', Theme.Magenta));
            strongBody.Add(new Pixel(3, -h - 1, '\\', Theme.Magenta));
            strongBody.Add(new Pixel(4, -h, '\\', Theme.Magenta));

            strongBody.Add(new Pixel(0, 0, '[', Theme.Red));
            strongBody.Add(new Pixel(1, 0, ']', Theme.Red));
            strongBody.Add(new Pixel(2, 0, '[', Theme.Red));
            strongBody.Add(new Pixel(3, 0, ']', Theme.Red));
            strongBody.Add(new Pixel(4, 0, '[', Theme.Red));
            strongBody.Add(new Pixel(5, 0, ']', Theme.Red));

            List<Pixel> halfDestroyedBody = new List<Pixel>();
            halfDestroyedBody.Add(new Pixel(1, -1, '#', Theme.Red));
            halfDestroyedBody.Add(new Pixel(2, 0, '#', Theme.Red));
            halfDestroyedBody.Add(new Pixel(3, -1, '#', Theme.Red));

            List<Pixel> destroyedBody = new List<Pixel>();
            destroyedBody.Add(new Pixel(0, 0, '|', Theme.Red));

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
