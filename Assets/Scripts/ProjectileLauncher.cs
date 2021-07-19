using UnityEngine;

[RequireComponent(typeof(InputReader))]
[RequireComponent(typeof(ShootPointHolder))]
public abstract class ProjectileLauncher : MonoBehaviour
{
    [SerializeField] protected GameObject projectilePrefab;
    [SerializeField] protected float fireRate;

    protected InputReader input;
    private ShootPointHolder shootPoint;
    
    protected float nextFireTime;
    
    protected virtual void Awake()
    {
        input = GetComponent<InputReader>();
        shootPoint = GetComponent<ShootPointHolder>();
    }

    protected void TryShootProjectile()
    {
        if (CanShoot())
        {
            nextFireTime = Time.time + 1f / fireRate;
            Shoot();
        }
    }
    
    protected virtual void Shoot()
    {
        Instantiate(projectilePrefab, shootPoint.ShootPoint);
    }

    protected abstract bool CanShoot();
}
