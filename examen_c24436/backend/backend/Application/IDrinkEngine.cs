using backend.Domain;

namespace backend.Application
{
    public interface IDrinkEngine
    {
        List<DrinkModel> getDrinks();
    }
}
