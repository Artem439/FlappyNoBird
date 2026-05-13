using Game.Scripts.Entities.Base;
using Game.Scripts.Entities.Base.Spawner;
using UnityEngine;

namespace Game.Scripts.Entities.Player.Attack.BulletSpawner
{
    public class BulletSpawner : SpawnerBase<BaseBullet>
    {
        public void Shoot()
        {
            Spawn();
        }

        protected override void Spawn()
        {
            BaseBullet baseBullet = _entitiesPool.Get();
            
            baseBullet.Reset(transform.position, transform.up, transform.root);
            baseBullet.Released += OnReleased;
        }
    }
}
