using UnityEngine;using Utils;

[CreateAssetMenu(fileName = "AsteroidsSpawnerSettings", menuName = "Asteroids Spawner Settings")]
public class AsteroidsSpawnerSettings : ScriptableObject
{
    [Header("Asteroids Settings")] 
    [SerializeField] private GameObject asteroidPrefab;
    [SerializeField] private float speed;
    [SerializeField] private MinMaxFloat sizeMinMax;

    [Header("Shatter Settings")] 
    [SerializeField] private MinMaxInt asteroidsShattersAmountMinMax;
    [SerializeField] private MinMaxFloat shatterAsteroidSizeRatioMinMax;

    public GameObject AsteroidPrefab => asteroidPrefab;
    public float Speed => speed;
    public float Size => sizeMinMax.GetRandom();

    public int ShattersAmount => asteroidsShattersAmountMinMax.GetRandom();
    public float ShatterSize => shatterAsteroidSizeRatioMinMax.GetRandom();
}
