using Game.Scripts.Entities.Enemy;
using TMPro;
using UnityEngine;

namespace Game.Scripts.UI
{
    public class ScoreCounter : MonoBehaviour
    {
        [SerializeField] private TMP_Text _scoreField;
        [SerializeField] private int _scoreAdditionValue;
        
        private int _scoreValue;

        private void OnEnable()
        {
            Enemy.OnDied += Counter;
        }

        private void OnDisable()
        {
            Enemy.OnDied -= Counter;
        }

        private void Counter()
        {
            _scoreValue += _scoreAdditionValue;
            _scoreField.text = _scoreValue.ToString();
        }
    }
}