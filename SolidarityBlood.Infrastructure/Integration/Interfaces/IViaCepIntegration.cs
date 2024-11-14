using SolidarityBlood.Infrastructure.Integration.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidarityBlood.Infrastructure.Integration.Interfaces
{
    public interface IViaCepIntegration
    {

        Task<ViaCepResponse> GetDataViaCep(string cep);

    }
}
