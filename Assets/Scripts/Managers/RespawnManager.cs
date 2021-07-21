using System;
using Obstacles;
using Player;
using UnityEngine;
using Weapons;

namespace Managers
{
    public class RespawnManager : MonoBehaviour
    {
        public static RespawnManager Instance;

        [SerializeField]
        private ShipHealth shipHealth;
    
        public event Action OnRespawn;
        public event Action OnDeath;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }

            shipHealth.OnDeath += Die;
            Respawn();
        }

        public void Respawn()
        {
            OnRespawn?.Invoke();

            var projectiles = FindObjectsOfType<Projectile>();
            var obstacles = FindObjectsOfType<Obstacle>();

            foreach (var projectile in projectiles)
            {
                Destroy(projectile.gameObject);
            }

            foreach (var obstacle in obstacles)
            {
                obstacle.DestroyObstacleSilent();
            }
        }

        private void Die()
        {
            OnDeath?.Invoke();
        }
    }
}