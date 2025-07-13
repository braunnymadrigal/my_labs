using backend.Application;
using backend.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace backend.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendingMachineController : ControllerBase
    {
        private readonly IVendingMachine _vendingMachine;

        public VendingMachineController(IVendingMachine vendingMachine)
        {
            _vendingMachine = vendingMachine;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult BuyDrinks(PurchaseRequestModel purchaseRequest)
        {
            var purchaseResponse = _vendingMachine.buyDrinks(purchaseRequest);
            return Ok(purchaseResponse);
        }
    }
}
