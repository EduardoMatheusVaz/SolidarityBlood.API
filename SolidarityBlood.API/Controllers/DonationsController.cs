using Microsoft.AspNetCore.Mvc;
using SolidarityBlood.Application.DTOs.Donations;
using SolidarityBlood.Application.Services.Interfaces;
using SolidarityBlood.Core.Entities;
using SolidarityBlood.Infrastructure.Persistence;

namespace SolidarityBlood.API.Controllers
{
    [ApiController]
    [Route("api/donations")]
    public class DonationsController : ControllerBase
    {
        private readonly IDonationService _donationService;

        public DonationsController(IDonationService donationService)
        {
            _donationService = donationService;
        }

        [HttpPost]
        public IActionResult Create(CreateDonationDTO donation)
        {
            _donationService.Create(donation);

            return CreatedAtAction(nameof(GetById), new { Id = donation.Id }, donation);
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var donations = _donationService.GetAllDonations();

            return Ok(donations);
        }


        //  api/donations/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var donation = _donationService.GetById(id);

            return Ok(donation);
        }


        //  api/donations/2
        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateDonationDTO donation)
        {
            _donationService.Update(id, donation);

            return NoContent();
        }


        //  api/donations/3
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _donationService.Delete(id);

            return NoContent();
        }
    }
}
