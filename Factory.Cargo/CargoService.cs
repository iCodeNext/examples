using Factory.Cargo.Factory;
using Factory.Cargo.Transportation;
using Factory.Cargo.TransportationFactory;

namespace Factory.Cargo;

public enum TransportationMode
{
    Air,
    Ship,
    Train
}

public class CargoService
{
    public ITransportation CreateTransportation(
        TransportationMode transportationMode,
        string? origin,
        string? destination)
    {
        return transportationMode switch
        {
            TransportationMode.Air => new AirTransportationFactory().Create(),
            TransportationMode.Ship => new ShipTransportationFactory().Create(origin,destination),
            TransportationMode.Train => new TrainTransportationFactory().Create(),
            _ => throw new NotImplementedException("Requested transport mode is not implemented.")
        };
    }
}