using System;
using Managers;
using UnityEngine;

namespace Ship
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
            GameOverManager.Instance.OnRespawn += OnRespawn;
        }

        private void OnDestroy()
        {
            GameOverManager.Instance.OnRespawn -= OnRespawn;
        }

        private void OnRespawn()
        {
            gameObject.SetActive(true);
        }
    }
}