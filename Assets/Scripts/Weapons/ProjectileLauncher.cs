using UnityEngine;

namespace Weapons
{
    public abstract class ProjectileLauncher
    {
        protected ProjectileLauncherSettings settings;
        protected Transform shootPoint;
        
        protected float nextFireTime;

        public void SetGameObject(GameObject playerShip)
        {
            shootPoint = playerShip.transform;
        }

        public void SetSettings(ProjectileLauncherSettings settings)
        {
            this.settings = settings;
        }

        public abstract void TryShootProjectile();
    }
}