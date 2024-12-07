using Factory.Cargo.Factory;

namespace Factory.Cargo.Transportation;

public class ShipTransportation(string Origin,string Destination) : ITransportation
{
    public void SendCargo()
    {
        Console.WriteLine("Sending cargo through ship transportation");
    }
}