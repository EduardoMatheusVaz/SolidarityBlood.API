﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using SolidarityBlood.Application.Commands.Donations;
using SolidarityBlood.Application.DTOs.Donations;
using SolidarityBlood.Application.Queries.Donation;
using SolidarityBlood.Core.Entities;
using SolidarityBlood.Infrastructure.Persistence;

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

        [HttpPost]
        public async Task<IActionResult> Create(CreateDonationCommand command)
        {
            var id = await _mediator.Send(command);
            
            return CreatedAtAction(nameof(GetById), new { Id = id}, id);
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var get = new GetAllDonationsQuerie();

            var donations = await _mediator.Send(get);

            return Ok(donations);
        }


        //  api/donations/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var get = new GetByIdDonationQuerie(id);

            var donation = await _mediator.Send(get);

            return Ok(donation);
        }


        //  api/donations/2
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateDonationCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }


        //  api/donations/3
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return NoContent();
        }
    }
}
