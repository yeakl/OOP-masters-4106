namespace RaceSimulator.Model.Vehicle;

public class Broom: AirVehicle
{
    protected override double AccelerationRate(int distance)
    {
        return (1 / distance) + Double.Pi;
    }

    public override string Name => "Метла";

    protected override double Speed()
    {
        return 10;
    }
}