using MediatR;
using Microsoft.AspNetCore.Mvc;
using SolidarityBlood.Application.Commands.BloodStocks;
using SolidarityBlood.Application.DTOs.BloodStocks;
using SolidarityBlood.Application.Queries.BloodStock;
using SolidarityBlood.Core.Entities;
using SolidarityBlood.Infrastructure.Persistence;

namespace SolidarityBlood.API.Controllers
{
    [ApiController]
    [Route("api/bloodstocks")]
    public class BloodStocksController : Controller
    {
        private readonly IMediator _mediator;

        public BloodStocksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBloodStockCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { Id = id }, id);
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var stocks = new GetAllBloodStocksQuerie();

            await _mediator.Send(stocks);

            return Ok(stocks);
        }


        //  api/addresses/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var stock = new GetByIdBloodStockQuerie(id);

            await _mediator.Send(stock);

            return Ok(stock);
        }


        //  api/addresses/2
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateBloodStockDTO bloodStock)
        {
            await _mediator.Send(bloodStock);

            return NoContent();
        }


        //  api/addresses/3
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return NoContent();
        }
    }
}
