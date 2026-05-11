using System;
using UnityEngine;

namespace Game.Scripts.Controls
{
    public class InputReader : MonoBehaviour
    {
        private const KeyCode JumpButton = KeyCode.Space;
        private const KeyCode ShutButton = KeyCode.Mouse0;
        
        public event Action JumpButtonClicked;
        public event Action ShutButtonClicked;

        private void Update()
        {
            if (Input.GetKey(JumpButton))
                JumpButtonClicked?.Invoke();
            
            if (Input.GetKeyDown(ShutButton))
                ShutButtonClicked?.Invoke();
        }
    }
}
