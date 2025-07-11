using backend.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        [HttpGet]
        public IActionResult Get()
        {
            var items = _vendingMachine.getItems();
            return Ok(items);
        }
    }
}
