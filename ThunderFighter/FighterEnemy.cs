namespace ThunderFighter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class FighterEnemy : Enemy, IMovable, IShooter
    {
        public ConsoleColor Color { get; private set; }

        private static List<Pixel> EnemyBody(Point2D pos)
        {
            List<Pixel> body = new List<Pixel>();

            body.Add(new Pixel(0, 0, '<', ConsoleColor.Blue));
            body.Add(new Pixel(1, -1, '=', ConsoleColor.Blue));
            body.Add(new Pixel(1, 1, '=', ConsoleColor.Blue));
            body.Add(new Pixel(2, 0, ':', ConsoleColor.Blue));
            body.Add(new Pixel(2, -2, '/', ConsoleColor.DarkBlue));
            body.Add(new Pixel(2, 2, '\\', ConsoleColor.DarkBlue));
            return body;
        }
        public FighterEnemy(Field field, Point2D position) : this(field, position, EnemyBody(position))
        {
        }
        public FighterEnemy(Field field, Point2D position, List<Pixel> body) : base(field, position, body)
        {
        }

        public override void Clear()
        {
            foreach (Pixel pixel in this.Body)
            {
                pixel.Clear();
            }
        }

        public override void Draw()
        {
            foreach (Pixel pixel in this.Body)
            {
                pixel.Draw();
            }
        }

        public void Move()
        {
            int yPosttion = RandomProvider.Instance.Next(this.RestrictionTop, this.RestrictionBottom);
            if (this.Position.X > this.RestrictionLeft)
            {
                this.Position.X--;
            }
            else
            {
                this.Position.Y = yPosttion;
                this.Position.X = this.RestrictionRight - 1;
            }
            this.ReCalculateBody();
        }

        public void Shoot()
        {
            throw new NotImplementedException();
        }
    }
}
