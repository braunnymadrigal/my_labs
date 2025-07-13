using AutoFixture;
using backend.Application;
using backend.Domain;
using Moq;

namespace Tests
{
    [TestFixture]
    public class VendingMachineTests
    {
        private Mock<IDrinkEngine> _drinkEngineMock;
        private Mock<IMoneyEngine> _moneyEngineMock;
        private Fixture _fixture;
        private VendingMachine _vendingMachine;

        [SetUp]
        public void SetUp()
        {
            _drinkEngineMock = new Mock<IDrinkEngine>();
            _moneyEngineMock = new Mock<IMoneyEngine>();
            _fixture = new Fixture();
            _vendingMachine = new VendingMachine(_drinkEngineMock.Object, _moneyEngineMock.Object);
        }

        [Test]
        public void BuyDrinks_ReturnsFailure_WhenExceptionThrown()
        {
            var request = _fixture.Create<PurchaseRequestModel>();
            _drinkEngineMock.Setup(x => x.getDrinks()).Throws<Exception>();
            var result = _vendingMachine.buyDrinks(request);
            Assert.That(result.success, Is.False);
        }

        [Test]
        public void BuyDrinks_ReturnsFailure_WhenInvalidDrinkSelected()
        {
            var drinks = _fixture.CreateMany<DrinkModel>(2).ToList();

            var request = new PurchaseRequestModel
            {
                drinks = drinks,
                money = new List<MoneyModel> 
                { 
                    new MoneyModel 
                    { 
                        type = 100, quantity = 1 
                    } 
                }
            };

            _drinkEngineMock.Setup(x => x.getDrinks()).Returns(drinks);
            _moneyEngineMock.Setup(x => x.getSupportedMoney()).Returns(new List<int>{});

            var result = _vendingMachine.buyDrinks(request);
            Assert.That(result.success, Is.False);
        }

        [Test]
        public void BuyDrinks_ReturnsFailure_WhenInsufficientMoney()
        {
            var drink = _fixture.Build<DrinkModel>()
                .With(d => d.name, "pepsi")
                .With(d => d.price, 100)
                .With(d => d.quantity, 10)
                .Create();

            var selectedDrink = _fixture.Build<DrinkModel>()
                .With(d => d.name, "pepsi")
                .With(d => d.price, 100)
                .With(d => d.quantity, 1)
                .Create();

            var selectedMoney = _fixture.Build<MoneyModel>()
                .With(m => m.type, 50)
                .With(m => m.quantity, 1)
                .Create();

            var request = _fixture.Build<PurchaseRequestModel>()
                .With(r => r.drinks, new List<DrinkModel> { selectedDrink })
                .With(r => r.money, new List<MoneyModel> { selectedMoney })
                .Create();

            _drinkEngineMock.Setup(x => x.getDrinks()).Returns(new List<DrinkModel> { drink });
            _moneyEngineMock.Setup(x => x.getSupportedMoney()).Returns(new List<int> { 50 });
            _moneyEngineMock.Setup(x => x.getMoney()).Returns(new List<MoneyModel>());

            var result = _vendingMachine.buyDrinks(request);
            Assert.That(result.success, Is.False);
        }

        [Test]
        public void BuyDrinks_ReturnsFailure_WhenUnsupportedMoney()
        {
            var drink = _fixture.Build<DrinkModel>()
                .With(d => d.name, "pepsi")
                .With(d => d.price, 100)
                .With(d => d.quantity, 10)
                .Create();

            var selectedDrink = _fixture.Build<DrinkModel>()
                .With(d => d.name, "pepsi")
                .With(d => d.price, 100)
                .With(d => d.quantity, 1)
                .Create();

            var unsupportedMoney = _fixture.Build<MoneyModel>()
                .With(m => m.quantity, 1)
                .Create();

            var request = _fixture.Build<PurchaseRequestModel>()
                .With(r => r.drinks, new List<DrinkModel> { selectedDrink })
                .With(r => r.money, new List<MoneyModel> { unsupportedMoney })
                .Create();

            _drinkEngineMock.Setup(x => x.getDrinks()).Returns(new List<DrinkModel> { drink });
            _moneyEngineMock.Setup(x => x.getSupportedMoney()).Returns(new List<int> { 100 });

            var result = _vendingMachine.buyDrinks(request);

            Assert.That(result.success, Is.False);
        }


