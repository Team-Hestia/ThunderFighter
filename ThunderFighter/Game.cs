namespace ThunderFighter
{
    public static class Game
    {
        public static void Start()
        {
            var theme = new Theme(ThemeColor.black);
            var field = new Field(theme, 130, 40);
            ScreenBuffer.Initialize(field.Width, field.Height, Theme.contrast, Theme.backGround);
            var player = new Fighters.ThunderFighterOne(field, new Point2D(10, 5));
            var level = GameLevel.Easy;

            Engine engine = new Engine(field, player, level);
            engine.Start();
        }
    }
}       
