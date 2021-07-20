using UnityEngine;

public class LaserLauncher : ProjectileLauncher
{
    [SerializeField] private int maxLasers = 3;
    [SerializeField] private float lasersRestockRate = 5f;

    private int lasersLeft;
    private float nextLaserRestockTime;

    protected override void Awake()
    {
        base.Awake();
        lasersLeft = maxLasers;
    }

    protected override bool CanShoot()
    {
        return lasersLeft > 0 && nextFireTime >= Time.time;
    }

    protected override void Shoot()
    {
        base.Shoot();
        lasersLeft--;
    }
    
    private void Update()
    {
        if (lasersLeft <= maxLasers)
        {
            TryRestockLasers();
        }
    }
    
    private void TryRestockLasers()
    {
        if (Time.time > nextLaserRestockTime)
        {
            lasersLeft++;
            nextLaserRestockTime = Time.time + 1f / lasersRestockRate;
        }
    }
}