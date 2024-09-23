namespace RaceSimulator.Model.Vehicle;

public abstract class Vehicle
{
    public abstract string Name {get;}
    
    protected abstract double Speed();

    public abstract double Run(int distance);
}