using System;
using System.Linq;
using ThunderFighter.Controls;

namespace ThunderFighter.Screens
{
    internal class PauseScreen : ScreenBase
    {
        private readonly Engine engine;
        private readonly MessageBox messageBox;

        public PauseScreen(Engine engine)
        {
            this.engine = engine;

            this.messageBox = new MessageBox(
                this.engine.Field,
                "PAUSE!\nPress any key to continue...",
                MessageBoxDrawing.DrawCentered,
                MessageBoxTextAlignment.Center);
        }

        protected override void ShowOverride()
        {
            this.messageBox.Draw();
        }

        protected override void HideOverride()
        {
            this.messageBox.Clear();
        }

        protected override void HandleKeyDown(ConsoleKeyDownEventArgs args)
        {
            this.Hide();
            this.engine.GameStatus = GameStatus.Play;

            ScreenBuffer.DrawScreen();
        }
    }
}
