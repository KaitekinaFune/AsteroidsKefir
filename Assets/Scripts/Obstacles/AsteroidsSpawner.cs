using UnityEngine;
using Utils;

namespace Obstacles
{
    public class AsteroidsSpawner : MonoBehaviour
    {
        [Header("Spawn Settings")]
        [SerializeField] private float spawnRate = 1f;
        [SerializeField] private float spawnDistance = 20f;
        [SerializeField] private float trajectoryDistance = 15f;
        [SerializeField] private int asteroidsToSpawn = 1;
        
        [Header("Asteroids Settings")]
        [SerializeField] private float speed;
        [SerializeField] private MinMaxFloat sizeMinMax;
        
        [Header("Shatter Settings")]
        [SerializeField] private MinMaxInt asteroidsShattersAmountMinMax;
        [SerializeField] private MinMaxFloat shatterAsteroidSizeRatioMinMax;

        private void Start()
        {
            InvokeRepeating(nameof(SpawnAsteroids), spawnRate, spawnRate);
        }

        private void SpawnAsteroids()
        {
            var asteroids = AsteroidsPool.Instance.Get(asteroidsToSpawn);

            foreach (var asteroid in asteroids)
            {
                SpawnAsteroid(asteroid);
            }
        }

        private void SpawnAsteroid(Asteroid asteroid)
        {
            Vector3 scale = Vector3.one * sizeMinMax.GetRandom();
            asteroid.SetSize(scale);
            
            Vector3 spawnDirection = Random.insideUnitCircle.normalized * spawnDistance;
            Vector3 spawnPoint = transform.position + spawnDirection;
            asteroid.SetPosition(spawnPoint);
            
            float variance = Random.Range(-trajectoryDistance, trajectoryDistance);
            Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward);
            float speedRatio = speed / scale.x;
            
            asteroid.FirstLaunch(rotation * -spawnDirection, speedRatio);
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
            
            var spawnPosition = oldTransform.position;
            newAsteroid.SetPosition(spawnPosition);
            
            Vector3 spawnDirection = Random.insideUnitCircle.normalized * spawnDistance;
            float variance = Random.Range(-trajectoryDistance, trajectoryDistance);
            Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward);
            newAsteroid.LaunchShattered(rotation * -spawnDirection, oldAsteroid.initialSpeed * ratio);
        }
    }
}