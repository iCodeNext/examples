using Application.Core.Interfaces;
using Application.Infrastructure.Services.TicketServices;
public class TicketService
{
    public ITicketService Get(string ticketType)
    {
        if (ticketType == "Movie")
            return new MovieTicketService();
        else if (ticketType == "Concert")
            return new ConcertTicketService();
        else if (ticketType == "Flight")
            return new FlightTicketService();
        else
            throw new ArgumentException("Invalid ticket type.");
    }
}
