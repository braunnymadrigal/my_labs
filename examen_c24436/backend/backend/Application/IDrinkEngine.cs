using backend.Domain;

namespace backend.Application
{
    public interface IDrinkEngine
    {
        List<ItemModel> getDrinks();
    }
}
