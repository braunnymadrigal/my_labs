using backend.Domain;

namespace backend.Infraestructure
{
    public class MoneyEngineRepository : IMoneyEngineRepository
    {
        public List<int> getSupportedMoney()
        {
            var supportedMoney = new List<int>();
            foreach (var entry in Database.Database.supportedMoney)
            {
                supportedMoney.Add(entry);
            }
            return supportedMoney;
        }
    }
}
