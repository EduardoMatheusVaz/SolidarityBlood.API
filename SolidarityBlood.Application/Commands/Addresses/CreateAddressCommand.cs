using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidarityBlood.Application.Commands.Addresses
{
    public class CreateAddressCommand : IRequest<int>
    {
        public string ZipCode { get; set; }
    }
}
