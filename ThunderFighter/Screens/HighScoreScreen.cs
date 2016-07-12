namespace ThunderFighter.Screens
{
    using ThunderFighter.Controls;
    using ThunderFighter.Enums;

    internal class HighScoreScreen : ScreenBase
    {
        private readonly Engine engine;
        private readonly MessageBox messageBox;
        private string message;

        public HighScoreScreen(Engine engine)
        {
            this.engine = engine;
            this.messageBox = new MessageBox(
                this.engine.Field,
                "CONGRATULATIONS!\nYou hit a new high score: " + this.engine.Scores.HighestScore,
                MessageBoxPosition.Lower,
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
        }
    }
}