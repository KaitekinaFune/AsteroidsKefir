using UnityEngine;

namespace Weapons
{
    public class LaserLauncher : ProjectileLauncher
    {
        private new LaserLauncherSettings settings;

        private int lasersLeft;
        private float nextLaserRestockTime;

        public void SetSettings(LaserLauncherSettings settings)
        {
            this.settings = settings;
        }

        public void ResetLasers()
        {
            lasersLeft = settings.MaxLasers;
        }

        private bool CanShoot()
        {
            return lasersLeft > 0 && Time.time >= nextFireTime;
        }

        private void Shoot()
        {
            lasersLeft--;
        }

        public override void TryShootProjectile()
        {
            if (CanShoot())
            {
                nextFireTime = Time.time + 1f / settings.FireRate;
                Shoot();
            }
        }

        public void OnUpdate()
        {
            if (lasersLeft < settings.MaxLasers)
            {
                TryRestockLasers();
            }
        }

        private void TryRestockLasers()
        {
            if (Time.time > nextLaserRestockTime)
            {
                lasersLeft++;
                nextLaserRestockTime = Time.time + 1f / settings.LasersRestockRate;
            }
        }
    }
}