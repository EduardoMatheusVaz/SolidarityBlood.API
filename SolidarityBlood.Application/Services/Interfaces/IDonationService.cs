using SolidarityBlood.Application.DTOs.Donations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidarityBlood.Application.Services.Interfaces
{
    public interface IDonationService
    {
        int Create(CreateDonationDTO donation);
        List<GetAllDonationDTO> GetAllDonations();
        GetByIdDonationDTO GetById(int id);
        void Update(int id, UpdateDonationDTO donation);
        void Delete(int id);

    }
}
