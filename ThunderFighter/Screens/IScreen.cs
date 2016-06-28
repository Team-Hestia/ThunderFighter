using System;
using System.Linq;

namespace ThunderFighter.Screens
{
    public interface IScreen
    {
        bool IsShown { get; }

        void Show();
        void Hide();
    }
}