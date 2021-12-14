using Dependencies.PaymentProcessing;

namespace StructuralPattern.Bridge.Vendors;

public class Florist : FarmerMarketVendor
{
    public Florist(IPaymentProcessor paymentProcessor) : base(paymentProcessor)
    {
    }

    public override string ProcessPayment(decimal payment, string vendor)
    {
        Console.WriteLine($"Florist: {vendor} is processing " +
                          $"a ${payment} payment for a vial of lavender oil");

        return PaymentProcessor.HandlePayment(payment);
    }
}