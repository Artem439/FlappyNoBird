using Game.Scripts.Controls;
using UnityEngine;

namespace Game.Scripts.Entities.Player.Attack
{
    [RequireComponent(typeof(InputReader))]
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private BulletSpawner.BulletSpawner _bulletSpawner;
        
        private InputReader _inputReader;

        private void Awake()
        {
            _inputReader = GetComponent<InputReader>();
        }

        private void OnEnable()
        {
            _inputReader.ShutButtonClicked += Shot;
        }

        private void OnDisable()
        {
            _inputReader.ShutButtonClicked -= Shot;
        }

        private void Shot()
        {
            _bulletSpawner.Shoot();
        }
    }
}
