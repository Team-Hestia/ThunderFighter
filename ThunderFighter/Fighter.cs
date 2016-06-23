namespace ThunderFighter
{
    using System.Collections.Generic;

    internal abstract class Fighter : Entity, IMovable, IBulletShooter, IBomber
    {
        private List<Bullet> bullets;
        private List<Bomb> bombs;
        private List<Missile> missiles;

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

        internal List<Bomb> Bombs
        {
            get
            {
                return this.bombs;
            }

            set
            {
                this.bombs = value;
            }
        }

        internal List<Missile> Missiles
        {
            get
            {
                return this.missiles;
            }

            set
            {
                this.missiles = value;
            }
        }

        protected Fighter(Field field, Point2D position, List<List<Pixel>> bodyStates, EntityState entityState) :
            base(field, position, bodyStates, entityState)
        {
            this.bullets = new List<Bullet>();
            this.bombs = new List<Bomb>();
            this.missiles = new List<Missile>();
        }

        public abstract void Move();

        public abstract void BulletShoot();

        public abstract void ThrowBomb();
    }
}