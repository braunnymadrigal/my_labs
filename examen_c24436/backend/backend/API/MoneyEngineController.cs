using backend.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoneyEngineController : ControllerBase
    {
        IMoneyEngine _moneyEngine;

        public MoneyEngineController(IMoneyEngine moneyEngine)
        {
            _moneyEngine = moneyEngine;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetSupportedMoney()
        {
            var supportedMoney = _moneyEngine.getSupportedMoney();
            return Ok(supportedMoney);
        }
    }
}
