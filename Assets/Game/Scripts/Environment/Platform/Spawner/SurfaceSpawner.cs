using System.Collections;
using Game.Scripts.Entities.Base.Spawner;
using UnityEngine;

namespace Game.Scripts.Environment.Platform.Spawner
{
    public class SurfaceSpawner : SpawnerBase<Surface>
    {
        [SerializeField] private float _spawnDelay;

        private void Start()
        {
            Spawn();
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