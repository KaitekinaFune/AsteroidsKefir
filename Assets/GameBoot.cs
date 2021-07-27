using Obstacles;
using Ship;
using UnityEngine;
using Weapons;

public class GameBoot : MonoBehaviour
{
    [SerializeField] private ShipSettings playerShipSettings;
    [SerializeField] private ObstaclesSpawnerSettings obstacleSpawnerSettings;
    [SerializeField] private AsteroidsSpawnerSettings asteroidsSpawnerSettings;
    [SerializeField] private UfosSpawnerSettings ufosSpawnerSettings;
    
    public void BootGame()
    {
        var playerController = new PlayerController(playerShipSettings);
        playerController.Initialize();

        var bulletPooler = new BulletPooler(playerShipSettings.BulletLauncherSettings.ProjectilePrefab);
        bulletPooler.Initialize();
        var laserPooler = new LaserPooler(playerShipSettings.LaserLauncherSettings.ProjectilePrefab);
        laserPooler.Initialize();
        
        var asteroidsPooler = new AsteroidsPool(asteroidsSpawnerSettings.AsteroidPrefab);
        asteroidsPooler.Initialize();
        
        var asteroidsSpawner = new AsteroidsSpawner(obstacleSpawnerSettings);
        asteroidsSpawner.Initialize(asteroidsSpawnerSettings);
        
        /*
        var ufosPooler = new UfosPool(ufoPrefab);
        ufosPooler.Initialize();
        
        var ufoSpawner = new UfosSpawner(obstacleSpawnerSettings);
        ufoSpawner.Initialize(ufosSpawnerSettings);
        */
        
        Destroy(gameObject);
    }
}
