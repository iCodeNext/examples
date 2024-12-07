using Factory.Cargo.Factory;
using Factory.Cargo.TransportationFactory;

namespace Factory.Cargo;

public class CargoFactoryService
{
    private Dictionary<string, ITransportationFactory> _transportationFactories = new();

    public CargoFactoryService(bool addBaseFactories = true)
    {
        if(addBaseFactories) AddBaseFactories();
    }
    private void AddBaseFactories()
    {
        _transportationFactories.Add("Air",new AirTransportationFactory());
        _transportationFactories.Add("Train",new TrainTransportationFactory());
        _transportationFactories.Add("Ship",new ShipTransportationFactory());
    }
    
    
    public void AddTransportationFactory(string mode, ITransportationFactory transportationFactory)
        => _transportationFactories.Add(mode, transportationFactory);

    public ITransportation Create(string mode, Dictionary<string,object> parameters)
    {
        if (_transportationFactories.TryGetValue(mode, out var transportationFactory) || transportationFactory is null)
            throw new NotImplementedException($"The factory {mode} didn't define."); 
        
        return transportationFactory.Create(parameters);
    }
}