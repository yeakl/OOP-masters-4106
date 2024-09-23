namespace RaceSimulator.Model.Race;

using Vehicle;

public class Race(int distance, RaceType raceType) {
    private readonly List<Vehicle> _members = [];

    public void RegisterMember(Vehicle vehicle)
    {
        //type check
        if (raceType == RaceType.Air && vehicle is not AirVehicle) {
            throw new Exception("Cannot register a race with a land vehicle");
        }

        if (raceType == RaceType.Land && vehicle is not LandVehicle) {
            throw new Exception("Cannot register a race with an air vehicle");
        }
            
        _members.Add(vehicle);
    }

    private void Validate()
    {
        if (distance < 1)
        {
            throw new Exception("Distance must be greater than 0");
        }
    }

    public void Start()
    {
        this.Validate();
        SortedList<double, Vehicle> participants = new SortedList<double, Vehicle>();
        foreach (Vehicle member in this._members) {
            var time = member.Run(distance);
            participants.Add(time, member);
        }

        int i = 1;
        foreach (KeyValuePair<double, Vehicle> participant in participants)
        {
            Console.WriteLine($"Место {i}: {participant.Value.Name}, время: {participant.Key}");
            i++;
        }
    }
}