namespace ThunderFighter
{
    using System.Collections.Generic;

    internal class Building : Entity, IMovable
    {
        private static decimal deltaX = -0.5M;
        private decimal positionX;

        protected Building(Field field, Point2D position, List<List<Pixel>> bodyStates, EntityState entityState) :
            base(field, position, bodyStates, entityState)
        {
            this.positionX = position.X;
        }

        public static decimal DeltaX
        {
            get
            {
                return Building.deltaX;
            }

            private set
            {
                Building.deltaX = value;
            }
        }

        public void Move()
        {
            this.positionX += Building.DeltaX;
            this.Position.X = (int)this.positionX;
        }
    }
}
