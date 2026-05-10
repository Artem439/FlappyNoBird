using System;
using Game.Scripts.Entities.Interfaces;
using UnityEngine;

namespace Game.Scripts.Entities.Base
{
    public class HealthBase : MonoBehaviour, IDamageable
    {
        [SerializeField] [Min(1)] private float _maxHealth;

        private float _currentHealth;

        public event Action Death;
        public event Action<float, float> HealthChanged;

        private void Start()
        {
            _currentHealth = _maxHealth;
        }

        public void TakeDamage(float damage)
        {
            if (damage <= 0)
                return;

            _currentHealth -= damage;
            _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);

            if (_currentHealth <= 0)
            {
                Death?.Invoke();
                _currentHealth = 0;
            }

            HealthChanged?.Invoke(_currentHealth, _maxHealth);
        }
    }
}