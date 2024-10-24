namespace RaceSimulator.Model.Vehicle;

public class FlyingShip: AirVehicle
{
    public override string Name => "Летучий корабль";

    protected override double Speed()
    {
        return 60;
    }

    protected override double AccelerationRate(int distance)
    {
        return (1 / distance) ^ 2;
    }
}