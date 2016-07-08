namespace ThunderFighter
{
    using System.Collections.Generic;
    using ThunderFighter.Enums;

    internal abstract class Bomb : Entity, IMovable
    {
        private decimal deltaX;
        private decimal deltaY;

        private decimal bombPositionX;        
        private decimal bombPositionY;

        protected Bomb(Field field, Point2D position, List<List<Pixel>> bodyStates, EntityState entityState) :
            base(field, position, bodyStates, entityState)
        {
            // defines initial bomb movement direction values
            this.DeltaX = 0.75M;
            this.DeltaY = 1.0M;

            this.BombPositionX = position.X;
            this.BombPositionY = position.Y;
        }

        public decimal DeltaX
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

        public decimal DeltaY
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

        protected decimal BombPositionX
        {
            get
            {
                return this.bombPositionX;
            }

            set
            {
                this.bombPositionX = value;
            }
        }

        protected decimal BombPositionY
        {
            get
            {
                return this.bombPositionY;
            }

            set
            {
                this.bombPositionY = value;
            }
        }

        public virtual void Move()
        {
            this.BombPositionX += this.DeltaX;
            this.BombPositionY += this.DeltaY;

            this.Position.X = (int)this.BombPositionX;
            this.Position.Y = (int)this.BombPositionY;
        }
    }
}
