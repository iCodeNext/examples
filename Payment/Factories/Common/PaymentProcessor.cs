namespace Payment.Factories.Common;

public abstract class PaymentProcessor(decimal fee, decimal discount)
{
    protected abstract string PaymentProcessorName { get; }
    protected decimal Fee { private set; get; } = fee;
    protected decimal Discount { private set; get; } = discount;
    protected virtual Money ProcessDiscount(Money amount) => amount.WithDiscount(Discount);
    protected virtual Money ProcessFee(Money amount) => amount.WithFee(Fee);

    public virtual PaymentStatus ProcessPayment(Money amount)
    {
        Console.WriteLine($"Processing payment with {PaymentProcessorName} method");
        Console.WriteLine($"Processing {PaymentProcessorName} discount");
        var amountAfterDiscount = ProcessDiscount(amount);
        Console.WriteLine($"Processing {PaymentProcessorName} fee");
        var amountAfterFee  = ProcessFee(amountAfterDiscount);
        Console.WriteLine($"Processing {PaymentProcessorName} with amount {amountAfterFee}");
        return PaymentStatus.Success;
    }
}