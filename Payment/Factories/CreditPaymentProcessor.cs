using Payment.Factories.Common;

namespace Payment.Factories;

public class CreditPaymentProcessor(decimal fee, decimal discount) : PaymentProcessor(fee, discount)
{
    protected override string PaymentProcessorName => "Credit";

}