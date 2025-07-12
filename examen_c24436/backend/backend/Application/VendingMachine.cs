using backend.Domain;
using System.Diagnostics;

namespace backend.Application
{
    public class VendingMachine : IVendingMachine
    {
        private readonly IDrinkEngine _drinkEngine;

        public VendingMachine(IDrinkEngine drinkEngine)
        {
            _drinkEngine = drinkEngine;
        }
    }
}
