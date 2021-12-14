namespace CreationalPattern.Builder;

public interface IBuildsPurchaseOrders
{
    void SetId();
    void SetName();
    void SetAddress();
    void SetSupplier();
    void SetItems();
    PurchaseOrder BuildPurchaseOrder();
}