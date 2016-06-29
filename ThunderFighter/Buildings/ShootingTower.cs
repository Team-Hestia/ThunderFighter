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

            List<Pixel> strongBody = new List<Pixel>();
            strongBody.Add(new Pixel(0, -3, '|', ConsoleColor.Black));
            strongBody.Add(new Pixel(0, -2, '|', ConsoleColor.Black));
            strongBody.Add(new Pixel(0, -1, '|', ConsoleColor.Black));
            strongBody.Add(new Pixel(0, 0, '|', ConsoleColor.Black));
            
            strongBody.Add(new Pixel(1, -4, '_', ConsoleColor.Black));
            strongBody.Add(new Pixel(2, -4, '_', ConsoleColor.Black));
            strongBody.Add(new Pixel(3, -4, '_', ConsoleColor.Black));
            
            strongBody.Add(new Pixel(4, -3, '|', ConsoleColor.Black));
            strongBody.Add(new Pixel(4, -2, '|', ConsoleColor.Black));
            strongBody.Add(new Pixel(4, -1, '|', ConsoleColor.Black));
            strongBody.Add(new Pixel(4, 0, '|', ConsoleColor.Black));

            List<Pixel> halfDestroyedBody = new List<Pixel>();
            halfDestroyedBody.Add(new Pixel(0, 0, '|', ConsoleColor.DarkRed));

            List<Pixel> destroyedBody = new List<Pixel>();
            destroyedBody.Add(new Pixel(0, 0, '|', ConsoleColor.DarkRed));

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
