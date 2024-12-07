using Payment.Factories;
using Payment.Factories.Common;

var providerService = new PaymentProcessorFactory();
var crypto = providerService.Create("Crypto", (decimal)0.02, (decimal)0.4);
crypto.ProcessPayment(new Money(10000,"USDT"));