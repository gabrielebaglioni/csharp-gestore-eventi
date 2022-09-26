using System.Data;

public class Evento
{
    public string Titolo
    {
        get
        {
            return Titolo;
        }
        set
        {
            if (string.IsNullOrEmpty(Titolo))
            {
                throw new checkTitle("Iserisci un titolo");
            }
            Titolo = value;
        }
    }
    public DateTime Data
    {
        get
        {
            return Data;
        }
        set
        {
            if (Data < DateTime.Now)
            {
                throw new CheckData("La data deve essere successiva al data odierna");
            }
            Data = value;
        }
    }

    public int PostiPrenotati { get; private set; }
    public int CapienzaMax
    {
        get
        {
            return CapienzaMax;
        }
        private set
        {
            if (CapienzaMax < 1)
            {
                throw new checkCapienza("La Capienza massima dell' evento deve essere maggiore di 0");
            }
            CapienzaMax = value;
        }
    }

    public Evento(string title, DateTime data, int capienza)
    {

        Titolo = title;
        Data = data;
        CapienzaMax = capienza;
        PostiPrenotati = 0;
    }
}





public class checkTitle : Exception
{
    public checkTitle(string message) : base(message) { }
}
public class CheckData : Exception
{
    public CheckData(string message) : base(message) { }
}
public class checkCapienza : Exception
{
    public checkCapienza(string message) : base(message) { }
}




//public void checkTitolo()
//{
//    if (string.IsNullOrEmpty(Titolo))
//    {
//        Console.WriteLine("write a title");

//    }
//}
//public void checkCapienzaMax()
//{
//    if (CapienzaMax < 0)
//    {
//        CapienzaMax *= -1;
//    }

//}