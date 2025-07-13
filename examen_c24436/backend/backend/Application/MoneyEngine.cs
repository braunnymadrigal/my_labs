using backend.Domain;
using backend.Infraestructure;

namespace backend.Application
{
    public class MoneyEngine : IMoneyEngine
    {
        private readonly IMoneyEngineRepository _moneyEngineRepository;

        public MoneyEngine(IMoneyEngineRepository moneyEngineRepository)
        {
            _moneyEngineRepository = moneyEngineRepository;
        }

        public List<int> getSupportedMoney()
        {
            var supportedMoney = _moneyEngineRepository.getSupportedMoney();
            return supportedMoney;
        }

        public List<MoneyModel> getMoney()
        {
            var money = _moneyEngineRepository.getMoney().Where(singleMoney => singleMoney.quantity > 0).ToList();
            return money;
        }

        public void updateMoney(List<MoneyModel> money)
        {
            _moneyEngineRepository.updateMoney(money);
        }
    }
}
