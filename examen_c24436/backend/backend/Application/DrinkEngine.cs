using backend.Domain;
using backend.Infraestructure;

namespace backend.Application
{
    public class DrinkEngine : IDrinkEngine
    {
        private readonly IDrinkEngineRepository _drinkRepository;

        public DrinkEngine(IDrinkEngineRepository drinkRepository)
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
