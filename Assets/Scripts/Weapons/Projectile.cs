using UnityEngine;

namespace Weapons
{
    public abstract class Projectile : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private float maxLifeTime = 1f;

        private float lifeTime;
        private Rigidbody rb;

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
            Launch();
        }

        private void Launch()
        {
            rb.AddForce(transform.up * speed);
        }

        private void Update()
        {
            lifeTime += Time.deltaTime;
            if (lifeTime > maxLifeTime)
            {
                Destroy(gameObject);
            }
        }
        
        protected abstract void OnTriggerEnter(Collider other);
    }
}