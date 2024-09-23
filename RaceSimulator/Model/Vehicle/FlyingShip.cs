namespace RaceSimulator.Model.Vehicle;

class FlyingShip: AirVehicle
{
    public override string Name => "Летучий корабль";

    protected override double Speed()
    {
        return 60;
    }

    protected override double AccelerationRate(int distance)
    {
        return 2.05;
    }
}