using UnityEngine;

namespace Game.Scripts.Entities.Enemy.Spawner
{
    public class EnemyRemover : MonoBehaviour
    {
        [SerializeField] private EnemyPool _enemyPool;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<Enemy>(out Enemy enemy))
                _enemyPool.Release(enemy);
        }
    }
}