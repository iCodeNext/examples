using Payment.Factories.Common;

namespace Payment.Factories;

public class PaymentProcessorFactory
{
    private readonly Dictionary<string, Func<decimal, decimal, PaymentProcessor>> _paymentProcessors = new();

    public PaymentProcessorFactory(bool addBaseFactories = true)
    {
        _paymentProcessors.Add("Null", (_, _) => new CreditPaymentProcessor(0, 0));
        if (!addBaseFactories)
            return;
        _paymentProcessors.Add("Credit", (_, discount) => new CreditPaymentProcessor((decimal)0.2, discount));
        _paymentProcessors.Add("Crypto", (fee, discount) => new CryptoPaymentProcessorAdapter(fee, discount));
    }

    public void RegisterPaymentProcessor(string methodName, Func<decimal, decimal, PaymentProcessor> func) =>
        _paymentProcessors.Add(methodName, func);

    public PaymentProcessor Create(string methodName, decimal fee, decimal discount)
    {
        if (!_paymentProcessors.TryGetValue(methodName, out var paymentProcessor))
            return _paymentProcessors["Null"](0,0);
        return paymentProcessor(fee, discount);
    }
}