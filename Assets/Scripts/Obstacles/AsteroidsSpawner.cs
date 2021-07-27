using UnityEngine;
namespace Obstacles
{
    public class AsteroidsSpawner : ObstacleSpawner
    {
        private AsteroidsSpawnerSettings asteroidsSpawnerSettings;
        
        public void Initialize(AsteroidsSpawnerSettings spawnerSettings)
        {
            asteroidsSpawnerSettings = spawnerSettings;
        }

        protected override void SpawnObstacles()
        {
            var obstacles = AsteroidsPool.Instance.Get(settings.ObstaclesToSpawn);

            foreach (var obstacle in obstacles)
            {
                var asteroid = (Asteroid) obstacle;
                SpawnObstacle(asteroid);
            }
        }

        private void SpawnObstacle(Asteroid asteroid)
        {
            var scale = Vector3.one * asteroidsSpawnerSettings.Size;
            asteroid.SetSize(scale);
            
            var spawnPoint = GetRandomSpawnPoint(scale.x / 2f);
            asteroid.SetPosition(spawnPoint);
            
            var speedRatio = asteroidsSpawnerSettings.Speed / scale.x;
            var direction = GetRandomDirection(spawnPoint);
            asteroid.FirstLaunch(-direction, speedRatio);
            asteroid.OnAsteroidShattered += OnAsteroidShattered;
        }

        private void OnAsteroidShattered(Asteroid oldAsteroid)
        {
            var shattersAmount = asteroidsSpawnerSettings.ShattersAmount;
            var obstacles = AsteroidsPool.Instance.Get(shattersAmount);

            foreach (var obstacle in obstacles)
            {
                var asteroid = (Asteroid) obstacle;
                SpawnAsteroidOnShatter(oldAsteroid, asteroid);
            }
            
            AsteroidsPool.Instance.ReturnObjectToPool(oldAsteroid);
        }

        private void SpawnAsteroidOnShatter(Asteroid oldAsteroid, Asteroid newAsteroid)
        {
            var oldTransform = oldAsteroid.gameObject.transform;

            var ratio = asteroidsSpawnerSettings.ShatterSize;
            var scale = oldTransform.localScale / ratio;
            newAsteroid.SetSize(scale);
            
            var spawnPoint = oldTransform.position;
            newAsteroid.SetPosition(spawnPoint);

            var direction = GetRandomDirection(spawnPoint);
            var newAsteroidSpeed = ratio * oldAsteroid.initialSpeed;
            newAsteroid.LaunchShattered(-direction, newAsteroidSpeed);
        }

        public AsteroidsSpawner(ObstaclesSpawnerSettings settingsAssetName) : base(settingsAssetName)
        {
        }
    }
}