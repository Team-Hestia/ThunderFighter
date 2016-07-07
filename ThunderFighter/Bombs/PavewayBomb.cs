namespace ThunderFighter.Bombs
{
    using System;
    using System.Collections.Generic;

    internal class PavewayBomb : Bomb
    {
        public PavewayBomb(Field field, Point2D position) : 
            this(field, position, EntityState.Strong)
        {
        }

        public PavewayBomb(Field field, Point2D position, EntityState entityState) : 
            this(field, position, PavewayBomb.BodyStates(), entityState)
        {
        }

        public PavewayBomb(Field field, Point2D position, List<List<Pixel>> bodyStates, EntityState entityState) : 
            base(field, position, bodyStates, entityState)
        {
            // decimal g = 2M;
            this.DeltaX = 0.7M;
            this.DeltaY = 1.0M;
        }

        private static List<List<Pixel>> BodyStates()
        {
            List<List<Pixel>> bodyStates = new List<List<Pixel>>();

            List<Pixel> strongBody = new List<Pixel>();
            strongBody.Add(new Pixel(5, 5, '*', Theme.Contrast));

            List<Pixel> halfDestroyedBody = new List<Pixel>();
            halfDestroyedBody.Add(new Pixel(2, 2, '*', ConsoleColor.Red));

            List<Pixel> destroyedBody = new List<Pixel>();
            destroyedBody.Add(new Pixel(3, 4, '+', ConsoleColor.Red));

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
