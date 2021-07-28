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
        
        var asteroidsPooler = new ObjectPooler<Asteroid>(asteroidsSpawnerSettings.SpawnerSettings.ObstaclePrefab);
        asteroidsPooler.Initialize();
        var asteroidsSpawner = new AsteroidsSpawner(asteroidsSpawnerSettings.SpawnerSettings);
        asteroidsSpawner.Initialize(asteroidsSpawnerSettings);
        
        var ufosPooler = new ObjectPooler<Ufo>(ufosSpawnerSettings.SpawnerSettings.ObstaclePrefab);
        ufosPooler.Initialize();
        var ufoSpawner = new UfosSpawner(asteroidsSpawnerSettings.SpawnerSettings);
        ufoSpawner.Initialize(ufosSpawnerSettings);
        
        ScoreManager.Initialize();
        GraphicsManager.Initialize();
        GameEventSystem.StartGame();
        
        Destroy(gameObject);
    }
}
