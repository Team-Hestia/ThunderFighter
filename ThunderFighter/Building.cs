namespace ThunderFighter
{
    using System.Collections.Generic;

    internal class Building : Entity, IMovable
    {
        private int deltaX = 1;

        protected Building(Field field, Point2D position, List<List<Pixel>> bodyStates, EntityState entityState) :
            base(field, position, bodyStates, entityState)
        {
        }

        public void Move()
        {
            this.Position.X += this.deltaX;
        }
    }
}
