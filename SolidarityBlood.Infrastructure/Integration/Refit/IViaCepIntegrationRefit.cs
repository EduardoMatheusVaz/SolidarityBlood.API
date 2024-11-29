using Refit;
using SolidarityBlood.Infrastructure.Integration.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidarityBlood.Infrastructure.Integration.Refit
{
    public interface IViaCepIntegrationRefit
    {
        [Get("/ws/{cep}/json")] //essa é a rota, acessamos a api informando o CEP, ele vai fazer um get dentro do ws passando o cep/json
        Task<ApiResponse<ViaCepResponse>> GetDataViaCep(string cep);
    }
}