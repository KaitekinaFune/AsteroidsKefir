using Managers;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(InputReader))]
    public class ShipEngine : MonoBehaviour
    {
        [SerializeField] private float speed = 30f;
        [SerializeField] private float turnSpeed = 15f;

        private Rigidbody rb;
        private InputReader input;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            input = GetComponent<InputReader>();
            OnRespawn();
        }

        private void Start()
        {
            RespawnManager.Instance.OnRespawn += OnRespawn;
        }

        private void FixedUpdate()
        {
            rb.AddForce(input.Vertical * transform.up * speed);
            rb.AddTorque(-input.Horizontal * Vector3.forward * turnSpeed);
        }

        private void OnRespawn()
        {
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }

        private void OnDestroy()
        {
            RespawnManager.Instance.OnRespawn -= OnRespawn;
        }
    }
}