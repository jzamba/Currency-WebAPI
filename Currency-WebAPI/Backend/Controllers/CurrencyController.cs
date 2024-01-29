using Homework03_project.Logic;
using Microsoft.AspNetCore.Mvc;
using Homework03_project.Logic;
using Homework03_project.Repository;
using Homework03_project.Filters;
using Homework03_project.Configuration;
using Homework03_project.Domain;
using Homework03_project.Controllers.DTO;



namespace  Homework03_project.Controllers
{

    [LogFilter]
    [ApiController]
    [Route("api/[controller]")]
    public class CurrencyController : ControllerBase
    {
        private readonly ICurrencyLogic _currencyLogic;

        public CurrencyController(ICurrencyLogic currencyLogic)
        {
            this._currencyLogic = currencyLogic;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CurrencyInfoDTO>> Get()
        {
            var allCurrencys = _currencyLogic.GetCurrencies().Select(x => CurrencyInfoDTO.FromModel(x));
            return Ok(allCurrencys);
        }

        [HttpGet("{id}")]
        public ActionResult<CurrencyInfoDTO> Get(int id)
        {
            var currency = _currencyLogic.GetCurrency(id);
            if (currency == null)
            {
                return NotFound($"Currency with ID {id} not found.");
            }

            return Ok(CurrencyInfoDTO.FromModel(currency));
        }

        [HttpPost]
        public ActionResult Post([FromBody] NewCurrencyDTO currency)
        {
            if (currency == null)
            {
                return BadRequest($"Wrong currency format!");
            }

            _currencyLogic.CreateNewCurrency(currency.ToModel());

            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] NewCurrencyDTO updatedCurrency)
        {
            if (updatedCurrency == null)
            {
                return BadRequest($"Wrong currency format!");
            }

            var existingCurrency = _currencyLogic.GetCurrency(id);
            if (existingCurrency == null)
            {
                return NotFound($"Currency with ID {id} not found.");
            }

            _currencyLogic.UpdateCurrency(id, updatedCurrency.ToModel());

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var currency = _currencyLogic.GetCurrency(id);
            if (currency == null)
            {
                return NotFound($"Currency with ID {id} not found.");
            }

            _currencyLogic.DeleteCurrency(id);

            return Ok();
        }
    }
}