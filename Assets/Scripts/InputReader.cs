using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    [SerializeField] private KeyCode shootPrimary;
    [SerializeField] private KeyCode shootSecondary;
    
    public float Vertical { get; private set; }
    public float Horizontal { get; private set; }

    public event Action OnShootPrimary;
    public event Action OnShootSecondary;

    private void Update()
    {
        Vertical = Input.GetAxis("Vertical");
        Horizontal = Input.GetAxis("Horizontal");

        if (Input.GetKey(shootPrimary))
        {
            OnShootPrimary?.Invoke();
        }
        
        if (Input.GetKey(shootSecondary))
        {
            OnShootSecondary?.Invoke();
        }
    }
}
