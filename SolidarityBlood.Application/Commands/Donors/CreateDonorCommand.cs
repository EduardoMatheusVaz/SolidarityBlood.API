using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidarityBlood.Application.Commands.Donors
{
    public class CreateDonorCommand : IRequest<int>
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime DateBirth { get; set; }
        public string Gender { get; set; }
        public double Weight { get; set; }
        public string BloodTypes { get; set; }
        public string RHFactor { get; set; }
        public int AddressId { get; set; }
    }
}
