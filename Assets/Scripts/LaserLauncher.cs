using UnityEngine;

public class LaserLauncher : ProjectileLauncher
{
    [SerializeField] private int maxLasers = 3;
    [SerializeField] private float timeBetweenLasersRestock = 5f;

    private int lasersLeft;
    private float lastLaserRestockTime;

    protected override void Awake()
    {
        base.Awake();
        lastLaserRestockTime = Time.time;
    }

    private void Update()
    {
        if (lasersLeft <= maxLasers)
        {
            TryRestockLasers();
        }
    }

    protected override void Shoot()
    {
        
    }

    private void TryRestockLasers()
    {
        if (Time.time > lastLaserRestockTime + timeBetweenLasersRestock)
        {
            lasersLeft++;
            lastLaserRestockTime = Time.time;
        }
    }

    private void OnEnable()
    {
        input.OnShootSecondary += TryShootProjectile;
    }

    private void OnDisable()
    {
        input.OnShootSecondary -= TryShootProjectile;
    }
}