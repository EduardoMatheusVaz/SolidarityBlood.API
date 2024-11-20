using MediatR;
using Microsoft.AspNetCore.Mvc;
using SolidarityBlood.Application.Commands.Addresses;
using SolidarityBlood.Application.DTOs.Addresses;
using SolidarityBlood.Application.Queries.Address;
using SolidarityBlood.Core.Entities;
using SolidarityBlood.Infrastructure.Persistence;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace SolidarityBlood.API.Controllers
{
    [ApiController]
    [Route("api/addresses")]
    public class AddressesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AddressesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Create Address")]
        public async Task<IActionResult> Create(CreateAddressCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { Id = id }, command);
        }


        //  api/addresses/
        [HttpGet("Consult Addresses")]
        public async Task<IActionResult> GetAll()
        {
            var get = new GetAllAddressQuerie();

            var addresses = await _mediator.Send(get);

            return Ok(addresses);

        }

         
        //  api/addresses/1
        [HttpGet("{id}/Address")]
        public async Task<IActionResult> GetById(int id)
        {
            var get = new GetByIdAddressQuerie(id);
            
            var address = await _mediator.Send(get);

            return Ok(address);
        }


        //  api/addresses/2
        [HttpPut("{id}/Update")]
        public async Task<IActionResult> Update(int id, UpdateAddressCommand command)
        {
            await _mediator.Send(command);
            
            return NoContent();
        }


        //  api/addresses/3
        [HttpDelete("{id}/Delete")]
        public async Task<IActionResult> Delete(int id, string reasonExclusion)
        {
            var delete = new DeleteAddressCommand(id, reasonExclusion);

            await _mediator.Send(delete);

            return NoContent();
        }
    }
}
