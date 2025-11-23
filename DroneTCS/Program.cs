//task,TaskCompletionSource,taskwhwnall.Task.WhenAll 
async void PartB()
{
    TaskCompletionSource<bool> DroneBrain = new TaskCompletionSource<bool>();
    TaskCompletionSource<bool> DroneMichel = new TaskCompletionSource<bool>();

    async Task FlyDrone(string name, int speed, TaskCompletionSource<bool> tcs)
    {
        Console.WriteLine($"Drone {name}.Speed: {speed} м/с has started its flight.");

        var monitorCheckpoints = 10;

        try
        {

        }
        catch (Exception fatal_error)
        {
            Console.WriteLine($" [ERROR] Drone {name} caught an exception.");
            tcs.SetException(fatal_error);
        }

        for (int i = 1; i < monitorCheckpoints; i++)
        {
            Console.WriteLine($"Monitoring checkpoint {i} for drone {name}.");
            Thread.Sleep(640);
        }
        // FlyDrone("Brain", 100);
        // return Task.CompletedTask;
    }
}






