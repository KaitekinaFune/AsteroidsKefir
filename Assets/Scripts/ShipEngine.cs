using UnityEngine;

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
    }

    private void FixedUpdate()
    {
        if (input.Vertical > 0f)
        {
            rb.AddForce(input.Vertical * transform.up * speed);
        }

        rb.AddTorque(-input.Horizontal * Vector3.forward * turnSpeed);
    }
}
