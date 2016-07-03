namespace ThunderFighter.Buildings
{
    using System;
    using System.Collections.Generic;

    internal class SimplePanelka : Building, IBulletShooter
    {
        public SimplePanelka(Field field, Point2D position) :
            this(field, position, EntityState.Strong)
        {
        }

        public SimplePanelka(Field field, Point2D position, EntityState entityState) :
            this(field, position, SimplePanelka.BodyStates(), entityState)
        {
        }

        public SimplePanelka(Field field, Point2D position, List<List<Pixel>> bodyStates, EntityState entityState) :
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

            int w = RandomProvider.Instance.Next(2, 16);
            if (w%2 != 0)
            {
                w = w + 1;
            }
            int h = RandomProvider.Instance.Next(2, 8);
            int r = RandomProvider.Instance.Next(33, 128);

            for (int i = 1; i < w; i++)
            {
                for (int j = 0; j <= h; j++)
                {
                    strongBody.Add(new Pixel(0, j * (-1), '|', ConsoleColor.Black));
                    strongBody.Add(new Pixel(w, j * (-1), '|', ConsoleColor.Black));
                    strongBody.Add(new Pixel(i, h * -1, '—', ConsoleColor.Black));

                    if (i % 2 != 0 && i > 0 && j < h && j > 0)
                    {
                        strongBody.Add(new Pixel(i, j * -1, (char)r, ConsoleColor.Black));
                    }
                }
            }


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
