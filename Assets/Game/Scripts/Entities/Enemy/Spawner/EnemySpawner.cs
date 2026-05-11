using System.Collections;
using Game.Scripts.Entities.Base.Spawner;
using UnityEngine;

namespace Game.Scripts.Entities.Enemy.Spawner
{
    public class EnemySpawner : SpawnerBase<Enemy>
    {
        [SerializeField] private float _spawnDelay;
        [SerializeField] private GetSpawnCoordinates _spawnCoordinates;

        private void Start()
        {
            StartCoroutine(SpawnRoutine());
        }

        protected override void Spawn()
        {
            Vector3 spawnPoint = new Vector3(transform.position.x, _spawnCoordinates.GetSpawnPoint(), transform.position.z);
            
            Enemy entity = _entitiesPool.Get();
            
            entity.Reset(spawnPoint);
            
            entity.Released += OnReleased;
        }
        
        private IEnumerator SpawnRoutine()
        {
            WaitForSeconds delay = new WaitForSeconds(_spawnDelay);

            while (enabled)
            {
                yield return delay;
                Spawn();
            }
        }
    }
}