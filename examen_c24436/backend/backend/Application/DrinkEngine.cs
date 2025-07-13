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
            var drinks = _drinkRepository.getDrinks().Where(drink => drink.quantity > 0).ToList(); ;
            return drinks;
        }

        public void updateDrinks(List<DrinkModel> drinks)
        {
            _drinkRepository.updateDrinks(drinks);
        }
    }
}
