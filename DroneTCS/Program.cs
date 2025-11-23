//task,TaskCompletionSource,taskwhwnall.Task.WhenAll 
async void PartB()
{
    TaskCompletionSource<bool> DroneBrain = new TaskCompletionSource<bool>();
    TaskCompletionSource<bool> DroneMichelle = new TaskCompletionSource<bool>();

    async Task FlyDrone(string name, int speed, TaskCompletionSource<bool> tcs)
    {
        Console.WriteLine($"Drone {name}.Speed: {speed} м/с has started its flight.");

        var monitorCheckpoints = 10;

        try
        {
            for (int i = 1; i < monitorCheckpoints; i++)
            {
                Console.WriteLine($"Monitoring checkpoint {i} for drone {name}.");
                await Task.Delay(640);
                Console.WriteLine($"{name} reached checkpoint {i}");

                if (name == "Michelle" && i == 3)
                {
                    throw new Exception($"FATAL ERROR!!! Engine Failure on Drone {name} at Checkpoint {i}. Aborting mission.");
                }
            }
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
}






