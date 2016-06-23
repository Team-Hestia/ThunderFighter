namespace ThunderFighter
{
    using System.Collections.Generic;

    internal class Bullet : Entity, IMovable
    {
        private int deltaX;
        private int deltaY;

        protected Bullet(Field field, Point2D position, List<List<Pixel>> bodyStates, EntityState entityState) : 
            base(field, position, bodyStates, entityState)
        {
        }

        public int DeltaX
        {
            get
            {
                return this.deltaX;
            }

            set
            {
                this.deltaX = value;
            }
        }

        public int DeltaY
        {
            get
            {
                return this.deltaY;
            }

            set
            {
                this.deltaY = value;
            }
        }

        public virtual void Move()
        {
            this.Position.X += this.DeltaX;
            this.Position.Y += this.DeltaY;
        }
    }
}
