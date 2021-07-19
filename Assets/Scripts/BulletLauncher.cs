public class BulletLauncher : ProjectileLauncher
{
    protected override void Shoot()
    {
        
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
