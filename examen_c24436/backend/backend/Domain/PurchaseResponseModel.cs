namespace backend.Domain
{
    public class PurchaseResponseModel
    {
        public required bool success { get; set; }
        public required int totalChange { get; set; }
        public required List<MoneyModel> detailedChange { get; set; }
    }
}
