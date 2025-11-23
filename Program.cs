

using System.Data;
using System.Net.Security;

void Runway(string name, int speed)
{
    Console.WriteLine($"Drone {name} is taking off at speed {speed} km/h.");

    var maxCheckpoints = 10;

    for (int i = 0; i < maxCheckpoints; i++)
    {
        Console.WriteLine($"{name} reached checkpoint {i}.");
    }
}

Runway("Alpha", 50);