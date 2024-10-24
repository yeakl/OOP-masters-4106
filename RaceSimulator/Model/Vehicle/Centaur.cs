namespace RaceSimulator.Model.Vehicle;

public class Centaur : LandVehicle
{
    public override string Name => "Центавр";

    protected override double Speed()
    {
        return 90;
    }

    protected override int RestTime(int stopIndex)
    {
        return stopIndex * 25;
    }

    protected override int TravelTimeUntilRest()
    {
        return 90;
    }
}