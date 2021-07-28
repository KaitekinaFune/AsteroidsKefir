using ScriptableObjects;
using Utils;

namespace Obstacles
{
    public class UfosSpawner : ObstacleSpawner
    {
        private UfosSpawnerSettings ufoSpawnerSettings;
        
        public void Initialize(UfosSpawnerSettings settingsAsset)
        {
            ufoSpawnerSettings = settingsAsset;
        }

        protected override void SpawnObstacles()
        {
            var obstacles = ObjectPooler<Ufo>.Instance.Get(settings.ObstaclesToSpawn);

            foreach (var obstacle in obstacles)
            {
                SpawnObstacle(obstacle);
            }
        }

        private void SpawnObstacle(Ufo ufo)
        {
            var halfUfoSize = ufo.gameObject.transform.localScale.x / 2f;
            var spawnPoint = GetRandomSpawnPoint(halfUfoSize);
            ufo.SetPosition(spawnPoint);

            var speed = ufoSpawnerSettings.Speed;
            var rotation = ufoSpawnerSettings.RotationSpeed;
            ufo.SetSpeedAndRotation(speed, rotation);
            ufo.Launch();
        }

        public UfosSpawner(ObstaclesSpawnerSettings spawnerSettings) : base(spawnerSettings)
        {
        }
    }
}