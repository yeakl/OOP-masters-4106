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
        switch (distance)
        {
            case < 1000:
                return 1;
            case > 1000 and < 3000:
                return 0.95;
            default:
                return 0.8;
        }
    }
}
