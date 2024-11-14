using SolidarityBlood.Infrastructure.Integration.Interfaces;
using SolidarityBlood.Infrastructure.Integration.Refit;
using SolidarityBlood.Infrastructure.Integration.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidarityBlood.Infrastructure.Integration
{
    public class ViaCepIntegration : IViaCepIntegration
    {
        private readonly IViaCepIntegrationRefit _viaCepIntegrationRefit;
        public ViaCepIntegration(IViaCepIntegrationRefit viaCepIntegrationRefit)
        {
            _viaCepIntegrationRefit = viaCepIntegrationRefit;
        }
        public async Task<ViaCepResponse> GetDataViaCep(string cep)
        {
            var responseData = await _viaCepIntegrationRefit.GetDataViaCep(cep);

            if (responseData != null && responseData.IsSuccessStatusCode)
            {
                return responseData.Content;
            }

            return null;  
        }
    }
}
