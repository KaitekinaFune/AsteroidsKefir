using UnityEngine;
using Utils;

namespace Weapons
{
    public class ProjectileLauncher<T> where T: Projectile, new()
    {
        private ProjectileLauncherSettings settings { get; set; }
        private Transform shootPoint;
        
        private float nextFireTime;

        public void SetGameObject(GameObject playerShip)
        {
            shootPoint = playerShip.transform;
        }

        public virtual void SetSettings(ProjectileLauncherSettings settings)
        {
            this.settings = settings;
        }

        public void TryShootProjectile()
        {
            if (CanShoot())
            {
                nextFireTime = Time.time + 1f / settings.FireRate;
                Shoot();
            }
        }

        protected virtual bool CanShoot()
        {
            return Time.time >= nextFireTime;
        }

        protected virtual void Shoot()
        {
            var projectiles = ObjectPooler<T>.Instance.Get(1);
            
            foreach (var projectile in projectiles)
            {
                projectile.Launch(shootPoint, settings.ProjectileSpeed);
            }
        }
    }
}