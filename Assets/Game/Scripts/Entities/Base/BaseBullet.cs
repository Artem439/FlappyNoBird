using System;
using Game.Scripts.Entities.Interfaces;
using UnityEngine;

namespace Game.Scripts.Entities.Base
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class BaseBullet : MonoBehaviour, ISpawnable<BaseBullet>
    {
        [SerializeField] private float _bulletSpeed = 20f;
        [SerializeField] protected float _damage = 1f;
        [SerializeField] private float _lifeTime = 3f;
        
        protected Rigidbody2D Rigidbody2D;
        protected Transform Owner;
        private float _lifeTimeLeft;
        
        public event Action<BaseBullet> Released;

        private void Awake()
        {
            Rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            _lifeTimeLeft -= Time.deltaTime;

            if (_lifeTimeLeft <= 0f)
                Release();
        }

        protected virtual void OnTriggerEnter2D(Collider2D other)
        {
            if (Owner != null && Owner.GetComponentInParent<Enemy.Enemy>() != null)
            {
                if (other.GetComponentInParent<Enemy.Enemy>() != null)
                    return;
            }

            if (other.TryGetComponent(out IDamageable damageable) == false)
                return;

            damageable.TakeDamage(_damage);
            Release();
        }
        
        public void Reset(Vector3 position)
        {
            Reset(position, transform.up);
        }

        public void Reset(Vector3 position, Vector2 direction)
        {
            Reset(position, direction, null);
        }

        public void Reset(Vector3 position, Vector2 direction, Transform owner)
        {
            Vector2 normalizedDirection = direction.sqrMagnitude > 0f
                ? direction.normalized
                : Vector2.right;

            Owner = owner;
            transform.position = position;
            transform.up = normalizedDirection;
            _lifeTimeLeft = _lifeTime;
            Rigidbody2D.velocity = normalizedDirection * _bulletSpeed;
        }

        private void Release()
        {
            Rigidbody2D.velocity = Vector2.zero;
            Released?.Invoke(this);
        }
    }
}
