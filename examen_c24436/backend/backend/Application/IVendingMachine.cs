using backend.Domain;

namespace backend.Application
{
    public interface IVendingMachine
    {
        PurchaseResponseModel buyDrinks(PurchaseRequestModel purchaseRequest);
    }
}
