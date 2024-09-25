using RaceSimulator.Exception;
using RaceSimulator.Model.Race;
using RaceSimulator.Model.Vehicle;

namespace RaceSimulator;

internal class Program
{
    private static void Main(string[] args)
    {
        var distance = PickDistance();
        var raceType = PickRaceType();
        
        var race = new Race(distance, raceType);
        RegisterVehicles(race);

        try
        {
            var participants = race.Start();
            var i = 1;
            Console.WriteLine($"Welcome to the {race.RaceType} race. The distance is {distance}!");
            foreach (KeyValuePair<double, Vehicle> participant in participants)
            {
                Console.WriteLine($"Place {i}: {participant.Value.Name}, time: {participant.Key:0.##}");
                i++;
            }
        }
        catch (InvalidRaceException e)
        {
            Console.WriteLine(e.Message);
            Environment.Exit(1);
        }
        catch (System.Exception)
        {
            Console.WriteLine("Произошла непредвиденная ошибка");
            Environment.Exit(1);
        }
    }

    private static int PickDistance()
    {
        Console.WriteLine("Choose distance:");
        try
        {
            return Convert.ToInt32(Console.ReadLine());
        }
        catch (System.Exception)
        {
            Console.Error.WriteLine("Invalid distance entered");
            Environment.Exit(1); 
        }

        return 0;
    }

    private static RaceType PickRaceType()
    {
        Console.WriteLine($"Enter race type from the list:");
        var raceTypes = Enum.GetValues(typeof(RaceType));
        foreach (var raceTypeInput in raceTypes)
        {
            Console.WriteLine(raceTypeInput);
        }

        var chosenRaceType = Convert.ToString(Console.ReadLine());
        if (chosenRaceType == null || !Enum.IsDefined(typeof(RaceType), chosenRaceType))
        {
            Console.Error.WriteLine("Invalid race type");
            Environment.Exit(1); 
        }

        var raceType = Enum.Parse<RaceType>(chosenRaceType);
        return raceType;
    }

    private static void RegisterVehicles(Race race)
    {
        var vehicles = AllVehicles();
        while (true)
        {
            var counter = 0;
            foreach (var vehicle in vehicles)
            {
                Console.WriteLine($"{counter}: {vehicle.Name}");
                counter++;
            }

            Console.WriteLine("Choose race participant, enter number OR press Enter to start the race!");
           
            var participantHolder = Console.ReadLine();
            if (participantHolder == "")
            {
                break;
            }

            try
            {
                var raceMember = vehicles[Convert.ToInt32(participantHolder)];
                race.RegisterMember(raceMember);
                vehicles.Remove(raceMember);
            }
            catch (WrongVehicleForRaceException e)
            {
                Console.WriteLine(e.Message);
                Environment.Exit(1);
            }
            catch (System.Exception)
            {
                Console.WriteLine("Произошла непредвиденная ошибка");
                Environment.Exit(1);
            }
            
            if (vehicles.Count == 0)
            {
                break;
            }
        }
    }
    
    private static List<Vehicle> AllVehicles()
    {
        var broom = new Broom();
        var centaur = new Centaur();
        var chickenLegHut = new ChickenLegHut();
        var flyingCarpet = new FlyingCarpet();
        var flyingShip = new FlyingShip();
        var mortar = new Mortar();
        var pumpkinCoach = new PumpkinCoach();
        var walkingBoots = new WalkingBoots();
        
        List<Vehicle> vehicles =
        [
            broom,
            centaur,
            chickenLegHut,
            flyingCarpet,
            flyingShip,
            mortar,
            pumpkinCoach,
            walkingBoots
        ];

        return vehicles;
    }
}