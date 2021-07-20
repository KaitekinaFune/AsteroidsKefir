using UnityEngine;

public class Weapons : MonoBehaviour
{
    [SerializeField] private ProjectileLauncher primaryWeapon;
    [SerializeField] private ProjectileLauncher secondaryWeapon;

    private InputReader input;

    private void Awake()
    {
        input = GetComponent<InputReader>();
        input.OnShootPrimary += primaryWeapon.TryShootProjectile;
        input.OnShootSecondary += secondaryWeapon.TryShootProjectile;
    }

    private void OnDisable()
    {
        input.OnShootPrimary -= primaryWeapon.TryShootProjectile;
        input.OnShootSecondary -= secondaryWeapon.TryShootProjectile;
    }
}
