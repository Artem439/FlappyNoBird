using System;
using Game.Scripts.Entities.Base;
using Game.Scripts.Entities.Player.Movement;
using UnityEngine;

namespace Game.Scripts.Entities.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(SurfaceDetector), typeof(HealthBase))]
    public class Player : MonoBehaviour 
    {
        private SurfaceDetector _surfaceDetector;
        private HealthBase _health;
        
        public event Action GameOver;
        
        private void Awake()
        {
            _surfaceDetector = GetComponent<SurfaceDetector>();
            _health = GetComponent<HealthBase>();
        }

        private void OnEnable()
        {
            _surfaceDetector.IsSurfaceDetected += OnGameOver;
            _health.Death += OnGameOver;
        }

        private void OnDisable()
        {
            _surfaceDetector.IsSurfaceDetected -= OnGameOver;
            _health.Death -= OnGameOver;
        }
        
        private void OnGameOver()
        {
            GameOver?.Invoke();
            Time.timeScale = 0;
        }
    }
}