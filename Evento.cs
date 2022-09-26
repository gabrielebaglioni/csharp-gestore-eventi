public class Event
{
    private DateOnly date;

    public string Title { get; set; }
    // Set the date whit controll
    public DateOnly Date
    {
        get => date;
        set
        {
            if (value < DateOnly.FromDateTime(DateTime.Now))
            {
                throw new ArgumentException("Date must be in the future");
            }

            date = value;
        }
    }
    // init variable with private set 
    public int Capacity { get; private set; }
    public int Reserved { get; private set; }
    //constructor
    public Event(string title, DateOnly date, int capacity)
    {
        if (title == "")
        {
            throw new ArgumentException("Title cannot be empty");
        }
        Title = title;
        if (date < DateOnly.FromDateTime(DateTime.Now))
        {
            throw new ArgumentException("Date must be in the future");
        }
        this.date = date;
        if (capacity < 1)
        {
            throw new ArgumentException("Capacity must be greater than 0");
        }
        Capacity = capacity;
        Reserved = 0;
    }
    //function

    public void Reserve(int seats)
    {
        if (seats < 1)
        {
            throw new ArgumentException("Seats must be greater than 0");
        }

        if (seats > Capacity - Reserved)
        {
            throw new ArgumentException("Not enough seats available");
        }

        if (DateOnly.FromDateTime(DateTime.Now) > Date)
        {
            throw new ArgumentException("Event already happened");
        }

        Reserved += seats;
        Capacity -= seats;
    }

    public void Cancel(int seats)
    {
        if (seats < 1)
        {
            throw new ArgumentException("Seats must be more then 0");
        }

        if (seats > Reserved)
        {
            throw new ArgumentException("There isn't enough seats");
        }

        if (DateOnly.FromDateTime(DateTime.Now) > Date)
        {
            throw new ArgumentException("Event already happened");
        }

        Reserved -= seats;
        Capacity += seats;
    }

    public override string ToString()
    {
        return $"{Title} - {Date.ToString("dd/MM/yyyy")}";
    }



}