using UnityEngine;

namespace Weapons
{
    public class Bullet : Projectile
    {
        protected override void OnTriggerEnter(Collider other)
        {
            var damageableObject = other.GetComponent<IDamageable>();
            damageableObject?.TryDamage();
            Destroy(gameObject);
        }
    }
}
