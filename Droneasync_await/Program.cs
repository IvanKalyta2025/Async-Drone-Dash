async Task FlyDrone(string name, int speed)
{
    Console.WriteLine($"Drone {name} is taking off at speed {speed} km/h.");

    var maxCheckpoints = 10;
    for (i = 0; i < maxCheckpoints; i++)
    {
        await Task.Delay(500);
        Console.WriteLine($"{name} Reached checkpoint {i}.");
    }



    Task flightAlpha = FlyDrone("Alpha", 50);
    Task flightBravo = FlyDrone("Bravo", 70);
    Task flightCharlie = FlyDrone("Charlie", 60);
}