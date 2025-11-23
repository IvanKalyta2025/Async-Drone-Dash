//task,TaskCompletionSource,taskwhwnall.Task.WhenAll 

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




