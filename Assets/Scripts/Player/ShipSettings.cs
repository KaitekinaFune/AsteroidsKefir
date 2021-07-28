using ScriptableObjects;
using UnityEngine;
using Weapons;

namespace Player
{
    [CreateAssetMenu(fileName = "New Ship Settings", menuName = "Ship Settings")]
    public class ShipSettings : ScriptableObject
    {
        [SerializeField] private GameObject shipPrefab;
        [SerializeField] private float turnSpeed;
        [SerializeField] private float moveSpeed;
        [SerializeField] private Vector3 spawnPosition;
        [SerializeField] private Quaternion spawnRotation;
        [SerializeField] private ProjectileLauncherSettings bulletLauncherSettings;
        [SerializeField] private LaserLauncherSettings laserLauncherSettings;

        public float TurnSpeed => turnSpeed;
        public float MoveSpeed => moveSpeed;
        public GameObject ShipPrefab => shipPrefab;
        public Vector3 SpawnPosition => spawnPosition;
        public Quaternion SpawnRotation => spawnRotation;
        public ProjectileLauncherSettings BulletLauncherSettings => bulletLauncherSettings;
        public LaserLauncherSettings LaserLauncherSettings => laserLauncherSettings;
    }
}