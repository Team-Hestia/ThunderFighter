namespace ThunderFighter
{
    using Sidebar;
    using System;

    public static class Game
    {
        public static void Start()
        {
            var field = new Field(100, 40);
            var menu = new Menu(field);
            menu.CreateBase();

            ScreenBuffer.Initialize(field.Width, field.Height, ConsoleColor.Black, ConsoleColor.White);
            var player = new Fighters.ThunderFighterOne(field, new Point2D(10, 5));
            var level = GameLevel.Easy;

            Engine engine = new Engine(field, player, level);
            engine.Start();
        }
    }
}
