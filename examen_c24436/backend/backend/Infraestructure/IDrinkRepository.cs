using backend.Domain;

namespace backend.Infraestructure
{
    public interface IDrinkRepository
    {
        List<DrinkModel> getDrinks();
    }
}
