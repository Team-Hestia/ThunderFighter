namespace ThunderFighter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    abstract class Enemy : Entity
    {
        public Enemy(Field field, Point2D position, List<Pixel> body) : base(field, position, body)
        {
        }
    }
}
