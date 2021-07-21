using UnityEngine;
using Utils;

namespace Weapons
{
    public abstract class Projectile : MonoBehaviour, IDestroyableByBoundary
    {
        [SerializeField] private float speed;

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

        public void OnBoundaryTouch()
        {
            Destroy(gameObject);
        }

        protected abstract void OnTriggerEnter(Collider other);
    }
}