        [Test]
        public void BuyDrinks_ReturnsFailure_WhenChangeCannotBeGiven()
        {
            var drink = _fixture.Build<DrinkModel>()
                .With(d => d.name, "pepsi")
                .With(d => d.price, 75)
                .With(d => d.quantity, 10)
                .Create();

            var selectedDrink = _fixture.Build<DrinkModel>()
                .With(d => d.name, "pepsi")
                .With(d => d.price, 75)
                .With(d => d.quantity, 1)
                .Create();

            var selectedMoney = _fixture.Build<MoneyModel>()
                .With(m => m.type, 100)
                .With(m => m.quantity, 1)
                .Create();

            var request = _fixture.Build<PurchaseRequestModel>()
                .With(r => r.drinks, new List<DrinkModel> { selectedDrink })
                .With(r => r.money, new List<MoneyModel> { selectedMoney })
                .Create();

            var machineMoney = _fixture.Build<MoneyModel>()
                .With(m => m.type, 25)
                .With(m => m.quantity, 0)
                .Create();

            _drinkEngineMock.Setup(x => x.getDrinks()).Returns(new List<DrinkModel> { drink });
            _moneyEngineMock.Setup(x => x.getSupportedMoney()).Returns(new List<int> { 100 });
            _moneyEngineMock.Setup(x => x.getMoney()).Returns(new List<MoneyModel> { machineMoney });

            var result = _vendingMachine.buyDrinks(request);

            Assert.That(result.success, Is.False);
        }

        [Test]
        public void BuyDrinks_ReturnsChange_WhenNoExactPayment()
        {
            var drink = _fixture.Build<DrinkModel>()
                .With(d => d.name, "pepsi")
                .With(d => d.price, 75)
                .With(d => d.quantity, 10)
                .Create();

            var selectedDrink = _fixture.Build<DrinkModel>()
                .With(d => d.name, "pepsi")
                .With(d => d.price, 75)
                .With(d => d.quantity, 1)
                .Create();

            var selectedMoney = _fixture.Build<MoneyModel>()
                .With(m => m.type, 100)
                .With(m => m.quantity, 1)
                .Create();

            var request = _fixture.Build<PurchaseRequestModel>()
                .With(r => r.drinks, new List<DrinkModel> { selectedDrink })
                .With(r => r.money, new List<MoneyModel> { selectedMoney })
                .Create();

            var availableMoney = _fixture.Build<MoneyModel>()
                .With(m => m.type, 25)
                .With(m => m.quantity, 1)
                .Create();

            _drinkEngineMock.Setup(x => x.getDrinks()).Returns(new List<DrinkModel> { drink });
            _moneyEngineMock.Setup(x => x.getSupportedMoney()).Returns(new List<int> { 100, 25 });
            _moneyEngineMock.Setup(x => x.getMoney()).Returns(new List<MoneyModel> { availableMoney });

            var expectedChange = 25;
            var expectedDetailedChangeSize = 1;

            var result = _vendingMachine.buyDrinks(request);

            Assert.That(result.success, Is.True);
            Assert.That(expectedChange, Is.EqualTo(result.totalChange));
            Assert.That(result.detailedChange.Count, Is.EqualTo(expectedDetailedChangeSize));

            _moneyEngineMock.Verify(x => x.updateMoney(It.IsAny<List<MoneyModel>>()), Times.Exactly(2));
            _drinkEngineMock.Verify(x => x.updateDrinks(It.IsAny<List<DrinkModel>>()), Times.Once);
        }

        [Test]
        public void BuyDrinks_ReturnsNoChange_WhenExactPayment()
        {
            var drink = _fixture.Build<DrinkModel>()
                .With(d => d.name, "pepsi")
                .With(d => d.price, 100)
                .With(d => d.quantity, 5)
                .Create();

            var selectedDrink = _fixture.Build<DrinkModel>()
                .With(d => d.name, "pepsi")
                .With(d => d.price, 100)
                .With(d => d.quantity, 1)
                .Create();

            var selectedMoney = _fixture.Build<MoneyModel>()
                .With(m => m.type, 100)
                .With(m => m.quantity, 1)
                .Create();

            var request = _fixture.Build<PurchaseRequestModel>()
                .With(r => r.drinks, new List<DrinkModel> { selectedDrink })
                .With(r => r.money, new List<MoneyModel> { selectedMoney })
                .Create();

            _drinkEngineMock.Setup(x => x.getDrinks()).Returns(new List<DrinkModel> { drink });
            _moneyEngineMock.Setup(x => x.getSupportedMoney()).Returns(new List<int> { 100 });
            _moneyEngineMock.Setup(x => x.getMoney()).Returns(new List<MoneyModel>());

            var expectedChange = 0;

            var result = _vendingMachine.buyDrinks(request);

            Assert.That(result.success, Is.True);
            Assert.That(expectedChange, Is.EqualTo(result.totalChange));
            Assert.That(result.detailedChange, Is.Empty);

            _moneyEngineMock.Verify(x => x.updateMoney(It.IsAny<List<MoneyModel>>()), Times.Once);
            _drinkEngineMock.Verify(x => x.updateDrinks(It.IsAny<List<DrinkModel>>()), Times.Once);
        }
    }
}
