using backend.Domain;

namespace backend.Infraestructure
{
    public interface IMoneyEngineRepository
    {
        List<int> getSupportedMoney();
        List<MoneyModel> getMoney();
        void updateMoney(List<MoneyModel> money);
    }
}
