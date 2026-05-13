using System;
using Game.Scripts.Entities.Interfaces;
using UnityEngine;

namespace Game.Scripts.Environment.Platform
{
    public class Surface : MonoBehaviour, ISpawnable<Surface>
    {
        public event Action<Surface> Released;
        
        public void Reset(Vector3 position)
        {
            transform.rotation = Quaternion.identity;
            transform.position = position;
        }
    }
}