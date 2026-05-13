using System;

namespace Game.Scripts.UI.Windows
{
    public class EndScreen : Window
    {
        public event Action RestartButtonClicked;

        public void Close()
        {
            WindowGroup.alpha = 0f;
            ActionButton.interactable = false;
        }

        public void Open()
        {
            WindowGroup.alpha = 1f;
            ActionButton.interactable = true;
        }

        protected override void OnButtonClick()
        {
            RestartButtonClicked?.Invoke();
        }
    }
}