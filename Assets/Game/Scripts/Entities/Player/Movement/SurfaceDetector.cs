using System;
using UnityEngine;

namespace Game.Scripts.Entities.Player.Movement
{
    public class SurfaceDetector : MonoBehaviour
    {
        [SerializeField] private LayerMask _surfaceLayer;
        [SerializeField] private Transform _rayOrigin;
        
        [SerializeField] private float _rayDistance = 0.01f;
        
        public event Action IsSurfaceDetected;

        private void Update()
        {
            if (IsSurface())
                IsSurfaceDetected?.Invoke();
        }
        
        private bool IsSurface()
        {
            return Physics2D.Raycast(_rayOrigin.position, Vector2.down, _rayDistance, _surfaceLayer);
        }
    }
}