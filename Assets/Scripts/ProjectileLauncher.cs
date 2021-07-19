using UnityEngine;

[RequireComponent(typeof(InputReader))]
[RequireComponent(typeof(ShootPointHolder))]
public abstract class ProjectileLauncher : MonoBehaviour
{
    [SerializeField] protected GameObject projectilePrefab;
    [SerializeField] protected float shootSpeed;

    protected InputReader input;
    protected ShootPointHolder shootPoint;
    protected float lastShotTime;
    
    protected virtual void Awake()
    {
        input = GetComponent<InputReader>();
        shootPoint = GetComponent<ShootPointHolder>();
        
        lastShotTime = Time.time;
    }

    protected void TryShootProjectile()
    {
        if (Time.time > lastShotTime + shootSpeed)
        {
            Shoot();
        }
    }

    protected abstract void Shoot();
}
