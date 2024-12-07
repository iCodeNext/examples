namespace Payment.Factories.Common;

public record Money(decimal Amount, string Currency)
{
    public Money WithDiscount(decimal discount) => this with { Amount = (1 - discount) * Amount };
    public Money WithFee(decimal fee) => this with { Amount = Amount * fee + Amount };
    public override string ToString()
    {
        return $"{Amount} {Currency}";
    }
}