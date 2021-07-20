using UnityEngine;

public class Projectile : MonoBehaviour
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
}
