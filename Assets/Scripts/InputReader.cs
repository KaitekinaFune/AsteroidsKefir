using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    public float Vertical { get; private set; }
    public float Horizontal { get; private set; }

    public event Action OnShoot = delegate { };

    private void Update()
    {
        Vertical = Input.GetAxis("Vertical");
        Horizontal = Input.GetAxis("Horizontal");

        if (Input.GetKey(KeyCode.Space))
        {
            OnShoot?.Invoke();
        }
    }
}
