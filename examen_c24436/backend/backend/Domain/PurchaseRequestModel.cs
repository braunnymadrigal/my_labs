namespace backend.Domain
{
    public class PurchaseRequestModel
    {
        public required List<DrinkModel> drinks { get; set; }
        public required List<MoneyModel> money { get; set; }
    }
}
