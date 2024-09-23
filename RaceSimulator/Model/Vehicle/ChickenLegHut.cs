namespace RaceSimulator.Model.Vehicle;

public class ChickenLegHut: LandVehicle
{
    public override string Name => "Избушка на курьих ножках";

    protected override double Speed()
    {
        return 50;
    }

    protected override int RestTime(int stopIndex)
    {
        return 20;
    }

    protected override int TravelTimeUntilRest()
    {
        return 40;
    }
}