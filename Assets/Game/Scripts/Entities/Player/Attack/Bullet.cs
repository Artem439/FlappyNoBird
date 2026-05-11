using System;
using Game.Scripts.Entities.Interfaces;
using UnityEngine;

namespace Game.Scripts.Entities.Player.Attack
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bullet : MonoBehaviour, ISpawnable<Bullet>
    {
        [SerializeField] private float _bulletSpeed = 20f;
        [SerializeField] private float _lifeTime = 3f;
        
        private Rigidbody2D _rigidbody2D;
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

        public void Reset(Vector3 position)
        {
            Reset(position, transform.up);
        }

        public void Reset(Vector3 position, Vector2 direction)
        {
            Vector2 normalizedDirection = direction.sqrMagnitude > 0f
                ? direction.normalized
                : Vector2.right;

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
