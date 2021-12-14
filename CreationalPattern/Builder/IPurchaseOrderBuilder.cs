namespace CreationalPattern.Builder;

public interface IPurchaseOrderBuilder
{
    IPurchaseOrderBuilder WithId(string id);
    IPurchaseOrderBuilder ForCompany(string companyName);
    IPurchaseOrderBuilder AtAddress(string address);
    IPurchaseOrderBuilder FromSupplier(Supplier supplier);
    IPurchaseOrderBuilder ForItems(List<LineItem> lineItems);
    PurchaseOrder BuildPurchaseOrder();
}