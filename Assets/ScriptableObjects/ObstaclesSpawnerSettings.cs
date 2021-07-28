using UnityEngine;

namespace ScriptableObjects
{
    [System.Serializable]
    public class ObstaclesSpawnerSettings
    {
        [SerializeField] private float spawnRate = 1f;
        [SerializeField] private int obstaclesToSpawn = 1;
        [SerializeField] private GameObject obstaclePrefab;

        public float SpawnRate => spawnRate;
        public int ObstaclesToSpawn => obstaclesToSpawn;
        public GameObject ObstaclePrefab => obstaclePrefab;
    }
}