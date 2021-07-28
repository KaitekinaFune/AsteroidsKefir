using UnityEngine;

namespace Player
{
    public class PlayerSpawnManager
    {
        private Vector3 spawnPosition;
        private Quaternion spawnRotation;
        private GameObject player;

        public void SetSpawnTransform(Vector3 position, Quaternion rotation)
        {
            spawnPosition = position;
            spawnRotation = rotation;
        }

        public GameObject GetPlayerObject(ShipSettings shipSettings)
        {
            if (player == null)
            {
                player = Object.Instantiate(shipSettings.ShipPrefab);
            }

            return player;
        }

        public void SetPlayerShipToSpawnPosition()
        {
            player.transform.position = spawnPosition;
            player.transform.rotation = spawnRotation;
        }
    }
}
