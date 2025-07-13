using backend.Domain;

namespace backend.Infraestructure
{
    public class DrinkEngineRepository : IDrinkEngineRepository
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
                drinks.Add(drink);
            }
            return drinks;
        }

        public void updateDrinks(List<DrinkModel> drinks)
        {
            foreach (var drink in drinks)
            {
                Database.Database.drinks[drink.name] = (drink.quantity, drink.price);
            }
        }
    }
}
