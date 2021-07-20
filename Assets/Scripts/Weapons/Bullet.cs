using Obstacles;
using UnityEngine;

namespace Weapons
{
    public class Bullet : Projectile
    {
        protected override void OnTriggerEnter(Collider other)
        {
            var obstacle = other.GetComponent<Obstacle>();
            if (obstacle != null)
            {
                obstacle.TryDamage();
                Destroy(gameObject);
            }
        }
    }
}