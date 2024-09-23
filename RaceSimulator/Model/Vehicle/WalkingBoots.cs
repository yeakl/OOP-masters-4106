namespace RaceSimulator.Model.Vehicle;

public class WalkingBoots: LandVehicle
{
    public override string Name => "Сапоги-скороходы";

    protected override double Speed()
    {
        return 10;
    }

    protected override int RestTime(int stopIndex)
    {
        return stopIndex > 2 ? 5 : 2;
    }

    protected override int TravelTimeUntilRest()
    {
        return 10;
    }
}