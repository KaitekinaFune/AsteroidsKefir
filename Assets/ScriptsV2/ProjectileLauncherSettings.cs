using UnityEngine;

[System.Serializable]
public class ProjectileLauncherSettings
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float projectileSpeed = 5;
    [SerializeField] private float fireRate;

    public GameObject ProjectilePrefab => projectilePrefab;
    public float ProjectileSpeed => projectileSpeed;
    public float FireRate => fireRate;
}
