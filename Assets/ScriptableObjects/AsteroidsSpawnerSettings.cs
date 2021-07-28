using UnityEngine;
using Utils;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "AsteroidsSpawnerSettings", menuName = "Asteroids Spawner Settings")]
    public class AsteroidsSpawnerSettings : ScriptableObject
    {
        [SerializeField] private ObstaclesSpawnerSettings spawnerSettings;
        [Header("Asteroids Settings")] 
        [SerializeField] private float speed;
        [SerializeField] private MinMaxFloat sizeMinMax;

        [Header("Shatter Settings")] 
        [SerializeField] private MinMaxInt asteroidsShattersAmountMinMax;
        [SerializeField] private MinMaxFloat shatterAsteroidSizeRatioMinMax;

        public ObstaclesSpawnerSettings SpawnerSettings => spawnerSettings;
        public float Speed => speed;
        public float Size => sizeMinMax.GetRandom();

        public int ShattersAmount => asteroidsShattersAmountMinMax.GetRandom();
        public float ShatterSize => shatterAsteroidSizeRatioMinMax.GetRandom();
    }
}
