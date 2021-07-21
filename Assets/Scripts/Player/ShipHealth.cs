using System;
using UnityEngine;

namespace Player
{
    public class ShipHealth : MonoBehaviour
    {
        public event Action OnDeath;
        
        public void TakeDamage()
        {
            gameObject.SetActive(false);
            OnDeath?.Invoke();
        }

        private void Start()
        {
            RespawnManager.Instance.OnRespawn += OnRespawn;
        }

        private void OnDestroy()
        {
            RespawnManager.Instance.OnRespawn -= OnRespawn;
        }

        private void OnRespawn()
        {
            gameObject.SetActive(true);
        }
    }
}