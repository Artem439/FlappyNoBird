using Game.Scripts.Entities.Player;
using Game.Scripts.Environment.Platform.Spawner;
using Game.Scripts.UI.Windows;
using UnityEngine;

namespace Game.Scripts
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private SurfaceSpawner _surfaceSpawner;
        [SerializeField] private StartScreen _startScreen;
        [SerializeField] private EndScreen _endScreen;

        private void OnEnable()
        {
            _startScreen.PlayButtonClicked += OnPlayButtonClick;
            _endScreen.RestartButtonClicked += OnRestartButtonClick;
        }

        private void OnDisable()
        {
            _startScreen.PlayButtonClicked -= OnPlayButtonClick;
            _endScreen.RestartButtonClicked -= OnRestartButtonClick;
        }

        private void OnPlayButtonClick()
        {
            _startScreen.Close();
            StartGame();
        }
        
        private void OnRestartButtonClick()
        {
            _endScreen.Close();
            StartGame();
        }

        private void StartGame()
        {
            Time.timeScale = 1;
        }
    }
}