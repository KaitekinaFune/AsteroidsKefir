using UnityEngine;

namespace Weapons
{
    [RequireComponent(typeof(ShootPointHolder))]
    public abstract class ProjectileLauncher : MonoBehaviour
    {
        [SerializeField] protected GameObject projectilePrefab;
        [SerializeField] protected float fireRate;

        private Transform shootPoint;
    
        protected float nextFireTime;
    
        protected virtual void Awake()
        {
            shootPoint = GetComponent<ShootPointHolder>().ShootPoint;
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
            Instantiate(projectilePrefab, shootPoint.position, shootPoint.rotation);
        }

        protected abstract bool CanShoot();
    }
}