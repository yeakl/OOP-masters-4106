namespace RaceSimulator.Model.Vehicle;

public abstract class LandVehicle: Vehicle {
    protected abstract int RestTime(int stopIndex);
    protected abstract int TravelTimeUntilRest();

    public override double Run(int distance)
    {
        double time = distance / this.Speed();
        int stops = (int) time / this.TravelTimeUntilRest();
        for (int i = 0; i < stops; i++)
        {
            time += RestTime(i);
        }

        return time;
    }
}