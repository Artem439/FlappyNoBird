using UnityEngine;

namespace Game.Scripts.Entities.Base.Spawner
{
    public class RemoveBase<T> : MonoBehaviour where T : Component
    {
        [SerializeField] private PoolBase<T> _pool;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out T enemy))
                _pool.Release(enemy);
        }
    }
}