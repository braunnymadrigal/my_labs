using backend.Domain;

namespace backend.Application
{
    public class VendingMachine : IVendingMachine
    {
        private readonly IDrinkEngine _drinkEngine;

        public VendingMachine(IDrinkEngine drinkEngine)
        {
            _drinkEngine = drinkEngine;
        }

        public List<ItemModel> getItems()
        {
            var items = new List<ItemModel>();
            items.AddRange(_drinkEngine.getDrinks());
            return items;
        }
    }
}
