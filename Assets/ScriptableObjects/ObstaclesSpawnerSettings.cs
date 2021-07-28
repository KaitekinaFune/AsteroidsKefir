using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "ObstaclesSpawnerSettings", menuName = "Obstacles Spawner Settings")]
    public class ObstaclesSpawnerSettings: ScriptableObject
    {
        [Header("Spawn Settings")]
        [SerializeField] private float spawnRate = 1f;
        [SerializeField] private int obstaclesToSpawn = 1;

        public float SpawnRate => spawnRate;
        public int ObstaclesToSpawn => obstaclesToSpawn;
    }
}