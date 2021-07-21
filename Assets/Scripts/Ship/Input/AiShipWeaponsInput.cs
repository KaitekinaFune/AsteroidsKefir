using System;
using Random = UnityEngine.Random;

namespace Ship.Input
{
    public class AiShipWeaponsInput : IShipWeaponsInput
    {
        public event Action OnShootPrimary;
        public event Action OnShootSecondary;

        public void ReadInput()
        {
            if (Random.value > .5f)
            {
                OnShootPrimary?.Invoke();
            }

            if (Random.value > .5f)
            {
                OnShootSecondary?.Invoke();
            }
        }
    }
}