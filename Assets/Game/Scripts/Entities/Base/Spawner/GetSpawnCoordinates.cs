using UnityEngine;

namespace Game.Scripts.Entities.Base.Spawner
{
    public class GetSpawnCoordinates : MonoBehaviour
    {
        [SerializeField] private UnityEngine.Camera _camera;
        [SerializeField] private float _margin;

        public float GetSpawnPoint()
        {
            Vector3 min = _camera.ViewportToWorldPoint(new Vector3(1f, 0f, transform.position.z));
            Vector3 max = _camera.ViewportToWorldPoint(new Vector3(1f, 1f, transform.position.z));

            return Random.Range(min.y + _margin, max.y - _margin);
        }
    }
}