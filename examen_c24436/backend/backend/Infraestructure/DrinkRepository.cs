using backend.Domain;

namespace backend.Infraestructure
{
    public class DrinkRepository : IDrinkRepository
    {
        public List<DrinkModel> getDrinks()
        {
            var drinks = new List<DrinkModel>();
            foreach (var entry in Database.Database.drinks)
            {
                var drink = new DrinkModel
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
