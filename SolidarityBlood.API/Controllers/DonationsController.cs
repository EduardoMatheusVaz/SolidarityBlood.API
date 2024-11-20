using MediatR;
using Microsoft.AspNetCore.Mvc;
using SolidarityBlood.Application.Commands.Donations;
using SolidarityBlood.Application.DTOs.Donations;
using SolidarityBlood.Application.Queries.Donation;
using SolidarityBlood.Core.Entities;
using SolidarityBlood.Infrastructure.Persistence;
using System.Reflection.Metadata;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SolidarityBlood.API.Controllers
{
    [ApiController]
    [Route("api/donations")]
    public class DonationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DonationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("/Create Donation")]
        public async Task<IActionResult> Create(CreateDonationCommand command)
        {
            try
            {
                int result = await _mediator.Send(command);
                return Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { error = ex.Message });
            }

            //var id = await _mediator.Send(command);
            //return CreatedAtAction(nameof(GetById), new { Id = id}, id);
        }


        [HttpGet("/Consult Donations")]
        public async Task<IActionResult> GetAll()
        {
            var get = new GetAllDonationsQuerie();

            var donations = await _mediator.Send(get);

            return Ok(donations);
        }


        //  api/donations/1
        [HttpGet("{id}/Donation")]
        public async Task<IActionResult> GetById(int id)
        {
            var get = new GetByIdDonationQuerie(id);

            var donation = await _mediator.Send(get);

            return Ok(donation);
        }


        //  api/donations/2
        [HttpPut("{id}/Update")]
        public async Task<IActionResult> Update(int id, UpdateDonationCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }


        //  api/donations/3
        [HttpDelete("{id}/Delete")]
        public async Task<IActionResult> Delete(int id, string reasonCanceled)
        {
            var delete = new DeleteDonationCommand(id, reasonCanceled);

            await _mediator.Send(delete);

            return NoContent();
        }
    }
}
