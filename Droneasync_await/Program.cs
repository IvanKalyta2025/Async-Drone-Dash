
async Task FlyDrone(string name, int speed)
{
    Console.WriteLine($"Drone {name} is taking off at speed {speed} km/h.");

    var maxCheckpoints = 10;
    for (int i = 0; i < maxCheckpoints; i++)
    {
        await Task.Delay(500);
        Console.WriteLine($"{name} Reached checkpoint {i}.");
        if (name == "Charlie" && i == 3)
        {
            throw new Exception($"FATAL ERROR!!! Collision detected on Drone {name} at checkpoint {i}.");
        }
    }
    Console.WriteLine($"Drone {name} has landed successfully.");
}


Task flightAlpha = FlyDrone("Alpha", 50);
Task flightBravo = FlyDrone("Bravo", 70);
Task flightCharlie = FlyDrone("Charlie", 60);

Task allDrones = Task.WhenAll(flightAlpha, flightBravo, flightCharlie);

try
{
    await allDrones;
    Console.WriteLine(" Task.WhenAll (+)");
}

catch
{
    if (allDrones.Exception != null)
    {
        foreach (var innerEx in allDrones.Exception.InnerExceptions)
        {
            Console.WriteLine($"Detailed Failure: {innerEx.Message}");
        }
    }
}
