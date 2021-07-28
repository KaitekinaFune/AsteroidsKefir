using UnityEngine;

namespace Player
{
    public class PlayerController
    {
        public static GameObject playerShip { get; private set; }
    
        private readonly PlayerSpawnManager spawnManager = new PlayerSpawnManager();
        private readonly ShipSettings shipSettings;
    
        private PlayerMoveSystem moveSystem;
        private PlayerInputReader input;
        private PlayerInBoundsController inBoundsController;
        private PlayerWeaponsSystem weaponsSystem;

        public PlayerController(ShipSettings shipSettings)
        {
            this.shipSettings = shipSettings;
        }
    
        public void Initialize()
        {
            SetFields();
            SubscribeToListeners(true);
            Disable();
        }

        private void SetFields()
        {
            var playerObject = spawnManager.GetPlayerObject(shipSettings);
            spawnManager.SetSpawnTransform(shipSettings.SpawnPosition, shipSettings.SpawnRotation);
            playerShip = playerObject;
            input = new PlayerInputReader();
            moveSystem = new PlayerMoveSystem(playerShip, input, shipSettings);
            inBoundsController = new PlayerInBoundsController(playerShip);
            weaponsSystem = new PlayerWeaponsSystem(playerShip, input, shipSettings);
        }
    
        private void SubscribeToListeners(bool value)
        {
            if (value)
            {
                GameEventSystem.OnUpdate += OnUpdate;
                GameEventSystem.OnGameStart += OnStart;
                GameEventSystem.OnGameRestart += OnStart;
                GameEventSystem.OnGameEnd += Disable;
            }
            else
            {
                GameEventSystem.OnUpdate -= OnUpdate;
                GameEventSystem.OnGameStart -= OnStart;
                GameEventSystem.OnGameRestart -= OnStart;
                GameEventSystem.OnGameEnd -= Disable;
            }
        }

        private void OnUpdate()
        {
            input.TryReadInput();
            moveSystem.TryMove();
            inBoundsController.OnUpdate();
            weaponsSystem.OnUpdate();
        }

        private void OnStart()
        {
            playerShip.gameObject.SetActive(true);
            weaponsSystem.Enable();
            moveSystem.Enable();
            input.Start();
            spawnManager.SetPlayerShipToSpawnPosition();
        }

        private void Disable()
        {
            weaponsSystem.Disable();
            playerShip.gameObject.SetActive(false);
            moveSystem.Disable();
            input.Stop();
        }
    }
}