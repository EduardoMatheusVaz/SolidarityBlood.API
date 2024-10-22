using MediatR;
using SolidarityBlood.Application.DTOs.Addresses;
using SolidarityBlood.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidarityBlood.Application.Queries.Address
{
    public class GetAllAddressQuerieHandler : IRequestHandler<GetAllAddressQuerie, List<GetAllAddressDTO>>
    {
        private readonly IAddressRepository _addressRepository;

        public GetAllAddressQuerieHandler(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task<List<GetAllAddressDTO>> Handle(GetAllAddressQuerie request, CancellationToken cancellationToken)
        {
            var addresses = await _addressRepository.GetAllAddress();

            var list = addresses.Select(l => new GetAllAddressDTO(
                l.Id,
                l.PublicPlace,
                l.City,
                l.State,
                l.ZipCode,
                l.Status
                )).ToList();

            return list;
        }
    }
}
