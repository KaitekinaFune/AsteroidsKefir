using UnityEngine;
using Utils;

namespace Obstacles
{
    public abstract class ObstacleSpawner
    {
        protected readonly ObstaclesSpawnerSettings settings;
        private float nextObstacleSpawnTime;

        private bool IsEnabled;

        protected ObstacleSpawner(ObstaclesSpawnerSettings obstaclesSpawnerSettings)
        {
            settings = obstaclesSpawnerSettings;
            SubscribeToListeners(true);
            Enable();
        }

        private void SubscribeToListeners(bool value)
        {
            if (value)
            {
                GameEventSystem.OnUpdate += TrySpawnObstacles;
                GameEventSystem.OnGameRestart += Enable;
                GameEventSystem.OnGameEnd += Disable;
            }
            else
            {
                GameEventSystem.OnUpdate -= TrySpawnObstacles;
                GameEventSystem.OnGameRestart -= Enable;
                GameEventSystem.OnGameEnd -= Disable;
            }
        }
        
        private void TrySpawnObstacles()
        {
            if (!IsEnabled)
            {
                return;
            }

            if (Time.time >= nextObstacleSpawnTime)
            {
                nextObstacleSpawnTime = Time.time + 1f / settings.SpawnRate;
                SpawnObstacles();
            }
        }
        
        protected abstract void SpawnObstacles();

        private void Enable()
        {
            IsEnabled = true;
        }

        private void Disable()
        {
            IsEnabled = false;
        }

        protected Vector3 GetRandomSpawnPoint(float halfObjSize)
        {
            var halfWidthScreen = ScreenBounds.GetScreenHalfWidthInWorldUnits() + halfObjSize;
            var halfHeightScreen = ScreenBounds.GetScreenHalfHeightInWorldUnits() + halfObjSize;

            var randomXPoint = Random.Range(-halfWidthScreen, halfWidthScreen);
            var randomYPoint = Random.Range(-halfHeightScreen, halfHeightScreen);

            if (Random.value > .5f)
            {
                if (Random.value > .5f)
                {
                    return new Vector2(randomXPoint, halfHeightScreen);
                }
                
                return new Vector2(randomXPoint, -halfHeightScreen);
            }

            if (Random.value > .5f)
            {
                return new Vector2(halfWidthScreen, randomYPoint);
            }
            
            return new Vector2(-halfWidthScreen, randomYPoint);
        }
        
        protected Vector3 GetRandomDirection(Vector3 spawnPoint)
        {
            var halfWidthScreen = ScreenBounds.GetScreenHalfWidthInWorldUnits();
            var halfHeightScreen = ScreenBounds.GetScreenHalfHeightInWorldUnits();

            var randomXPoint = Random.Range(-halfWidthScreen, halfWidthScreen);
            var randomYPoint = Random.Range(-halfHeightScreen, halfHeightScreen);

            return spawnPoint - new Vector3(randomXPoint, randomYPoint);
        }
    }
}