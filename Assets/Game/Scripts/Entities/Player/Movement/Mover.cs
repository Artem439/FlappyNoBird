using Game.Scripts.Controls;
using UnityEngine;

namespace Game.Scripts.Entities.Player.Movement
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(InputReader))]
    public class Mover : MonoBehaviour
    {
        [SerializeField] private float _tapForce;
        [SerializeField] private float _speed;
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private float _maxRotationZ;
        [SerializeField] private float _minRotationZ;
    
        private Rigidbody2D _rigidbody2D;
        private Quaternion _maxRotation;
        private Quaternion _minRotation;
    
        private InputReader _inputReader;
        
        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        
            _inputReader = GetComponent<InputReader>();
            
            _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);
            _minRotation = Quaternion.Euler(0, 0, _minRotationZ);
        }

        private void OnEnable()
        {
            _inputReader.JumpButtonClicked += Move;
        }

        private void OnDisable()
        {
            _inputReader.JumpButtonClicked -= Move;
        }

        private void Update()
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
        }

        private void Move()
        {
            _rigidbody2D.velocity = new Vector2(_speed, _tapForce);
            transform.rotation = _maxRotation;
        }
    }
}
