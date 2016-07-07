namespace ThunderFighter.Screens
{
    using ThunderFighter.Controls;

    internal class GameOverScreen : ScreenBase
    {
        private readonly Engine engine;
        private readonly MessageBox messageBox;

        public GameOverScreen(Engine engine)
        {
            this.engine = engine;

            this.messageBox = new MessageBox(
                this.engine.Field,
                "GAME OVER!\nPress any key to continue...",
                MessageBoxDrawing.DrawCentered,
                MessageBoxTextAlignment.Center);
        }

        protected override void ShowOverride()
        {
            this.messageBox.Draw(true);
        }

        protected override void HideOverride()
        {
            this.messageBox.Clear();
        }

        protected override void HandleKeyDown(ConsoleKeyDownEventArgs args)
        {
            this.Hide();
            this.engine.GameStatus = GameStatus.Welcome;

            ScreenBuffer.DrawScreen();
        }
    }
}