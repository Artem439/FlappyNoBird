using System.Collections;
using Game.Scripts.Entities.Base;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.UI
{
    [RequireComponent(typeof(Slider))]
    public class SmoothBarChanger : MonoBehaviour
    {
        private const float Epsilon = 0.00001f;
        
        [SerializeField] private HealthBase _playerHealth;
        [SerializeField] private float _speed;
        
        private Slider _slider;
        private Coroutine _coroutine;

        private void Awake()
        {
            _slider = GetComponent<Slider>();
        }
        
        private void OnEnable()
        {
            _playerHealth.HealthChanged += OnHealthChanged;
        }

        private void OnDisable()
        {
            _playerHealth.HealthChanged -= OnHealthChanged;
        }
        
        private void OnHealthChanged(float currentHealth, float maxHealth)
        {
            if (_coroutine != null)
                StopCoroutine(_coroutine);

            _coroutine = StartCoroutine(SmoothChangBarCoroutine(currentHealth, maxHealth));
        }

        private IEnumerator SmoothChangBarCoroutine(float currentHealth, float maxHealth)
        {
            while (Mathf.Abs(_slider.value - currentHealth / maxHealth) > Epsilon)
            {
                _slider.value = Mathf.MoveTowards(_slider.value, currentHealth / maxHealth, _speed * Time.deltaTime);
                
                yield return null;
            }
        }
    }
}