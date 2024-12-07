using Payment.Factories.Common;

namespace Payment.Factories;

public class NullPaymentProcessor(decimal fee, decimal discount) :PaymentProcessor(fee, discount)
{
    protected override string PaymentProcessorName => "Null Payment Processor";
    public override PaymentStatus ProcessPayment(Money amount)
    {
        Console.WriteLine("Null payment processing");
        return PaymentStatus.Failed;
    }
}