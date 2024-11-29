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
    public class GetDeleteAddressQuerieHandler : IRequestHandler<GetDeleteAddressQuerie, List<GetAllAddressDTO>>
    {
        private readonly IAddressRepository _addressRepository;

        public GetDeleteAddressQuerieHandler(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task<List<GetAllAddressDTO>> Handle(GetDeleteAddressQuerie request, CancellationToken cancellationToken)
        {
            var addresses = await _addressRepository.GetDeletedAddress();

            var list = addresses.Select(l => new GetAllAddressDTO(
                l.Id,
                l.PublicPlace,
                l.City,
                l.State,
                l.ZipCode,
                l.Status,
                l.ReasonExclusion
                )).Where(a => a.Status != Core.Enums.AddressStatusEnum.Active).ToList();

            return list;
        }
    }
}
