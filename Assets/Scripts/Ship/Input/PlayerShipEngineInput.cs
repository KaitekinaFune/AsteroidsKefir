namespace Ship.Input
{
    public class PlayerShipEngineInput : IShipEngineInput
    {
        public float Rotation { get; private set; }
        public float Thrust { get; private set; }
    
        public void ReadInput()
        {
            Rotation = UnityEngine.Input.GetAxis("Horizontal");
            Thrust = UnityEngine.Input.GetAxis("Vertical");
        }
    }
}
