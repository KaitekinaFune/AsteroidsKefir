using UnityEngine;

namespace Weapons
{
    public class Laser : Projectile
    {
        protected override void OnTriggerEnter(Collider other)
        {
            var damageableObject = other.GetComponent<IDamageable>();
            damageableObject?.DestroyObject();
            Destroy(gameObject);
        }
    }
}
