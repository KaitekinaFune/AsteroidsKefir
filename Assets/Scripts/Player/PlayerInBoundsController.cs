using UnityEngine;
using Utils;

namespace Player
{
    public class PlayerInBoundsController
    {
        private readonly Transform playerShip;

        private readonly float screenHalfWidthInWorldUnits;
        private readonly float screenHalfHeightInWorldUnits;

        public PlayerInBoundsController(GameObject ship)
        {
            playerShip = ship.transform;
            
            var localScale = playerShip.localScale;
            var halfObjectWidth = localScale.x / 2f;
            var halfObjectHeight = localScale.y / 2f;
            
            screenHalfWidthInWorldUnits = ScreenBounds.GetScreenHalfWidthInWorldUnits() + halfObjectWidth;
            screenHalfHeightInWorldUnits = ScreenBounds.GetScreenHalfHeightInWorldUnits() + halfObjectHeight;
        }

        public void OnUpdate()
        {
            if (playerShip.position.x < -screenHalfWidthInWorldUnits)
            {
                playerShip.position = new Vector2(screenHalfWidthInWorldUnits, playerShip.position.y);
            }
            if (playerShip.position.x > screenHalfWidthInWorldUnits)
            {
                playerShip.position = new Vector2(-screenHalfWidthInWorldUnits, playerShip.position.y);
            }
            if (playerShip.position.y < -screenHalfHeightInWorldUnits)
            {
                playerShip.position = new Vector2(playerShip.position.x, screenHalfHeightInWorldUnits);
            }   
            if (playerShip.position.y > screenHalfHeightInWorldUnits)
            {
                playerShip.position = new Vector2(playerShip.position.x, -screenHalfHeightInWorldUnits);
            }
        }
    }
}