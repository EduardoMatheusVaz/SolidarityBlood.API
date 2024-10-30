using MediatR;
using SolidarityBlood.Application.DTOs.Addresses;
using SolidarityBlood.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace SolidarityBlood.Application.Queries.Address
{
    public class GetByIdAddressQuerieHandler : IRequestHandler<GetByIdAddressQuerie, GetByIdAddressDTO>
    {
        private readonly IAddressRepository _addressRepository;

        public GetByIdAddressQuerieHandler(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task<GetByIdAddressDTO> Handle(GetByIdAddressQuerie request, CancellationToken cancellationToken)
        {
            var get = await _addressRepository.GetByIdAddress(request.Id);

            var address = new GetByIdAddressDTO(get.Id, get.PublicPlace, get.City, get.State, get.ZipCode, get.Status, get.ReasonExclusion);

            return address;
        }
    }
}
