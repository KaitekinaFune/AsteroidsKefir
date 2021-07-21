using Ship.Input;
using UnityEngine;

namespace Weapons
{
    public class ShipWeapons : MonoBehaviour
    {
        [SerializeField] private ProjectileLauncher primaryWeapon;
        [SerializeField] private ProjectileLauncher secondaryWeapon;

        private IShipWeaponsInput input;

        public void SetInput(IShipWeaponsInput input)
        {
            this.input = input;
        }

        private void Awake()
        {
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