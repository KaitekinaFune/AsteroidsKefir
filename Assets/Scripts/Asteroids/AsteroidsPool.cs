using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class AsteroidsPool : MonoBehaviour
    {
        public static AsteroidsPool Instance;

        [SerializeField] private Asteroid asteroidPrefab;

        private readonly Stack<Asteroid> asteroids = new Stack<Asteroid>();

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

        public IEnumerable<Asteroid> Get(int amount)
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
            var asteroid = Instantiate(asteroidPrefab);
            ReturnAsteroidToPool(asteroid);
        }

        public void ReturnAsteroidToPool(Asteroid asteroid)
        {
            asteroid.gameObject.SetActive(false);
            asteroids.Push(asteroid);
        }
    }
}