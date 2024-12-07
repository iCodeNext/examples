using System.Security.Cryptography.X509Certificates;
using Factory.Cargo.Factory;

namespace Factory.Cargo.Transportation;

public class TrainTransportation:ITransportation
{
    public void Initial()
    {
        Console.WriteLine("Initializing train transportation");
    }

    public void SendCargo()
    {
        Console.WriteLine("Sending cargo through train transportation");
    }
}