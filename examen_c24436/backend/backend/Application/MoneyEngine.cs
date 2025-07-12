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
    }
}
