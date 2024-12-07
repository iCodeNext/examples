using Factory.Cargo.Factory;

namespace Factory.Cargo.Transportation;

public class AirTransportation : ITransportation
{
    public void SendCargo()
    {
        Console.WriteLine("Sending cargo through air transportation");
    }
}