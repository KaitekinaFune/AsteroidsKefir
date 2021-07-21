using Ship;
using UnityEngine;

namespace Obstacles
{
    public abstract class Obstacle : MonoBehaviour
    {
        protected Rigidbody rb;
        
        public abstract void TryDamage();
        public abstract void DestroyObstacle();
        public abstract void DestroyObstacleSilent();
        
        protected virtual void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        public void SetPosition(Vector3 spawnPoint)
        {
            transform.position = spawnPoint;
        }
        
        private void OnTriggerEnter(Collider other)
        {
            var ship = other.GetComponent<ShipHealth>();
            if (ship != null)
            {
                ship.TakeDamage();
            }
        }
    }
}