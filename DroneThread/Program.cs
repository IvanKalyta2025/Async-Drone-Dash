using System;
using System.Threading;

var t = new Thread(() =>
{
    string name = "Alpha";
    int speed = 50;
    Thread.Sleep(2000);
    Console.WriteLine($"Monitoring drone operations for {name} at speed {speed} km/h...");
    var monitorCheckpoints = 10;
    for (int i = 0; i < monitorCheckpoints; i++)
    {
        Console.WriteLine($"Monitoring checkpoint {i} for drone {name}.");
        Thread.Sleep(640);
    }
    Console.WriteLine($"Monitoring completed for drone {name}.");
});

var t2 = new Thread(() =>
{
    string name = "Bravo";
    int speed = 70;
    Thread.Sleep(2000);
    Console.WriteLine($"Monitoring drone operations for {name} at speed {speed} km/h...");
    var monitorCheckpoints = 10;
    for (int i = 0; i < monitorCheckpoints; i++)
    {
        Console.WriteLine($"Monitoring checkpoint {i} for drone {name}.");
        Thread.Sleep(640);
    }
    Console.WriteLine($"Monitoring completed for drone {name}.");
});


t2.Start();
t2.Join();

t.Start();
t.Join();
Console.WriteLine("All drones finished");

