using System;
using Game.Scripts.Entities.Interfaces;
using UnityEngine;

namespace Game.Scripts.Entities.Base
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bullet : MonoBehaviour, ISpawnable<Bullet>
    {
        [SerializeField] private float _bulletSpeed = 20f;
        [SerializeField] private float _damage = 1f;
        [SerializeField] private float _lifeTime = 3f;
        
        private Rigidbody2D _rigidbody2D;
        private Transform _owner;
        private float _lifeTimeLeft;
        
        public event Action<Bullet> Released;
        
        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            _lifeTimeLeft -= Time.deltaTime;

            if (_lifeTimeLeft <= 0f)
                Release();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (_owner != null && other.transform.root == _owner)
                return;

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

            _owner = owner;
            transform.position = position;
            transform.up = normalizedDirection;
            _lifeTimeLeft = _lifeTime;
            _rigidbody2D.velocity = normalizedDirection * _bulletSpeed;
        }

        private void Release()
        {
            _rigidbody2D.velocity = Vector2.zero;
            Released?.Invoke(this);
        }
    }
}
