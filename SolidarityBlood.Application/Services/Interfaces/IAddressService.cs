using SolidarityBlood.Application.DTOs.Addresses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidarityBlood.Application.Services.Interfaces
{
    public interface IAddressService
    {
        int Create(CreateAddressDTO address);
        List<GetAllAddressDTO> GetAll();
        GetByIdAddressDTO GetById(int id);
        void Update(int id, UpdateAddressDTO address);
        void Delete(int id);
    }
}
