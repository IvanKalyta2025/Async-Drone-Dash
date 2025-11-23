

using System.Data;
using System.Formats.Tar;
using System.Net.Security;
using System.Threading;
using System.Threading.Tasks;







// async Task Runway(string name, int speed)
// {
//     Console.WriteLine($"Drone {name} is taking off at speed {speed} km/h.");

//     var maxCheckpoints = 10;

//     for (int i = 1; i < maxCheckpoints; i++)
//     {
//         Console.WriteLine($"{name} reached checkpoint {i}.");
//         await Task.Delay(640);
//         Console.WriteLine($"{name} is flying...");
//     }
//     Console.WriteLine($"Drone {name} has landed successfully.");
// }

// await Runway("Alpha", 50);
// await Runway("Bravo", 70);
// await Runway("Charlie", 60);






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

