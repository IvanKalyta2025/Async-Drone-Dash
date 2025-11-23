

using System.Data;
using System.Formats.Tar;
using System.Net.Security;
using System.Threading;
using System.Threading.Tasks;




Console.WriteLine("1 - Thread + Join");
Console.WriteLine("2 - Task + TCS");
Console.WriteLine("3 - async/await");
Console.WriteLine("4 - API");

var input = Console.ReadLine();


switch (input)
{
    case
        "1":
        PartA();
        break;

    case
        "2":
        PartB();
        break;
    case
        "3":
        PartC();
        break;
    case
        "4":
        PartD();
        break;
    default:
        Console.WriteLine("404");
        break;
}






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




void PartA()
{

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

}

void PartB()

//task,TaskCompletionSource,taskwhwnall.Task.WhenAll 
{
    TaskCompletionSource<bool> DroneBrain = new TaskCompletionSource<bool>();
    TaskCompletionSource<bool> DroneMichel = new TaskCompletionSource<bool>();

    Task FlyDrone(string name, int speed)
    {
        var monitorCheckpoints = 10;
        for (int i = 1; i < monitorCheckpoints; i++)
        {
            Console.WriteLine($"Monitoring checkpoint {i} for drone {name}.");
            Thread.Sleep(640);
        }
        FlyDrone("Brain", 100);
        return Task.CompletedTask;
    }


}


void PartC()
{

}

void PartD()
{

}


