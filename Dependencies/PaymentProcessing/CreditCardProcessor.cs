namespace Dependencies.PaymentProcessing;

public class CreditCardProcessor : IPaymentProcessor
{
    public string HandlePayment(decimal amount)
    {
        Thread.Sleep(3000);
        return $"Handling Credit Card Payment for amount: {amount}";
    }
}