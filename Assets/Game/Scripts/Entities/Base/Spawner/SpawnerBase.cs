using Game.Scripts.Entities.Interfaces;
using UnityEngine;

namespace Game.Scripts.Entities.Base.Spawner
{
    public abstract class SpawnerBase<T> : MonoBehaviour where T : Component, ISpawnable<T>
    {
        [SerializeField] protected PoolBase<T> _entitiesPool;
        
        protected virtual void Spawn()
        {
            Vector3 spawnPoint = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            
            T entity = _entitiesPool.Get();
            
            entity.Reset(spawnPoint);
            
            entity.Released += OnReleased;
        }

        protected virtual void OnReleased(T entity)
        {
            entity.Released -= OnReleased;
        
            _entitiesPool.Release(entity);
        }
    }
}