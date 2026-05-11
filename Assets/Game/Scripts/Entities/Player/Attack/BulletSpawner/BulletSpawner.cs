using Game.Scripts.Entities.Base.Spawner;
using UnityEngine;

namespace Game.Scripts.Entities.Player.Attack.BulletSpawner
{
    public class BulletSpawner : SpawnerBase<Bullet>
    {
        public void Shoot()
        {
            Spawn();
        }

        protected override void Spawn()
        {
            Bullet bullet = _entitiesPool.Get();
            
            bullet.Reset(transform.position, transform.up);
            bullet.Released += OnReleased;
        }
    }
}
