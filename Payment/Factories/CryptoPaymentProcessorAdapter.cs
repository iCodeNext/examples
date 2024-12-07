using Payment.ExternalCryptoLib;
using Payment.Factories.Common;

namespace Payment.Factories;

public class CryptoPaymentProcessorAdapter(decimal discount, decimal fee) : PaymentProcessor(discount, fee)
{
    private readonly ExternalCryptoProvider _externalCryptoProvider = new();
    protected override string PaymentProcessorName { get; } = "Crypto Payment Processor";
    private const string DefaultWallet = "0xbs78djsj";

    public override PaymentStatus ProcessPayment(Money amount)
    {
        Console.WriteLine($"Processing payment with {PaymentProcessorName} method");
        Console.WriteLine($"Processing {PaymentProcessorName} discount");
        var amountAfterDiscount = ProcessDiscount(amount);
        Console.WriteLine($"Processing {PaymentProcessorName} fee");
        var amountAfterFee  = ProcessFee(amountAfterDiscount);
        Console.WriteLine($"Processing {PaymentProcessorName} with amount {amountAfterFee}");
        _externalCryptoProvider.Process(amountAfterFee.Amount,amountAfterFee.Currency,DefaultWallet);
        return PaymentStatus.Success;
    }
}