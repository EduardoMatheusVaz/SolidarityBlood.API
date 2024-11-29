using MediatR;
using SolidarityBlood.Application.DTOs.Addresses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidarityBlood.Application.Queries.Address
{
    public class GetDeleteAddressQuerie : IRequest<List<GetAllAddressDTO>>
    {

    }
}
