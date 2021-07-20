using Player;
using UnityEngine;

namespace Obstacles
{
    public abstract class Obstacle : MonoBehaviour
    {
        public abstract void TryDamage();
        public abstract void DestroyObstacle();

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