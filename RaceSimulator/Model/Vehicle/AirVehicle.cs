namespace RaceSimulator.Model.Vehicle;

public abstract class AirVehicle: Vehicle {
    protected abstract double AccelerationRate(int distance);

    public override double Run(int distance)
    {
        return distance * AccelerationRate(distance) / this.Speed();
    }
}