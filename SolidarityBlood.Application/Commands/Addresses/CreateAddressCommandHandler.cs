using MediatR;
using SolidarityBlood.Core.Entities;
using SolidarityBlood.Core.Repositories;
using SolidarityBlood.Infrastructure.Integration.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidarityBlood.Application.Commands.Addresses
{
    public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommand, int>
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IViaCepIntegration _viaCepIntegration;

        public CreateAddressCommandHandler(IAddressRepository addressRepository, IViaCepIntegration viaCepIntegration)
        {
            _addressRepository = addressRepository;
            _viaCepIntegration = viaCepIntegration;
        }

        public async Task<int> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
        {
            
            var responseViaCep = await _viaCepIntegration.GetDataViaCep(request.ZipCode);
            var address = new Address(responseViaCep.Logradouro, responseViaCep.Complemento, responseViaCep.Bairro, responseViaCep.Localidade, responseViaCep.Uf, responseViaCep.Cep);

            await _addressRepository.CreateAddress(address);

            return address.Id;
        }
    }
}
