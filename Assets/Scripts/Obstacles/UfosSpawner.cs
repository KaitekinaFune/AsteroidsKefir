using UnityEngine;
using Utils;

namespace Obstacles
{
    public class UfosSpawner : ObstacleSpawner
    {
        [Header("Ufos Settings")] 
        [SerializeField] private MinMaxFloat ufoSpeedMinMax;
        [SerializeField] private MinMaxFloat ufoRotationSpeedMinMax;

        protected override void SpawnObstacles()
        {
            var ufos = UfosPool.Instance.Get(obstaclesToSpawn);

            foreach (var ufo in ufos)
            {
                SpawnObstacle(ufo);
            }
        }

        private void SpawnObstacle(Ufo ufo)
        {
            var halfUfoSize = transform.localScale.x / 2f;
            var spawnPoint = GetRandomSpawnPoint(halfUfoSize);
            ufo.SetPosition(spawnPoint);

            var speed = ufoSpeedMinMax.GetRandom();
            var rotation = ufoRotationSpeedMinMax.GetRandom();
            ufo.SetSpeedAndRotation(speed, rotation);
            ufo.Launch();
        }
    }
}