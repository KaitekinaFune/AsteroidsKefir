using UnityEngine;
using Utils;

namespace Obstacles
{
    public class UfosSpawner : MonoBehaviour
    {
        [Header("Spawn Settings")]
        [SerializeField] private float spawnRate = 1f;
        [SerializeField] private float spawnDistance = 20f;
        [SerializeField] private int ufosToSpawn = 1;

        [Header("Ufos Settings")] 
        [SerializeField] private MinMaxFloat ufoSpeedMinMax;
        [SerializeField] private MinMaxFloat ufoRotationSpeedMinMax;

        private void Start()
        {
            InvokeRepeating(nameof(SpawnUfos), spawnRate, spawnRate);
        }

        private void SpawnUfos()
        {
            var ufos = UfosPool.Instance.Get(ufosToSpawn);

            foreach (var ufo in ufos)
            {
                SpawnUfo(ufo);
            }
        }

        private void SpawnUfo(Ufo ufo)
        {
            Vector3 spawnDirection = Random.insideUnitCircle.normalized * spawnDistance;
            Vector3 spawnPoint = transform.position + spawnDirection;

            float speed = ufoSpeedMinMax.GetRandom();
            float rotation = ufoRotationSpeedMinMax.GetRandom();
            ufo.SetPosition(spawnPoint);
            ufo.SetSpeedAndRotation(speed, rotation);
            ufo.Launch();
        }
    }
}