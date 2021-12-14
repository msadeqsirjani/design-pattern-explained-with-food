namespace Dependencies.PaymentProcessing;

public interface IPaymentProcessor
{
    string HandlePayment(decimal amount);
}