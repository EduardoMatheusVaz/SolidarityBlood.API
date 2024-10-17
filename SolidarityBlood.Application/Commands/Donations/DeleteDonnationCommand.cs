using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidarityBlood.Application.Commands.Donations
{
    public class DeleteDonnationCommand : IRequest<Unit>
    {
        public DeleteDonnationCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
