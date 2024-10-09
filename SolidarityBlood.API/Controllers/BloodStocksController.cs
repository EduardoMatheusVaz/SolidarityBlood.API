  using Microsoft.AspNetCore.Mvc;
using SolidarityBlood.Application.DTOs.BloodStocks;
using SolidarityBlood.Application.Services.Interfaces;
using SolidarityBlood.Core.Entities;
using SolidarityBlood.Infrastructure.Persistence;

namespace SolidarityBlood.API.Controllers
{
    [ApiController]
    [Route("api/bloodstocks")]
    public class BloodStocksController : Controller
    {
        private readonly IBloodStockService _bloodStockService;

        public BloodStocksController(IBloodStockService bloodStockService)
        {
            _bloodStockService = bloodStockService;
        }

        [HttpPost]
        public IActionResult Create(CreateBloodStockDTO bloodStock)
        {
            _bloodStockService.Create(bloodStock);

            return CreatedAtAction(nameof(GetById), new { Id = bloodStock.Id }, bloodStock);
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var stocks = _bloodStockService.GetAll();

            return Ok(stocks);
        }


        //  api/addresses/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var stock = _bloodStockService.GetById(id);

            return Ok(stock);
        }


        //  api/addresses/2
        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateBloodStockDTO bloodStock)
        {
            _bloodStockService.Update(id, bloodStock);

            return NoContent();
        }


        //  api/addresses/3
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _bloodStockService.Delete(id);

            return NoContent();
        }
    }
}
