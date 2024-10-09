using SolidarityBlood.Application.DTOs.Donors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidarityBlood.Application.Services.Interfaces
{
    public interface IDonorService
    {
        int Create(CreateDonorDTO donor);
        List<GetAllDonorsDTO> GetAllDonors();
        GetByIdDonorDTO GetById(int id);
        void Update(int id, UpdateDonorDTO donor);
        void Delete(int id);
    }
}
