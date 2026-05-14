using System.Collections;
using Game.Scripts.Entities.Base;
using Game.Scripts.Entities.Base.Spawner;
using UnityEngine;

namespace Game.Scripts.Entities.Enemy.Attack.BulletSpawner
{
    public class BulletSpawner : SpawnerBase<BaseBullet>
    {
        [SerializeField] [Min(0.1f)] private float _shootInterval = 2f;

        private Coroutine _shootRoutine;

        private void OnEnable()
        {
            _shootRoutine = StartCoroutine(ShootRoutine());
        }

        private void OnDisable()
        {
            if (_shootRoutine != null)
                StopCoroutine(_shootRoutine);

            _shootRoutine = null;
        }

        protected override void Spawn()
        {
            BaseBullet baseBullet = _entitiesPool.Get();

            baseBullet.Init(transform.position, -transform.up, transform.root);
            baseBullet.Released += OnReleased;
        }

        private IEnumerator ShootRoutine()
        {
            WaitForSeconds delay = new WaitForSeconds(_shootInterval);
            
            yield return null;

            while (enabled)
            {
                Spawn();
                yield return delay;
            }
        }
    }
}
