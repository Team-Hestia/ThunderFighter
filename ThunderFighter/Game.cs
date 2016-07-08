namespace ThunderFighter
{
    using ThunderFighter.Enums;

    public static class Game
    {
        public static void Start()
        {
            var theme = new Theme(ThemeColor.Blue);
            var field = new Field(theme, 130, 40);
            ScreenBuffer.Initialize(field.Width, field.Height, Theme.Contrast, Theme.BackGround);
            
            Engine engine = new Engine(field);
            engine.Start();
        }
    }
}       
