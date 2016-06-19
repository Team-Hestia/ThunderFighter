namespace ThunderFighter
{
    using System;
    using System.Collections.Generic;

    class KillerWingEnemy : Enemy, IShooter
    {
        private static List<Pixel> EnemyBody(Point2D pos)
        {
            List<Pixel> body = new List<Pixel>();
            var randomEnemy = RandomProvider.Instance;
            int taleLength = randomEnemy.Next(2, 15);

            switch (randomEnemy.Next(0, 4))
            {
                case 0:
                    body.Add(new Pixel(0, 0, '<', ConsoleColor.DarkMagenta));
                    body.Add(new Pixel(1, -1, '(', ConsoleColor.DarkMagenta));
                    body.Add(new Pixel(1, 1, '(', ConsoleColor.DarkMagenta));
                    body.Add(new Pixel(2, 0, '<', ConsoleColor.DarkMagenta));
                    for (int i = 0; i < taleLength; i++)
                    {
                        body.Add(new Pixel(i + 3, 0, '-', ConsoleColor.DarkMagenta));
                    }
                    break;
                case 1:
                    body.Add(new Pixel(0, 0, '{', ConsoleColor.DarkCyan));
                    body.Add(new Pixel(1, -1, '\\', ConsoleColor.DarkCyan));
                    body.Add(new Pixel(1, 1, '/', ConsoleColor.DarkCyan));
                    body.Add(new Pixel(2, 0, 'B', ConsoleColor.DarkCyan));
                    for (int i = 0; i < taleLength; i++)
                    {
                        body.Add(new Pixel(i + 3, 0, '-', ConsoleColor.DarkCyan));
                    }
                    break;
                case 2:
                    body.Add(new Pixel(0, 0, '[', ConsoleColor.DarkGreen));
                    body.Add(new Pixel(1, -1, 'O', ConsoleColor.DarkGreen));
                    body.Add(new Pixel(1, 1, 'O', ConsoleColor.DarkGreen));
                    body.Add(new Pixel(2, 0, 'O', ConsoleColor.DarkGreen));
                    for (int i = 0; i < taleLength; i++)
                    {
                        body.Add(new Pixel(i + 3, 0, '-', ConsoleColor.DarkGreen));
                    }
                    break;
                default:
                    body.Add(new Pixel(0, 0, '<', ConsoleColor.Blue));
                    body.Add(new Pixel(1, -1, '/', ConsoleColor.Blue));
                    body.Add(new Pixel(1, 1, '\\', ConsoleColor.Blue));
                    body.Add(new Pixel(2, 0, ':', ConsoleColor.Blue));
                    for (int i = 0; i < taleLength; i++)
                    {
                        body.Add(new Pixel(i + 3, 0, '-', ConsoleColor.Blue));
                    }
                    break;
            }
            
            return body;
        }
        public KillerWingEnemy(Field field, Point2D position) : this(field, position, EnemyBody(position))
        {
        }
        public KillerWingEnemy(Field field, Point2D position, List<Pixel> body) : base(field, position, body)
        {
        }

        public override void Move()
        {
            this.Position.X--;

            this.ReCalculateBody();
        }

        public void Shoot()
        {
            throw new NotImplementedException();
        }
    }
}
