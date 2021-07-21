using System;

namespace Ship.Input
{
    public interface IShipWeaponsInput : IShipInput
    {
        event Action OnShootPrimary;
        event Action OnShootSecondary;
    }
}
