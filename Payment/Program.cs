namespace Payment;

public interface IPaymentMethod
{
    void CalculateDiscounts(decimal amount);
}

public class PayPal : IPaymentMethod
{
    public void CalculateDiscounts(decimal amount)
    {
        Console.WriteLine($"total amount: ${amount}");
    }
}
public class CreditCard : IPaymentMethod
{
    public void CalculateDiscounts(decimal amount)
    {
        Console.WriteLine($"Applying 2% fee for credit card payment.'\n' Processing credit card payment of ${amount * 1.02m}");

    }
}
//Adapter
public class CryptoCurrencyAdapter : IPaymentMethod
{
    private readonly CryptoCurrencyThirdParty _cryptoCurrencyThirdParty;
    public CryptoCurrencyAdapter(CryptoCurrencyThirdParty cryptoCurrencyThirdParty)
    {
        _cryptoCurrencyThirdParty = cryptoCurrencyThirdParty;
    }
    public void CalculateDiscounts(decimal amount)
    {
        _cryptoCurrencyThirdParty.ProcessCryptoPayment(amount);
    }
}
//NullObject
public class UnknownPayment : IPaymentMethod
{

    public void CalculateDiscounts(decimal amount)
    {
        Console.WriteLine($"No adjustment for the selected payment method.'\n'Payment method not supported.Unable to process ${amount}.");

    }
}

//Third Party Class
public class CryptoCurrencyThirdParty
{
    public void ProcessCryptoPayment(decimal amount)
    {
        Console.WriteLine($"Processing cryptocurrency payment of ${amount} via third-party library");

    }
}
//Factory
public class PaymentFactory
{
    public static IPaymentMethod GetPaymentMethod(string paymentMethod)
    {
        switch (paymentMethod)
        {
            case "CreditCard":
                return new CreditCard();

            case "PayPal":
                return new PayPal();

            case "CryptoCurrency":
                return new CryptoCurrencyAdapter(new CryptoCurrencyThirdParty());

            default :
                return new UnknownPayment();

        }
    }
}


class Program
{
    static void Main(string[] args)
    {

        ProcessPayment("CreditCard", 100);
        ProcessPayment("CryptoCurrency", 200);
        ProcessPayment("PayPal", 250);
        ProcessPayment("Unsupported", 150);
    }

    static void ProcessPayment(string paymentMethod, decimal amount)
    {
        var processor = PaymentFactory.GetPaymentMethod(paymentMethod);
        processor.CalculateDiscounts(amount);
    }
}

