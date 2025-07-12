using backend.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrinkEngineController : ControllerBase
    {
        IDrinkEngine _drinkEngine;

        public DrinkEngineController(IDrinkEngine drinkEngine)
        {
            _drinkEngine = drinkEngine;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetDrinks()
        {
            var items = _drinkEngine.getDrinks();
            return Ok(items);
        }
    }
}
