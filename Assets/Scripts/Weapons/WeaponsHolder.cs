using Player;
using UnityEngine;

namespace Weapons
{
    public class WeaponsHolder : MonoBehaviour
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

        private void OnDestroy()
        {
            input.OnShootPrimary -= primaryWeapon.TryShootProjectile;
            input.OnShootSecondary -= secondaryWeapon.TryShootProjectile;
        }
    }
}