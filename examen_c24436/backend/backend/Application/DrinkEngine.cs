using backend.Domain;
using backend.Infraestructure;

namespace backend.Application
{
    public class DrinkEngine : IDrinkEngine
    {
        private IDrinkRepository _drinkRepository;

        public DrinkEngine(IDrinkRepository drinkRepository)
        {
            _drinkRepository = drinkRepository;
        }

        public List<DrinkModel> getDrinks()
        {
            var drinks = _drinkRepository.getDrinks();
            return drinks;
        }
    }
}
