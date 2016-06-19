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
            body.Add(new Pixel(0, 0, '<', ConsoleColor.Blue));
            body.Add(new Pixel(1, -1, '/', ConsoleColor.Blue));
            body.Add(new Pixel(2, 2, '\\', ConsoleColor.Blue));
            body.Add(new Pixel(2, -2, '/', ConsoleColor.Blue));
            body.Add(new Pixel(1, 1, '\\', ConsoleColor.Blue));
            body.Add(new Pixel(2, 0, ':', ConsoleColor.Blue));
            for (int i = 0; i < taleLength; i++)
            {
                body.Add(new Pixel(i + 3, 0, '-', ConsoleColor.Blue));
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
