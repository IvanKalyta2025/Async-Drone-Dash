//task,TaskCompletionSource,taskwhwnall.Task.WhenAll 

TaskCompletionSource<bool> DroneBrain = new TaskCompletionSource<bool>();
TaskCompletionSource<bool> DroneMichelle = new TaskCompletionSource<bool>();

async Task FlyDrone(string name, int speed, TaskCompletionSource<bool> tcs)
{
    Console.WriteLine($"Drone {name}.Speed: {speed} м/с has started its flight.");

    var monitorCheckpoints = 10;

    try
    {
        for (int i = 0; i < monitorCheckpoints; i++)
        {
            Console.WriteLine($"Monitoring checkpoint {i} for drone {name}.");
            await Task.Delay(640);
            Console.WriteLine($"{name} reached checkpoint {i}");

            if (name == "Michelle" && i == 3)
            {
                throw new Exception($"FATAL ERROR!!! Engine Failure on Drone {name} at Checkpoint {i}. Aborting mission.");
            }
        }
        Console.WriteLine($"Drone {name} has completed its route!");
        tcs.SetResult(true);
    }
    catch (Exception fatal_error)
    {
        Console.WriteLine($" [ERROR] Drone {name} caught an exception.");
        tcs.SetException(fatal_error);
    }

    // FlyDrone("Brain", 100);
    // return Task.CompletedTask;
}
Task flightBrian = FlyDrone("Brian", 100, DroneBrain);
Task flightMichelle = FlyDrone("Michelle", 80, DroneMichelle);

Task allFlightsCompleted = Task.WhenAll(DroneBrain.Task, DroneMichelle.Task);

try
{
    await allFlightsCompleted;
}

catch
{
    if (allFlightsCompleted.Exception != null)
    {
        // Task.Exception является AggregateException, который содержит все ошибки
        foreach (var innerEx in allFlightsCompleted.Exception.InnerExceptions)
        {
            Console.WriteLine($"Detailed Failure: {innerEx.Message}");
        }
    }
}
await Task.WhenAll(flightBrian, flightMichelle);



