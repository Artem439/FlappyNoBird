using System;
using Game.Scripts.Entities.Interfaces;
using UnityEngine;

namespace Game.Scripts.Entities.Player.Movement
{
    public class EnemyDetector : MonoBehaviour
    {
        public event Action Faced;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out IDamageable _))
                Faced?.Invoke();
        }
    }
}