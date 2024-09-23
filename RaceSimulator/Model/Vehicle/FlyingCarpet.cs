namespace RaceSimulator.Model.Vehicle;

public class FlyingCarpet: AirVehicle
{
    public override string Name => "Ковер-самолет";

    protected override double Speed()
    {
        return 180;
    }

    protected override double AccelerationRate(int distance)
    {
        return 1.75;
    }
}