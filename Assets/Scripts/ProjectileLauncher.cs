using UnityEngine;

[RequireComponent(typeof(InputReader))]
[RequireComponent(typeof(ShootPointHolder))]
public abstract class ProjectileLauncher : MonoBehaviour
{
    [SerializeField] protected GameObject projectilePrefab;
    [SerializeField] protected float fireRate;

    private ShootPointHolder shootPoint;
    
    protected float nextFireTime;
    
    protected virtual void Awake()
    {
        shootPoint = GetComponent<ShootPointHolder>();
    }

    public void TryShootProjectile()
    {
        if (CanShoot())
        {
            nextFireTime = Time.time + 1f / fireRate;
            Shoot();
        }
    }
    
    protected virtual void Shoot()
    {
        Instantiate(projectilePrefab, shootPoint.ShootPoint).GetComponent<Projectile>();
    }

    protected abstract bool CanShoot();
}
