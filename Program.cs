

using System.Data;
using System.Net.Security;

async Task Runway(string name, int speed)
{
    Console.WriteLine($"Drone {name} is taking off at speed {speed} km/h.");

    var maxCheckpoints = 10;

    for (int i = 1; i < maxCheckpoints; i++)
    {
        Console.WriteLine($"{name} reached checkpoint {i}.");
        await Task.Delay(640);
        Console.WriteLine($"{name} is flying...");
    }
    Console.WriteLine($"Drone {name} has landed successfully.");
}

await Runway("Alpha", 50);
await Runway("Bravo", 70);
await Runway("Charlie", 60);

