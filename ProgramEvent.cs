public class ProgramEvent
{
    

    private string Title { get; }
    private List<Event> events { get; }


    //costructur
    public ProgramEvent(string title)
    {
        Title = title;
        events = new List<Event>();
    }

    

    //Function
    public void addEvent(Event e)
    {
        this.events.Add(e);
    }

#pragma warning disable CA1822 // Mark members as static
    public List<Event> GetEventWithFormDate(DateOnly date)
#pragma warning restore CA1822 // Mark members as static
    {
        List<Event> result = new List<Event>();

        foreach (Event e in events)
        {
            if (e.Date == date)
            {
                result.Add(e);
            }
        }
        return result;
    }

    public static void PrintEvents(List<Event> events)
    {
        foreach(Event e in events)
        {
            Console.WriteLine(e.ToString());
        }
    }
    public void ClearProgram()
    {
        events.Clear();
    }
    public int CountEvents()
    {
        return events.Count;
    }
    
}