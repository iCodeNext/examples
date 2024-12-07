namespace Payment.ExternalCryptoLib;

public class ExternalCryptoProvider
{
    public int Process(decimal amount,string currency,string wallet)
    {
        Console.WriteLine("ExternalCryptoProvider lib connecting");
        if (new Random(7).Next(0, 10) > 5)
            return 0;
        return 1;
    }
}