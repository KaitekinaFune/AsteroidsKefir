using UnityEngine;

namespace Ship.Input
{
    public class AiShipEngineInput : IShipEngineInput
    {
        public float Rotation { get; private set; }
        public float Thrust { get; private set; }

        public void ReadInput()
        {
            Rotation = Random.Range(-1f, 1f);
            Thrust = Random.Range(0f, 1f);
        }
    }
}