namespace ThunderFighter
{
    public static class Game
    {
        public static void Start()
        {
            var field = new Field(100, 40);
            var player = new Fighters.ThunderFighterOne(field, new Point2D(10, 5));
            var level = GameLevel.Easy;

            Engine engine = new Engine(field, player, level);
            engine.Start();
        }
    }
}
