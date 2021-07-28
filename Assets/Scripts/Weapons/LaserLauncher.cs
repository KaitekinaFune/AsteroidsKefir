using ScriptableObjects;
using UnityEngine;

namespace Weapons
{
    public class LaserLauncher : ProjectileLauncher<Laser>
    {
        private LaserLauncherSettings settings;
        
        private int lasersLeft;
        private float nextLaserRestockTime;
        
        public void ResetLasers()
        {
            lasersLeft = settings.MaxLasers;
        }

        public override void SetSettings(ProjectileLauncherSettings settings)
        {
            base.SetSettings(settings);

            if (settings is LaserLauncherSettings laserSettings)
            {
                this.settings = laserSettings;
            }
        }

        protected override bool CanShoot()
        {
            return base.CanShoot() && lasersLeft > 0;
        }
        
        protected override void Shoot()
        {
            lasersLeft--;
            base.Shoot();
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