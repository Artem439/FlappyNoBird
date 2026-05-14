using Game.Scripts.Entities.Player;
using Game.Scripts.Environment.Platform.Spawner;
using Game.Scripts.UI.Windows;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Scripts
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private SurfaceSpawner _surfaceSpawner;
        [SerializeField] private StartScreen _startScreen;
        [SerializeField] private EndScreen _endScreen;
        [SerializeField] private CanvasGroup _gameUI;

        private void OnEnable()
        {
            _player.GameOver += OnGameOver;
            _startScreen.PlayButtonClicked += OnPlayButtonClick;
            _endScreen.RestartButtonClicked += OnRestartButtonClick;
        }

        private void OnDisable()
        {
            _player.GameOver -= OnGameOver;
            _startScreen.PlayButtonClicked -= OnPlayButtonClick;
            _endScreen.RestartButtonClicked -= OnRestartButtonClick;
        }
        
        private void Start()
        {
            Time.timeScale = 0;
            _startScreen.Open();
        }

        private void OnPlayButtonClick()
        {
            _startScreen.Close();
            StartGame();
        }
        
        private void OnRestartButtonClick()
        {
            _endScreen.Close();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        private void StartGame()
        {
            _gameUI.alpha = 1f;
            Time.timeScale = 1;
        }

        private void OnGameOver()
        {
            _gameUI.alpha = 0f;
            _endScreen.Open();
            Time.timeScale = 0;
        }
    }
}