namespace RaceSimulator.Model.Vehicle;

public class Mortar: AirVehicle
{
    public override string Name => "Ступа Бабы Яги";

    protected override double Speed()
    {
        return 120;
    }

    protected override double AccelerationRate(int distance)
    {
        return 1.55;
    }
}