using backend.Domain;

namespace backend.Infraestructure
{
    public class DrinkRepository : IDrinkRepository
    {
        public List<ItemModel> getDrinks()
        {
            var drinks = new List<ItemModel>();
            foreach (var entry in Database.Database.drinks)
            {
                var drink = new ItemModel
                {
                    name = entry.Key,
                    quantity = entry.Value.Item1,
                    price = entry.Value.Item2,
                };
            }
            return drinks;
        }
    }
}
