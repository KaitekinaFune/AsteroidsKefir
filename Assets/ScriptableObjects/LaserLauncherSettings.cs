using UnityEngine;
using Weapons;

namespace ScriptableObjects
{
    [System.Serializable]
    public class LaserLauncherSettings : ProjectileLauncherSettings
    {
        [SerializeField] private int maxLasers = 3;
        [SerializeField] private float lasersRestockRate = 5f;

        public int MaxLasers => maxLasers;
        public float LasersRestockRate => lasersRestockRate;
    }
}