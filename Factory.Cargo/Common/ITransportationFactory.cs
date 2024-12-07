namespace Factory.Cargo.Factory;

public interface ITransportationFactory
{
    public ITransportation Create();
    public ITransportation Create(string origin, string destination);

    public ITransportation Create(Dictionary<string,object> parameters)
    {
        throw new NotImplementedException(); // to prevent from client code destruction on package update.
    }
}