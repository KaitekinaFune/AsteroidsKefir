using UnityEngine;
using Utils;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "UfosSpawnerSettings", menuName = "Ufos Spawner Settings")]
    public class UfosSpawnerSettings : ScriptableObject
    {
        [SerializeField] private ObstaclesSpawnerSettings spawnerSettings;
        [Header("Ufos Settings")]
        [SerializeField] private MinMaxFloat SpeedMinMax;
        [SerializeField] private MinMaxFloat RotationSpeedMinMax;

        public ObstaclesSpawnerSettings SpawnerSettings => spawnerSettings;
        public float Speed => SpeedMinMax.GetRandom();
        public float RotationSpeed => RotationSpeedMinMax.GetRandom();
    }
}