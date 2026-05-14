using System;
using UnityEngine;

namespace Game.Scripts.UI.Windows
{
    public class StartScreen : Window
    {
        public event Action PlayButtonClicked;

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
            PlayButtonClicked?.Invoke();
        }
    }
}