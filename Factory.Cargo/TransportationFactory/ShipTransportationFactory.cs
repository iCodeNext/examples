using Factory.Cargo.Factory;
using Factory.Cargo.Transportation;

namespace Factory.Cargo.TransportationFactory;

public class ShipTransportationFactory : ITransportationFactory
{
    public ITransportation Create() 
        => throw new NotImplementedException("Ship transportation should be initialized with origin and destination");

    public ITransportation Create(string origin, string destination)
        => new ShipTransportation(origin, destination);

    public ITransportation Create(Dictionary<string, object> parameters)
    {
        if (!parameters.TryGetValue("Origin", out object? originObj) || originObj is not string origin)
            throw new ArgumentException("Origin parameter has not defined properly");

        if (!parameters.TryGetValue("Origin", out object? destinationObj) || destinationObj is not string destination)
            throw new ArgumentException("Destination parameter has not defined properly");

        return Create(origin,destination);
    }
}