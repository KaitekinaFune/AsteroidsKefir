using UnityEngine;
using Utils;

namespace Obstacles
{
    public abstract class ObstacleSpawner : MonoBehaviour
    {
        [Header("Spawn Settings")] 
        [SerializeField] private float spawnRate = 1f;
        [SerializeField] protected int obstaclesToSpawn = 1;

        protected abstract void SpawnObstacles();
        
        private void Start()
        {
            InvokeRepeating(nameof(SpawnObstacles), spawnRate, spawnRate);
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