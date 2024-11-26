public class TicketService
{
    public string Get(string ticketType)
    {
        if (ticketType == "Movie")
            return new MovieTicketService().GetTicket(ticketType);
        else if (ticketType == "Concert")
            return new ConcertTicketService().GetTicket(ticketType);
        else if (ticketType == "Flight")
            return new FlightTicketService().GetTicket(ticketType);
        else
            throw new ArgumentException("Invalid ticket type.");
    }
}


public interface ITicketService
{
    public string GetTicket(string type);
}

public class MovieTicketService : ITicketService
{
    public string GetTicket(string type)
    {
        throw new NotImplementedException();
    }
}

public class ConcertTicketService : ITicketService
{
    public string GetTicket(string type)
    {
        throw new NotImplementedException();
    }
}

public class FlightTicketService : ITicketService
{
    public string GetTicket(string type)
    {
        throw new NotImplementedException();
    }
}
