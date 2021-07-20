using System.Collections.Generic;
using UnityEngine;

namespace Obstacles
{
    public abstract class ObstaclesPooler<T> : MonoBehaviour where T: Obstacle
    {
        public static ObstaclesPooler<T> Instance;

        [SerializeField] private T obstaclePrefab;

        private readonly Stack<T> asteroids = new Stack<T>();

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public IEnumerable<T> Get(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                if (asteroids.Count == 0)
                {
                    AddAsteroids();
                }

                yield return asteroids.Pop();
            }
        }

        private void AddAsteroids()
        {
            var obstacle = Instantiate(obstaclePrefab);
            ReturnObstacleToPool(obstacle);
        }

        public void ReturnObstacleToPool(T obstacle)
        {
            obstacle.gameObject.SetActive(false);
            asteroids.Push(obstacle);
        }
    }
}