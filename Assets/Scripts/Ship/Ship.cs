using Managers;
using Ship.Input;
using UnityEngine;
using Weapons;

namespace Ship
{
    public class Ship : MonoBehaviour
    {
        [SerializeField] private ShipSettings shipSettings;

        private IShipEngineInput shipEngineInput;
        private ShipEngine shipEngine;
        
        private IShipWeaponsInput shipWeaponsInput;
        private ShipWeapons shipWeapons;

        private void Awake()
        {
            shipEngineInput = shipSettings.Ai 
                ? (IShipEngineInput) new AiShipEngineInput() 
                : new PlayerShipEngineInput();
            shipEngine = new ShipEngine(shipEngineInput, transform, shipSettings);

            shipWeaponsInput = shipSettings.Ai
                ? (IShipWeaponsInput) new AiShipWeaponsInput()
                : new PlayerShipWeaponsInput();
            shipWeapons = GetComponent<ShipWeapons>();
            shipWeapons.SetInput(shipWeaponsInput);

            GameOverManager.Instance.OnRespawn += OnRespawn;
        }

        private void Update()
        {
            shipWeaponsInput.ReadInput();
            shipEngineInput.ReadInput();
            shipEngine.OnUpdate();
        }

        private void OnRespawn()
        {
            shipEngine.ResetPosition();
        }

        private void OnDestroy()
        {
            GameOverManager.Instance.OnRespawn -= OnRespawn;
        }
    }
}