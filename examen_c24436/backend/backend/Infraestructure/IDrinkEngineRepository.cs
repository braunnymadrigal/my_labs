using backend.Domain;

namespace backend.Infraestructure
{
    public interface IDrinkEngineRepository
    {
        List<DrinkModel> getDrinks();
        void updateDrinks(List<DrinkModel> drinks);
    }
}
