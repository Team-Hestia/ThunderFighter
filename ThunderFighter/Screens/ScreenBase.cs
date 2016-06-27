using System;
using System.Linq;
using ThunderFighter.Controls;

namespace ThunderFighter.Screens
{
    public abstract class ScreenBase : IScreen
    {
        private bool isShown;

        public bool IsShown
        {
            get
            {
                return this.isShown;
            }
        }

        public void Show()
        {
            if (!this.isShown)
            {
                ConsoleKeyboardHandler.Instance.KeyDown += this.Instance_KeyDown;

                this.ShowOverride();
                this.isShown = true;
            }
        }

        private void Instance_KeyDown(object sender, ConsoleKeyDownEventArgs e)
        {
            this.HandleKeyDown(e);
        }

        public void Hide()
        {
            if (this.isShown)
            {
                ConsoleKeyboardHandler.Instance.KeyDown -= this.Instance_KeyDown;

                this.HideOverride();
                this.isShown = false;
            }
        }

        protected abstract void ShowOverride();
        protected abstract void HideOverride();

        protected virtual void HandleKeyDown(ConsoleKeyDownEventArgs args)
        {
        }
    }
}