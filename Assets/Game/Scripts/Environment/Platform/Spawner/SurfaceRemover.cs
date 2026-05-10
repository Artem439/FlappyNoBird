using UnityEngine;

namespace Game.Scripts.Environment.Platform.Spawner
{
    public class SurfaceRemover : MonoBehaviour
    {
        [SerializeField] private SurfacePool _surfacePool;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<Surface>(out Surface enemy))
                _surfacePool.Release(enemy);
        }
    }
}