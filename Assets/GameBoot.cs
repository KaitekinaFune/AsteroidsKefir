using Graphics;
using Obstacles;
using Player;
using ScriptableObjects;
using UI;
using UnityEngine;
using Utils;
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

        var bulletPooler = new ObjectPooler<Bullet>(playerShipSettings.BulletLauncherSettings.ProjectilePrefab);
        bulletPooler.Initialize();
        var laserPooler = new ObjectPooler<Laser>(playerShipSettings.LaserLauncherSettings.ProjectilePrefab);
        laserPooler.Initialize();
        
        var asteroidsPooler = new ObjectPooler<Asteroid>(asteroidsSpawnerSettings.AsteroidPrefab);
        asteroidsPooler.Initialize();
        
        var asteroidsSpawner = new AsteroidsSpawner(obstacleSpawnerSettings);
        asteroidsSpawner.Initialize(asteroidsSpawnerSettings);
        
        var ufosPooler = new ObjectPooler<Ufo>(ufosSpawnerSettings.UfoPrefab);
        ufosPooler.Initialize();
        
        var ufoSpawner = new UfosSpawner(obstacleSpawnerSettings);
        ufoSpawner.Initialize(ufosSpawnerSettings);
        
        
        ScoreManager.Initialize();
        GraphicsManager.Initialize();
        GameEventSystem.StartGame();
        Destroy(gameObject);
    }
}
