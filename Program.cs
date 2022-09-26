//creo evnto
Event newEvent = new Event("Fiera", new DateOnly(2023, 05, 12), 1000);


//Console.WriteLine(newEvent.ToString());

//reserveAndCancel(newEvent);


//program mileston 2
ProgramEvent EventsGroup = new ProgramEvent("Concerti");

EventsGroup.addEvent(newEvent);

Event e = CreateEvent();

Event CreateEvent()
{
    Event? e = null;
    Console.WriteLine("do you wonna ad a new events? (y/n): ");
    string prompt = Console.ReadLine() ?? "";
    try
    {
        
        while(prompt == "y")
        {
            Console.Write("Inserisci il nome dell'evento: ");
            string title = Console.ReadLine() ?? "";
            Console.Write("Inserisci la data dell'evento(gg/mm/aaaa): ");
            DateOnly date = DateString(Console.ReadLine());
            Console.Write("Inserisci la capienza dell'evento: ");
            int capacity = Convert.ToInt32(Console.ReadLine() ?? "0");
            Console.WriteLine("Congrats you add a new avents");
            e = new Event(title, date, capacity);
            Console.Write("Do you wonna add more events (y/n): ");
            prompt = Console.ReadLine() ?? "";
                if(prompt == "n")
                {
                Console.WriteLine(e.ToString());
                    
                   
                }
            
        }
        reserveAndCancel(e);

    }
    catch (ArgumentException error)
    {
        Console.WriteLine(error.Message); 
    }

    return e;
}


DateOnly DateString(string date)
{
    string[] dateArray = date.Split('/');


    int day = Convert.ToInt32(dateArray[0]);
    int month = Convert.ToInt32(dateArray[1]);
    int year = Convert.ToInt32(dateArray[2]);
    return new DateOnly(year, month, day);
}



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
