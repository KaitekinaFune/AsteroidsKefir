using UnityEngine;

namespace Weapons
{
    public class BulletLauncher : ProjectileLauncher
    {
        public override void TryShootProjectile()
        {
            if (CanShoot())
            {
                nextFireTime = Time.time + 1f / settings.FireRate;
                Shoot();
            }
        }

        private bool CanShoot()
        {
            return Time.time >= nextFireTime;
        }

        private void Shoot()
        {
            var bullets = BulletPooler.Instance.Get(1);
            
            foreach (var bullet in bullets)
            {
                bullet.Launch(shootPoint, settings.ProjectileSpeed);
            }
        }
    }
}