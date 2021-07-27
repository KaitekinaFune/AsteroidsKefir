using System;
using Obstacles;
using Ship;
using UnityEngine;
using Weapons;

namespace Managers
{
    public class GameOverManager : MonoBehaviour
    {
        public static GameOverManager Instance;

        [SerializeField]
        private ShipHealth playerShip;
    
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

            playerShip.OnDeath += Die;
            Respawn();
        }

        public void Respawn()
        {
            OnRespawn?.Invoke();

            /*
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
            */
        }

        private void Die()
        {
            OnDeath?.Invoke();
        }
    }
}