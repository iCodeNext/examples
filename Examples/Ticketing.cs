public class Ticketing
{
    private readonly ITicketing _ticketing;

    public Ticketing(ITicketing ticketing)
    {
        _ticketing = ticketing;
    }

    public void ReserveTicket()
    {
        _ticketing.Reserve();
    }
}