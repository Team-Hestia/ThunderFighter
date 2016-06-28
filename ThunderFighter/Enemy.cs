namespace ThunderFighter
{
    using System.Collections.Generic;

    internal abstract class Enemy : Entity, IMovable, IBulletShooter
    {
        private List<Bullet> bullets;

        protected Enemy(Field field, Point2D position, List<List<Pixel>> bodyStates, EntityState entityState) :
            base(field, position, bodyStates, entityState)
        {
            this.bullets = new List<Bullet>();
        }

        public int DeltaX { get; set; }

        public int DeltaY { get; set; }

        internal List<Bullet> Bullets
        {
            get
            {
                return this.bullets;
            }

            set
            {
                this.bullets = value;
            }
        }

        public virtual void Move()
        {
            this.Position.X += this.DeltaX;
            this.Position.Y += this.DeltaY;
        }

        public abstract void BulletShoot();
    }
}
