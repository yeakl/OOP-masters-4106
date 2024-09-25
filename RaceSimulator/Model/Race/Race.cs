namespace RaceSimulator.Model.Race;

using Exception;
using Vehicle;

public class Race(int distance, RaceType raceType) {
    private readonly List<Vehicle> _members = [];
    public RaceType RaceType { get; } = raceType;

    public void RegisterMember(Vehicle vehicle)
    {
        if (RaceType == RaceType.Air && vehicle is not AirVehicle) {
            throw new WrongVehicleForRaceException("Cannot register a land vehicle to an air race");
        }

        if (RaceType == RaceType.Land && vehicle is not LandVehicle) {
            throw new WrongVehicleForRaceException("Cannot register an air vehicle to a land race");
        }
            
        _members.Add(vehicle);
    }

    private void Validate()
    {
        if (distance < 1)
        {
            throw new InvalidRaceException("Distance must be greater than 0");
        }
    }

    public SortedList<double, Vehicle> Start()
    {
        Validate();
        SortedList<double, Vehicle> participants = new SortedList<double, Vehicle>();
        foreach (Vehicle member in this._members) {
            var time = member.Run(distance);
            participants.Add(time, member);
        }

        return participants;
    }
}