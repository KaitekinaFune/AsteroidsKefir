using Ship.Input;
using UnityEngine;

namespace Ship
{
    public class ShipEngine
    {
        private readonly IShipEngineInput shipInput;
        private readonly Transform transformToMove;
        private readonly ShipSettings shipSettings;

        public ShipEngine(IShipEngineInput shipInput, Transform transformToMove, ShipSettings shipSettings)
        {
            this.shipInput = shipInput;
            this.transformToMove = transformToMove;
            this.shipSettings = shipSettings;
        }

        public void OnUpdate()
        {
            var rotateAmount = Vector3.forward * shipInput.Rotation * Time.deltaTime * shipSettings.TurnSpeed;
            transformToMove.Rotate(-rotateAmount);

            var moveAmount = transformToMove.up * shipInput.Thrust * Time.deltaTime * shipSettings.MoveSpeed;
            transformToMove.position += moveAmount;
        }

        public void ResetPosition()
        {
            transformToMove.localPosition = Vector3.zero;
            transformToMove.localRotation = Quaternion.identity;
        }
    }
}