using System;
using System.Diagnostics;
using System.Threading.Tasks;

class SmartParkingSystem
{
    private void PrintThreadInfo(string methodName)
    {
        Console.WriteLine($"[{methodName}] Process ID: {Process.GetCurrentProcess().Id}, Thread ID: {Thread.CurrentThread.ManagedThreadId}, Thread Count: {Process.GetCurrentProcess().Threads.Count}");
    }

    public async Task CheckTicketAsync(string carNumber)
    {
        PrintThreadInfo(nameof(CheckTicketAsync));
        Console.WriteLine($"[Car {carNumber}] Checking ticket...");
        await Task.Delay(2000);
        Console.WriteLine($"[Car {carNumber}] Ticket is valid!");
    }

    public async Task OpenEntryBarrierAsync(string carNumber)
    {
        PrintThreadInfo(nameof(OpenEntryBarrierAsync));
        Console.WriteLine($"[Car {carNumber}] Opening entry barrier...");
        await Task.Delay(1500);
        Console.WriteLine($"[Car {carNumber}] Entry barrier opened.");
    }

    public async Task ParkCarAsync(string carNumber)
    {
        PrintThreadInfo(nameof(ParkCarAsync));
        Console.WriteLine($"[Car {carNumber}] Searching for a parking spot...");
        await Task.Delay(3000);
        Console.WriteLine($"[Car {carNumber}] Successfully parked.\n");
    }

    public async Task ProcessPaymentAsync(string carNumber)
    {
        PrintThreadInfo(nameof(ProcessPaymentAsync));
        Console.WriteLine($"[Car {carNumber}] Processing payment...");
        await Task.Delay(2500);
        Console.WriteLine($"[Car {carNumber}] Payment successful!");
    }

    public async Task OpenExitBarrierAsync(string carNumber)
    {
        PrintThreadInfo(nameof(OpenExitBarrierAsync));
        Console.WriteLine($"[Car {carNumber}] Opening exit barrier...");
        await Task.Delay(1500);
        Console.WriteLine($"[Car {carNumber}] Exit barrier opened.");
    }

    public async Task UpdateDatabaseAsync(string carNumber)
    {
        PrintThreadInfo(nameof(UpdateDatabaseAsync));
        Console.WriteLine($"[Car {carNumber}] Updating database...");
        await Task.Delay(1000);
        Console.WriteLine($"[Car {carNumber}] Database updated.");
    }

    public async Task CarEnterAsync(string carNumber)
    {
        PrintThreadInfo(nameof(CarEnterAsync));
        await CheckTicketAsync(carNumber);
        await OpenEntryBarrierAsync(carNumber);
        await ParkCarAsync(carNumber);
    }

    public async Task CarExitAsync(string carNumber)
    {
        PrintThreadInfo(nameof(CarExitAsync));
        await ProcessPaymentAsync(carNumber);
        await Task.WhenAll(OpenExitBarrierAsync(carNumber), UpdateDatabaseAsync(carNumber)); // Execute these in parallel
        Console.WriteLine($"[Car {carNumber}] Successfully exited.\n");
    }
}
