using Microsoft.AspNetCore.Mvc;
using SolidarityBlood.Application.DTOs.Addresses;
using SolidarityBlood.Application.Services.Implementations;
using SolidarityBlood.Application.Services.Interfaces;
using SolidarityBlood.Core.Entities;
using SolidarityBlood.Infrastructure.Persistence;

namespace SolidarityBlood.API.Controllers
{
    [ApiController]
    [Route("api/addresses")]
    public class AddressesController : ControllerBase
    {
        private readonly IAddressService _addressService;

        public AddressesController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpPost]
        public IActionResult Create(CreateAddressDTO address)
        {
            _addressService.Create(address);

            return CreatedAtAction(nameof(GetById), new { Id = address.Id }, address);
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var addresses = _addressService.GetAll();

            return Ok(addresses);

        }


        //  api/addresses/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var address = _addressService.GetById(id);

            return Ok(address);
        }


        //  api/addresses/2
        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateAddressDTO address)
        {
            _addressService.Update(id, address);

            return NoContent();
        }


        //  api/addresses/3
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _addressService.Delete(id);

            return NoContent();
        }
    }
}
