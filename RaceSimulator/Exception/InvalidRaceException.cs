namespace RaceSimulator.Exception;

using System;

public class InvalidRaceException(string message) : Exception(message);