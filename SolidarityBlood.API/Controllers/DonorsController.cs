using Microsoft.AspNetCore.Mvc;
using SolidarityBlood.Application.DTOs.Donors;
using SolidarityBlood.Application.Services.Interfaces;
using SolidarityBlood.Core.Entities;
using SolidarityBlood.Infrastructure.Persistence;

namespace SolidarityBlood.API.Controllers
{
    [ApiController]
    [Route("api/donors")]
    public class DonorsController : ControllerBase
    {   

        private readonly IDonorService _donorService;

        public DonorsController(IDonorService service)
        {
            _donorService = service;
        }

        [HttpPost]
        public IActionResult Create(CreateDonorDTO donor)
        {
            _donorService.Create(donor);

            return CreatedAtAction(nameof(GetById), new { id = donor.Id }, donor);
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var donors = _donorService.GetAllDonors();

            return Ok(donors);
        }


        //  api/donors/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var donor = _donorService.GetById(id);

            return Ok(donor);

        }


        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateDonorDTO donor)
        {
            _donorService.Update(id, donor);

            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _donorService.Delete(id);

            return NoContent();
        }
    }
}
 