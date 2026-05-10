using System.Collections;
using Game.Scripts.Entities.Base.Spawner;
using UnityEngine;

namespace Game.Scripts.Entities.Enemy.Spawner
{
    public class EnemySpawner : SpawnerBase<Enemy>
    {
        [SerializeField] private float _spawnDelay;

        private void Start()
        {
            StartCoroutine(SpawnRoutine());
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