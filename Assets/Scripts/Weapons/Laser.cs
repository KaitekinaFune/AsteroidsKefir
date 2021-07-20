using Obstacles;
using UnityEngine;

namespace Weapons
{
    public class Laser : Projectile
    {
        protected override void OnTriggerEnter(Collider other)
        {
            var obstacle = other.GetComponent<Obstacle>();
            if (obstacle != null)
            {
                obstacle.DestroyObstacle();
                Destroy(gameObject);
            }
        }
    }
}