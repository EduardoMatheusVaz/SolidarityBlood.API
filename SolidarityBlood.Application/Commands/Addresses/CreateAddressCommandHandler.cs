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

        public CreateAddressCommandHandler(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task<int> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
        {
            //var responseViaCep = await _viaCepIntegration.GetDataViaCep(request.ZipCode);
            var responseViaCep = await _addressRepository.AddresQuery(request.ZipCode);

            var address = new Address(responseViaCep.PublicPlace, responseViaCep.Complement, responseViaCep.Neighborhood, responseViaCep.City, responseViaCep.State, responseViaCep.ZipCode);

            await _addressRepository.CreateAddress(address);

            return address.Id;
        }
    }
}
