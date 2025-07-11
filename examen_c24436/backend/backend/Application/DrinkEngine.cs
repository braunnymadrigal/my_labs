using backend.Domain;
using backend.Infraestructure;

namespace backend.Application
{
    public class DrinkEngine : IDrinkEngine
    {
        private readonly IDrinkRepository _drinkRepository;

        public DrinkEngine(IDrinkRepository drinkRepository)
        {
            _drinkRepository = drinkRepository;
        }

        public List<ItemModel> getDrinks()
        {
            var drinks = _drinkRepository.getDrinks();
            return drinks;
        }
    }
}
