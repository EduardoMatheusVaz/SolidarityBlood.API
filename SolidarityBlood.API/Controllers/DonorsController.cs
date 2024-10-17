﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using SolidarityBlood.Application.Commands.Donors;
using SolidarityBlood.Application.DTOs.Donors;
using SolidarityBlood.Application.Queries.Donor;
using SolidarityBlood.Core.Entities;
using SolidarityBlood.Infrastructure.Persistence;
using System.Net;

namespace SolidarityBlood.API.Controllers
{
    [ApiController]
    [Route("api/donors")]
    public class DonorsController : ControllerBase
    {   
        private readonly IMediator _mediator;

        public DonorsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateDonorCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { Id = id }, command);
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var get = new GetAllDonorsQuerie();

            var donors = await  _mediator.Send(get);

            return Ok(donors);
        }


        //  api/donors/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var get = new GetByIdDonorQuerie(id);

            var donor = await _mediator.Send(get);

            return Ok(donor);

        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateDonorCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return NoContent();
        }
    }
}
 