using Dependencies.PaymentProcessing;

namespace StructuralPattern.Bridge.Vendors;

public class CattleFarmer : FarmerMarketVendor
{
    public CattleFarmer(IPaymentProcessor paymentProcessor) : base(paymentProcessor)
    {

    }

    public override string ProcessPayment(decimal payment, string vendor)
    {
        Console.WriteLine($"CattleFarmer: {vendor} is processing " +
                          $"a ${payment} payment for grass-fed short ribs");

        return PaymentProcessor.HandlePayment(payment);
    }
}