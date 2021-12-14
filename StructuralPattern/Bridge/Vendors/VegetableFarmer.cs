using Dependencies.PaymentProcessing;

namespace StructuralPattern.Bridge.Vendors;

public class VegetableFarmer : FarmerMarketVendor
{
    public VegetableFarmer(IPaymentProcessor paymentProcessor) : base(paymentProcessor)
    {
    }

    public override string ProcessPayment(decimal payment, string vendor)
    {
        Console.WriteLine($"Vegetable Farmer: {vendor} is processing " +
                          $"a ${payment} for a bag of organic carrots");

        return PaymentProcessor.HandlePayment(payment);
    }
}