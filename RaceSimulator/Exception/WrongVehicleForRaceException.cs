namespace RaceSimulator.Exception;

using System;

public class WrongVehicleForRaceException(string message) : Exception(message);