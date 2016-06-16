namespace ThunderFighter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    abstract class Building : Entity
    {
        public Building(Field field, Point2D position, List<Pixel> body) : base(field, position, body)
        {
        }

        public override void Draw()
        {
            throw new NotImplementedException();
        }

        public override void Clear()
        {
            throw new NotImplementedException();
        }
    }
}
