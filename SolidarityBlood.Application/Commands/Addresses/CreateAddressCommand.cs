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
        //public string? PublicPlace { get; set; }
        //public string? City { get; set; }
        //public string? State { get; set; }
        public string ZipCode { get; set; }
    }
}
