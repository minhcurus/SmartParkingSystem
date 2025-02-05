using System;
using System.Diagnostics;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        SmartParkingSystem parking = new SmartParkingSystem();

        Console.WriteLine("Smart Parking System is starting...\n");

        // Print the main thread info
        Console.WriteLine($"[Main Thread] Process ID: {Process.GetCurrentProcess().Id}, Thread ID: {Thread.CurrentThread.ManagedThreadId}");

        // Simulate car entry and exit with isolated thread management
        await parking.CarEnterAsync("A123");

        await Task.Delay(5000); // Simulate time before exiting

        await parking.CarExitAsync("A123");

        // Print total number of threads
        Console.WriteLine($"Total number of threads: {Process.GetCurrentProcess().Threads.Count}");
        Console.WriteLine("Parking system transaction completed!\n");
    }
}
