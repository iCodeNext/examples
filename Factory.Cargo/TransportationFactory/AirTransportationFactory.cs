using Factory.Cargo.Factory;
using Factory.Cargo.Transportation;

namespace Factory.Cargo.TransportationFactory;

public class AirTransportationFactory : ITransportationFactory
{
    private ITransportation? _transportation;

    public ITransportation Create()
        => _transportation ??= new AirTransportation();

    public ITransportation Create(string origin, string destination) =>
        throw new NotImplementedException("Air transportation should be initialized without any args");

    public ITransportation Create(Dictionary<string, object> _) => Create();
}