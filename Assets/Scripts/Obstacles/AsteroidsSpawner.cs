using UnityEngine;
using Utils;

namespace Obstacles
{
    public class AsteroidsSpawner : ObstacleSpawner
    {
        [Header("Asteroids Settings")] 
        [SerializeField] private float speed;
        [SerializeField] private MinMaxFloat sizeMinMax;

        [Header("Shatter Settings")] 
        [SerializeField] private MinMaxInt asteroidsShattersAmountMinMax;
        [SerializeField] private MinMaxFloat shatterAsteroidSizeRatioMinMax;
        
        protected override void SpawnObstacles()
        {
            var asteroids = AsteroidsPool.Instance.Get(obstaclesToSpawn);

            foreach (var asteroid in asteroids)
            {
                SpawnObstacle(asteroid);
            }
        }

        private void SpawnObstacle(Asteroid asteroid)
        {
            var scale = Vector3.one * sizeMinMax.GetRandom();
            asteroid.SetSize(scale);
            
            var spawnPoint = GetRandomSpawnPoint(scale.x / 2f);
            asteroid.SetPosition(spawnPoint);
            
            var speedRatio = speed / scale.x;
            var direction = GetRandomDirection(spawnPoint);
            asteroid.FirstLaunch(-direction, speedRatio);
            asteroid.OnAsteroidShattered += OnAsteroidShattered;
        }

        private void OnAsteroidShattered(Asteroid oldAsteroid)
        {
            var shattersAmount = asteroidsShattersAmountMinMax.GetRandom();
            var asteroids = AsteroidsPool.Instance.Get(shattersAmount);

            foreach (var asteroid in asteroids)
            {
                SpawnAsteroidOnShatter(oldAsteroid, asteroid);
            }
            
            AsteroidsPool.Instance.ReturnObstacleToPool(oldAsteroid);
        }

        private void SpawnAsteroidOnShatter(Asteroid oldAsteroid, Asteroid newAsteroid)
        {
            var oldTransform = oldAsteroid.transform;

            var ratio = shatterAsteroidSizeRatioMinMax.GetRandom();
            var scale = oldTransform.localScale / ratio;
            newAsteroid.SetSize(scale);
            
            var spawnPoint = oldTransform.position;
            newAsteroid.SetPosition(spawnPoint);

            var direction = GetRandomDirection(spawnPoint);
            var newAsteroidSpeed = ratio * oldAsteroid.initialSpeed;
            newAsteroid.LaunchShattered(-direction, newAsteroidSpeed);
        }
    }
}