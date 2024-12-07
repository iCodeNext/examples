using Factory.Cargo.Factory;
using Factory.Cargo.Transportation;

namespace Factory.Cargo.TransportationFactory;

public class TrainTransportationFactory : ITransportationFactory
{
    public ITransportation Create()
    {
        var trainTransportation = new TrainTransportation();
        trainTransportation.Initial();
        return trainTransportation;
    }


    public ITransportation Create(string origin, string destination) =>
        throw new NotImplementedException("Train transportation should be initialized without any args");

    public ITransportation Create(Dictionary<string, object> _) => Create();
}