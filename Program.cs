

using System.Data;
using System.Net.Security;

void Runway(string name, int speed)
{
    Console.WriteLine($"Drone {name} is taking off at speed {speed} km/h.");

    var maxCheckpoints = 10;

    for (int i = 0; i < maxCheckpoints; i++)
    {
        Console.WriteLine($"{name} reached checkpoint {i}.");
        Thread.Sleep(640);
        Console.WriteLine($"{name} is flying...");
    }
    Console.WriteLine($"Drone {name} has landed successfully.");
}

Runway("Alpha", 50);
Runway("Bravo", 70);
Runway("Charlie", 60);