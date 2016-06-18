namespace ThunderFighter
{
    using System.Collections.Generic;

    abstract class Enemy : Entity, IMovable
    {
        public Enemy(Field field, Point2D position, List<Pixel> body) : base(field, position, body)
        {
        }

        abstract public void Move();
    }
}