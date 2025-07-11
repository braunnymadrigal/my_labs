using backend.Domain;
using System.Diagnostics;

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
            try
            {
                items.AddRange(_drinkEngine.getDrinks());
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
            return items;
        }
    }
}
