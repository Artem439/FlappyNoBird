using System;
using Game.Scripts.Entities.Interfaces;
using UnityEngine;

namespace Game.Scripts.Entities.Base
{
    public class HealthBase : MonoBehaviour, IDamageable
    {
        [SerializeField] [Min(1)] private float _maxHealth;

        private float _currentHealth;
        private bool _isDead;

        public event Action Death;
        public event Action<float, float> HealthChanged;

        private void Start()
        {
            ResetHealth();
        }

        public void ResetHealth()
        {
            _currentHealth = _maxHealth;
            _isDead = false;
            HealthChanged?.Invoke(_currentHealth, _maxHealth);
        }

        public void TakeDamage(float damage)
        {
            if (damage <= 0 || _isDead)
                return;

            _currentHealth -= damage;
            _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);

            if (_currentHealth <= 0)
            {
                _currentHealth = 0;
                _isDead = true;
                Death?.Invoke();
            }

            HealthChanged?.Invoke(_currentHealth, _maxHealth);
        }
    }
}
