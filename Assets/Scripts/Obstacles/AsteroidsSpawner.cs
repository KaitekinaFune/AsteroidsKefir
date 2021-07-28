using ScriptableObjects;
using UnityEngine;
using Utils;

namespace Obstacles
{
    public class AsteroidsSpawner : ObstacleSpawner
    {
        private AsteroidsSpawnerSettings asteroidsSpawnerSettings;
        
        public void Initialize(AsteroidsSpawnerSettings spawnerSettings)
        {
            asteroidsSpawnerSettings = spawnerSettings;
            Asteroid.OnAsteroidShattered += OnAsteroidShattered;
        }

        protected override void SpawnObstacles()
        {
            var obstacles = ObjectPooler<Asteroid>.Instance.Get(settings.ObstaclesToSpawn);

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
        }

        private void OnAsteroidShattered(Asteroid oldAsteroid)
        {
            var shattersAmount = asteroidsSpawnerSettings.ShattersAmount;
            var obstacles = ObjectPooler<Asteroid>.Instance.Get(shattersAmount);

            foreach (var obstacle in obstacles)
            {
                var asteroid = (Asteroid) obstacle;
                SpawnShatteredAsteroid(oldAsteroid, asteroid);
            }
            
            ObjectPooler<Asteroid>.Instance.ReturnObjectToPool(oldAsteroid);
        }

        private void SpawnShatteredAsteroid(Asteroid oldAsteroid, Asteroid newAsteroid)
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