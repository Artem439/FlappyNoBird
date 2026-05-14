using System;
using Game.Scripts.Entities.Base;
using Game.Scripts.Entities.Interfaces;
using UnityEngine;

namespace Game.Scripts.Entities.Enemy
{
    [RequireComponent(typeof(HealthBase))]
    public class Enemy : MonoBehaviour, ISpawnable<Enemy>
    {
        public static event Action OnDied;
        
        public event Action<Enemy> Released;
        
        private HealthBase _health;

        private void Awake()
        {
            _health = GetComponent<HealthBase>();
        }

        private void OnEnable()
        {
            _health.Death += OnDeath;
        }

        private void OnDisable()
        {
            _health.Death -= OnDeath;
        }

        public void Reset(Vector3 position)
        {
            _health.ResetHealth();
            transform.rotation = Quaternion.Euler(0f, 0f, -90f);
            transform.position = position;
        }

        private void OnDeath()
        {
            Released?.Invoke(this);
            OnDied?.Invoke();
        }
    }
}
