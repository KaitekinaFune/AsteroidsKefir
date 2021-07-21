using System;

namespace Ship.Input
{
    public class PlayerShipWeaponsInput : IShipWeaponsInput
    {
        public event Action OnShootPrimary;
        public event Action OnShootSecondary;
    
        public void ReadInput()
        {
            if (UnityEngine.Input.GetAxis("Fire1") > 0)
            {
                OnShootPrimary?.Invoke();
            }

            if (UnityEngine.Input.GetAxis("Fire2") > 0)
            {
                OnShootSecondary?.Invoke();
            }
        }
    }
}