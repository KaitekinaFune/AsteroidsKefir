using UnityEngine;

namespace Player
{
    public class PlayerMoveSystem
    {
        private readonly ShipSettings shipSettings;
        private readonly PlayerInputReader input;
        private readonly Transform playerTransform;

        private bool IsActive;
    
        public PlayerMoveSystem(GameObject playerGameObject, PlayerInputReader input, ShipSettings shipSettings)
        {
            this.shipSettings = shipSettings;
            this.input = input;
            playerTransform = playerGameObject.transform;
        }

        public void Enable()
        {
            IsActive = true;
        }

        public void Disable()
        {
            IsActive = false;
        }

        public void TryMove()
        {
            if (!IsActive)
            {
                return;
            }
        
            var rotateAmount = Vector3.forward * input.horizontal * Time.deltaTime * shipSettings.TurnSpeed;
            playerTransform.Rotate(-rotateAmount);

            var moveAmount = playerTransform.up * input.vertical * Time.deltaTime * shipSettings.MoveSpeed;
            playerTransform.position += moveAmount;
        }
    }
}
