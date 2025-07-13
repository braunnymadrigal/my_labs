using backend.Domain;
using System.Text.Json;

namespace backend.Application
{
    public class VendingMachine : IVendingMachine
    {
        private const int INTEGER_DEFAULT_VALUE = 0;

        private readonly IDrinkEngine _drinkEngine;
        private readonly IMoneyEngine _moneyEngine;

        public VendingMachine(IDrinkEngine drinkEngine, IMoneyEngine moneyEngine)
        {
            _drinkEngine = drinkEngine;
            _moneyEngine = moneyEngine;
        }

        public PurchaseResponseModel buyDrinks(PurchaseRequestModel purchaseRequest)
        {
            var purchaseResponse = new PurchaseResponseModel
            {
                success = false,
                totalChange = 0,
                detailedChange = new List<MoneyModel>()
            };
            try
            {
                purchaseResponse = startPurchase(purchaseRequest, purchaseResponse);
            }
            catch
            {
            }
            return purchaseResponse;
        }

        private PurchaseResponseModel startPurchase(PurchaseRequestModel purchaseRequest, PurchaseResponseModel purchaseResponse)
        {
            var selectedDrinks = purchaseRequest.drinks;
            var drinks = _drinkEngine.getDrinks();
            checkSelectedDrinksCorrectness(selectedDrinks, drinks);
            var selectedMoney = purchaseRequest.money;
            checkSelectedMoneyCorrectness(selectedMoney);

            var costs = selectedDrinks.Sum(drink => drink.quantity * drink.price);
            var pay = selectedMoney.Sum(singleMoney => singleMoney.type * singleMoney.quantity);
            checkCostsAreGreaterThanZero(costs);
            checkPayMeetsCosts(costs, pay);

            var money = _moneyEngine.getMoney();
            if (costs != pay)
            {
                var neededChange = pay - costs;
                purchaseResponse.detailedChange = calculateChange(neededChange, selectedMoney, money);
                purchaseResponse.totalChange = neededChange;
                substractMoney(purchaseResponse.detailedChange, money);
            }
            addMoney(selectedMoney, money);
            substractDrinks(selectedDrinks, drinks);
            purchaseResponse.success = true;
            return purchaseResponse;
        }

        private List<MoneyModel> calculateChange(int neededChange, List<MoneyModel> selectedMoney, List<MoneyModel> money)
        {
            var detailedChange = new List<MoneyModel>();
            money = money.OrderByDescending(singleMoney => singleMoney.type).ToList();
            foreach (var coin in money)
            {
                var quantityOfCoinsToUse = Math.Min(coin.quantity, neededChange / coin.type);
                if (quantityOfCoinsToUse > 0)
                {
                    detailedChange.Add(new MoneyModel { type = coin.type, quantity = quantityOfCoinsToUse });
                    neededChange -= quantityOfCoinsToUse * coin.type;
                }
            }
            if (neededChange !=  0)
            {
                throw new Exception();
            }
            return detailedChange;
        }

        private void addMoney(List<MoneyModel> selectedMoney, List<MoneyModel> money)
        {
            var updatedMoney = new List<MoneyModel>();
            foreach(var singleSelectedMoney in selectedMoney)
            {
                var singleMoney = money.Find(m => m.type == singleSelectedMoney.type);
                if (singleMoney != null)
                {
                    updatedMoney.Add(new MoneyModel
                    {
                        type = singleSelectedMoney.type,
                        quantity = singleMoney.quantity + singleSelectedMoney.quantity,
                    });
                }
            }
            _moneyEngine.updateMoney(updatedMoney);
        }

        private void substractMoney(List<MoneyModel> selectedMoney, List<MoneyModel> money)
        {
            var updatedMoney = new List<MoneyModel>();
            foreach (var singleSelectedMoney in selectedMoney)
            {
                var singleMoney = money.Find(m => m.type == singleSelectedMoney.type);
                if (singleMoney != null)
                {
                    updatedMoney.Add(new MoneyModel
                    {
                        type = singleSelectedMoney.type,
                        quantity = singleMoney.quantity - singleSelectedMoney.quantity,
                    });
                }
            }
            _moneyEngine.updateMoney(updatedMoney);
        }

        private void substractDrinks(List<DrinkModel> selectedDrinks, List<DrinkModel> availableDrinks)
        {
            var updatedDrinks =  new List<DrinkModel>();
            foreach (var selectedDrink in selectedDrinks)
            {
                var availableDrink = availableDrinks.Find(drink => drink.name == selectedDrink.name);
                if (availableDrink != null)
                {
                    updatedDrinks.Add(new DrinkModel
                    {
                        name = selectedDrink.name,
                        price = selectedDrink.price,
                        quantity = availableDrink.quantity - selectedDrink.quantity,
                    });
                }
            }
            _drinkEngine.updateDrinks(updatedDrinks);
        }

        private void checkCostsAreGreaterThanZero(int costs)
        {
            if (costs <= INTEGER_DEFAULT_VALUE)
            {
                throw new Exception();
            }
        }

        private void checkPayMeetsCosts(int costs, int pay)
        {
            if (costs > pay)
            {
                throw new Exception();
            }
        }

        private void checkSelectedDrinksCorrectness(List<DrinkModel> selectedDrinks, List<DrinkModel> availableDrinks)
        {
            foreach (var selectedDrink in selectedDrinks)
            {
                var availableDrink = availableDrinks.Find(drink => drink.name == selectedDrink.name);
                if (availableDrink == null)
                {
                    throw new Exception();
                }
                if (availableDrink.quantity < selectedDrink.quantity || availableDrink.price != selectedDrink.price)
                {
                    throw new Exception();
                }
            }
        }

        private void checkSelectedMoneyCorrectness(List<MoneyModel> selectedMoney)
        {
            var supportedMoney = _moneyEngine.getSupportedMoney();
            foreach (var singleSelectedMoney in selectedMoney)
            {
                var singleSupportedMoney = supportedMoney.Find(singleMoney => singleMoney == singleSelectedMoney.type);
                if (singleSupportedMoney == INTEGER_DEFAULT_VALUE)
                {
                    throw new Exception();
                }
            }
        }
    }
}
