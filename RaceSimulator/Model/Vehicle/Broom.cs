namespace RaceSimulator.Model.Vehicle;

public class Broom: AirVehicle
{
    protected override double AccelerationRate(int distance)
    {
        return 5;
    }

    public override string Name => "Метла";

    protected override double Speed()
    {
        return 10;
    }
}