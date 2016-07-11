namespace ThunderFighter.Screens
{
    using System;
    using ThunderFighter.Controls;
    using ThunderFighter.Enums;

    internal class PauseScreen : ScreenBase
    {
        private readonly Engine engine;
        private readonly MessageBox messageBox;
        private DateTime timeBeforePause;

        public PauseScreen(Engine engine)
        {
            this.engine = engine;

            this.messageBox = new MessageBox(
                this.engine.Field,
                "PAUSE!\nPress any key to continue...",
                MessageBoxPosition.Center,
                MessageBoxTextAlignment.Center);
        }

        protected override void ShowOverride()
        {
            this.timeBeforePause = DateTime.Now;
            this.messageBox.Draw(true);
        }

        protected override void HideOverride()
        {
            this.messageBox.Clear();
        }

        protected override void HandleKeyDown(ConsoleKeyDownEventArgs args)
        {
            this.Hide();
            this.engine.GameStatus = GameStatus.Play;
            this.engine.StartTime += DateTime.Now - this.timeBeforePause;

            ScreenBuffer.DrawScreen();
        }
    }
}
