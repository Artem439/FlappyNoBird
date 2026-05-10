using System;
using Game.Scripts.Entities.Interfaces;
using UnityEngine;

namespace Game.Scripts.Entities.Enemy
{
    public class Enemy : MonoBehaviour, ISpawnable<Enemy>
    {
        public event Action<Enemy> Released;
        public void Reset(Vector3 position)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, -90f);
            transform.position = position;
        }
    }
}