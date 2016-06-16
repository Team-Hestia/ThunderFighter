namespace ThunderFighter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class ShootingTower : Building, IShooter
    {
        public ShootingTower(Field field, Point2D position, List<Pixel> body) : base(field, position, body)
        {
        }

        public void Shoot()
        {
            throw new NotImplementedException();
        }
    }
}
