using UnityEngine;

public class BulletLauncher : ProjectileLauncher
{
    protected override bool CanShoot()
    {
        return Time.time >= nextFireTime;
    }
}
