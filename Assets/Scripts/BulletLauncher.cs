using UnityEngine;

public class BulletLauncher : ProjectileLauncher
{
    protected override bool CanShoot()
    {
        return Time.time >= nextFireTime;
    }

    private void OnEnable()
    {
        input.OnShootPrimary += TryShootProjectile;
    }

    private void OnDisable()
    {
        input.OnShootPrimary -= TryShootProjectile;
    }
}
