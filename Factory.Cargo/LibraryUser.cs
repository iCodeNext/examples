using Factory.Cargo.Factory;
using Factory.Cargo.Transportation;

namespace Factory.Cargo;

public class LibraryUser
{
    private readonly CargoFactoryService _factoryService = new CargoFactoryService();

    public LibraryUser()
    {
        _factoryService.AddTransportationFactory("Truck", new TruckTransportationFactory());

        var truckTransportation = _factoryService.Create("Truck", new Dictionary<string, object>
        {
            { "TruckType", "Trailer" },
        });
    }
}

public class TruckTransportation(string TruckType) : ITransportation
{
    public void SendCargo()
    {
        Console.WriteLine($"Sending cargo through {TruckType} truck.");
    }
}

public class TruckTransportationFactory : ITransportationFactory
{
    public ITransportation Create()
    {
        throw new NotImplementedException("Use parameter overload instead");
    }

    public ITransportation Create(Dictionary<string, object> parameters)
    {
        if (parameters.TryGetValue("TruckType", out object? truckTypeObj) && truckTypeObj is string truckType)
            return new TruckTransportation(truckType);
        
        throw new ArgumentNullException($"TruckType has not defined properly");

    }

    public ITransportation Create(string origin, string destination)
    {
        throw new NotImplementedException("Use parameter overload instead");
    }
}