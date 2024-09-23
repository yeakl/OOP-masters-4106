namespace RaceSimulator;

using Model.Vehicle;
using Model.Race;

class Program
{
    static void Main(string[] args)
    {
        var broom = new Broom();
        var centaur = new Centaur();
        var chickenLegHut = new ChickenLegHut();
        var flyingCarpet = new FlyingCarpet();
        var flyingShip = new FlyingShip();
        var mortar = new Mortar();
        var pumpkinCoach = new PumpkinCoach();
        var walkingBoots = new WalkingBoots();
        

        var race = new Race(distance: 10000, RaceType.Any);
        race.RegisterMember(flyingCarpet);
        race.RegisterMember(flyingShip);
        race.RegisterMember(mortar);
        race.RegisterMember(walkingBoots);
        
        race.Start();
    }
}