using Dependencies.PaymentProcessing;

namespace StructuralPattern.Bridge;

public abstract class FarmerMarketVendor
{
    protected readonly IPaymentProcessor PaymentProcessor;

    protected FarmerMarketVendor(IPaymentProcessor paymentProcessor)
    {
        PaymentProcessor = paymentProcessor;
    }

    public virtual string ProcessPayment(decimal payment, string vendor)
    {
        throw new NotImplementedException("Please override this method in a concrete implementation");
    }
}