namespace ThunderFighter
{
    using System.Collections.Generic;

    using System.Threading.Tasks;
    class Bullet : Entity, IMovable
    {
        public Bullet(Field field, Point2D position, List<Pixel> body) : base(field, position, body)
        {
        }

        public void Move()
        {
            this.Position.X += 2;

            this.ReCalculateBody();
        }
    }
}
