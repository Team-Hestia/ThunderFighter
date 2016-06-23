namespace ThunderFighter
{
    using System.Collections.Generic;

    internal abstract class Enemy : Entity, IMovable, IBulletShooter
    {
        protected Enemy(Field field, Point2D position, List<List<Pixel>> bodyStates, EntityState entityState) : 
            base(field, position, bodyStates, entityState)
        {
        }

        public int DeltaX { get; set; }

        public int DeltaY { get; set; }

        public virtual void Move()
        {
            this.Position.X += this.DeltaX;
            this.Position.Y += this.DeltaY;
        }

        public abstract void BulletShoot();
    }
}
