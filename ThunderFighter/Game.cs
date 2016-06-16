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
            var field = new Field(140, 40);
            var player = new Fighter(field, new Point2D(10, 5));

            Engine engine = new Engine(field, player);
            engine.Field.Draw();
        }
    }
}
