namespace RaceSimulator.Model.Vehicle;

public class PumpkinCoach: LandVehicle
{
    public override string Name => "Корета-тыква";

    protected override double Speed()
    {
        return 20;
    }

    protected override int RestTime(int stopIndex)
    {
        return (int)(1.5 + stopIndex)^2;
    }

    protected override int TravelTimeUntilRest()
    {
        return 20;
    }
}