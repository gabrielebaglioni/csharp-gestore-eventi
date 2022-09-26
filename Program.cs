//creo evnto
Event newEvent = new Event("Fiera", new DateOnly(2023, 05, 12), 1000);


Console.WriteLine(newEvent.ToString());


//program
reserveAndCancel(newEvent);
//uso funzioni
void ReserveSeats(Event e)
{
    Console.Write("How many seats do you wonna reserve? ");
    int seats = Convert.ToInt32(Console.ReadLine() ?? "0");
    try
    {
        e.Reserve(seats);
    }
    catch (ArgumentException error)
    {
        Console.WriteLine(error.Message);
    }
    Console.WriteLine("booking was successful");
}

void CancelSeats(Event e)
{
    Console.WriteLine("How many seats do you wonna cancell: ");
    int seats = Convert.ToInt32(Console.ReadLine() ?? "0");
    try
    {
        e.Cancel(seats);
    }
    catch (ArgumentException error)
    {
        Console.WriteLine(error.Message);
    }
}

void printInfo(Event e)
{
    Console.WriteLine($"Reserved seats = {e.Reserved}");
    Console.WriteLine($"Seats available = {e.Capacity}");
}

void reserveAndCancel(Event e)
{
    printInfo(e);
    ReserveSeats(e);
    Console.Write("Do you wonna cancell more seats? (y/n): ");
    string prompt = Console.ReadLine() ?? "";

    while (prompt == "y")
    {
        try
        {
            CancelSeats(e);
            printInfo(e);
            
            Console.Write("Do you wonna cancell more seats? (y/n): ");
            prompt = Console.ReadLine() ?? "";
        }
        catch (ArgumentException error)
        {
            Console.WriteLine(error.Message);
        }
    }
    
    Console.Clear();
    Console.WriteLine(e.ToString());
    printInfo(e);
}
