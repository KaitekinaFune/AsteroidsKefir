using UnityEngine;

namespace Weapons
{
    public class BulletLauncher : ProjectileLauncher
    {
        protected override bool CanShoot()
        {
            return Time.time >= nextFireTime;
        }
    }
}