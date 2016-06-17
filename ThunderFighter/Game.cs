namespace ThunderFighter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class Game
    {
        public static void Start()
        {
            var field = new Field(100, 40);
            var player = new Fighter(field, new Point2D(10, 5));
            var enemy = new FighterEnemy(field, new Point2D(80, 20));

            Engine engine = new Engine(field, player, enemy);
            engine.Field.Draw();
        }
    }
}
