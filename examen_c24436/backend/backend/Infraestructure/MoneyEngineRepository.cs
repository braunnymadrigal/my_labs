using backend.Domain;
using System.Reflection;

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

        public List<MoneyModel> getMoney()
        {
            var money = new List<MoneyModel>();
            foreach (var entry in Database.Database.money)
            {
                var singleMoney = new MoneyModel
                {
                    type = entry.Key,
                    quantity = entry.Value,
                };
                money.Add(singleMoney);
            }
            return money;
        }

        public void updateMoney(List<MoneyModel> money)
        {
            foreach (var singleMoney in money)
            {
                Database.Database.money[singleMoney.type] = singleMoney.quantity;
            }
        }
    }
}
