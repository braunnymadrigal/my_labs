using backend.Domain;

namespace backend.Application
{
    public interface IMoneyEngine
    {
        List<int> getSupportedMoney();
        List<MoneyModel> getMoney();
        void updateMoney(List<MoneyModel> money);
    }
}
