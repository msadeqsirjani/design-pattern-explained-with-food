namespace Dependencies.PaymentProcessing;

public class GiftCardProcessor : IPaymentProcessor
{
    public string HandlePayment(decimal amount)
    {
        Thread.Sleep(3000);
        return $"Handling Gift Card Payment for amount: {amount}";
    }
}