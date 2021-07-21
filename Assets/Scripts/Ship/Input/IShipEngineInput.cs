namespace Ship.Input
{
    public interface IShipEngineInput : IShipInput
    {
        float Rotation { get; }
        float Thrust { get; }
    }
}