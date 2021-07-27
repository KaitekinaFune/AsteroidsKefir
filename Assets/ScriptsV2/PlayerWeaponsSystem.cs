using Ship;
using UnityEngine;
using Weapons;

public class PlayerWeaponsSystem
{
    private readonly PlayerInputReader input;

    private readonly BulletLauncher bulletLauncher = new BulletLauncher();
    private readonly LaserLauncher laserLauncher = new LaserLauncher();
    
    public PlayerWeaponsSystem(GameObject playerShip, PlayerInputReader input, ShipSettings shipSettings)
    {
        this.input = input;

        bulletLauncher.SetGameObject(playerShip);
        bulletLauncher.SetSettings(shipSettings.BulletLauncherSettings);
        laserLauncher.SetGameObject(playerShip);
        laserLauncher.SetSettings(shipSettings.LaserLauncherSettings);
    }

    public void Enable()
    {
        input.OnShootPrimary += bulletLauncher.TryShootProjectile;
        input.OnShootSecondary += laserLauncher.TryShootProjectile;

        laserLauncher.ResetLasers();
    }

    public void Disable()
    {
        input.OnShootPrimary -= bulletLauncher.TryShootProjectile;
        input.OnShootSecondary -= laserLauncher.TryShootProjectile;
    }

    public void OnUpdate()
    {
        laserLauncher.OnUpdate();
    }
}
