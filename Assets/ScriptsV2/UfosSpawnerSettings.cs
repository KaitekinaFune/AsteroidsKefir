using UnityEngine;
using Utils;

[CreateAssetMenu(fileName = "UfosSpawnerSettings", menuName = "Ufos Spawner Settings")]
public class UfosSpawnerSettings : ScriptableObject
{
    [Header("Ufos Settings")]
    [SerializeField] private GameObject ufoPrefab;
    [SerializeField] private MinMaxFloat SpeedMinMax;
    [SerializeField] private MinMaxFloat RotationSpeedMinMax;

    public GameObject UfoPrefab => ufoPrefab;
    public float Speed => SpeedMinMax.GetRandom();
    public float RotationSpeed => RotationSpeedMinMax.GetRandom();
}