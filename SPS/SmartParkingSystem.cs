using System;
using System.Threading.Tasks;

class SmartParkingSystem
{
    // Simulate checking a parking ticket
    public async Task CheckTicketAsync(string carNumber)
    {
        Console.WriteLine($"[Car {carNumber}] Checking ticket...");
        await Task.Delay(2000); // Simulating processing time
        Console.WriteLine($"[Car {carNumber}] Ticket is valid!");
    }

    // Simulate opening the entry barrier
    public async Task OpenEntryBarrierAsync(string carNumber)
    {
        Console.WriteLine($"[Car {carNumber}] Opening entry barrier...");
        await Task.Delay(1500);
        Console.WriteLine($"[Car {carNumber}] Entry barrier opened.");
    }

    // TODO: Implement parking logic
    public async Task ParkCarAsync(string carNumber)
    {
        // Student implementation
    }

    // TODO: Implement payment processing
    public async Task ProcessPaymentAsync(string carNumber)
    {
        // Student implementation
    }

    // TODO: Implement logic for opening the exit barrier
    public async Task OpenExitBarrierAsync(string carNumber)
    {
        // Student implementation
    }

    // TODO: Implement database update logic
    public async Task UpdateDatabaseAsync(string carNumber)
    {
        // Student implementation
    }

    // Implement the process for a car entering the parking lot
    public async Task CarEnterAsync(string carNumber)
    {
        await CheckTicketAsync(carNumber);
        await OpenEntryBarrierAsync(carNumber);
        await ParkCarAsync(carNumber);
        Console.WriteLine($"[Car {carNumber}] Successfully parked.\n");
    }

    // Implement the process for a car exiting the parking lot
    public async Task CarExitAsync(string carNumber)
    {
        await ProcessPaymentAsync(carNumber);
        await Task.WhenAll(OpenExitBarrierAsync(carNumber), UpdateDatabaseAsync(carNumber));
        Console.WriteLine($"[Car {carNumber}] Successfully exited.\n");
    }
}
