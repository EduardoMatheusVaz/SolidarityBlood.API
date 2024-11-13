using MediatR;
using Microsoft.EntityFrameworkCore;
using SolidarityBlood.Core.Entities;
using SolidarityBlood.Core.Repositories;
using SolidarityBlood.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace SolidarityBlood.Application.Commands.Donors
{
    public class CreateDonorCommandHandler : IRequestHandler<CreateDonorCommand, int>
    {
        private readonly IDonorRepository _donorRepository;
        private readonly SolidarityBloodDbContext _dbContext;

        public CreateDonorCommandHandler(IDonorRepository donorRepository, SolidarityBloodDbContext dbContext)
        {
            _donorRepository = donorRepository;
            _dbContext = dbContext;
        }

        public async Task<int> Handle(CreateDonorCommand request, CancellationToken cancellationToken)
        {
            // 1 - Acessar o contexto de dados
            // 2 - Pegar variavel com o valor do email
            // 3 - Validar se o valor de entrada ja existe no contexto de dados
            // 4 - Caso ele já exista então deve barrar a entrada do dado            

            var newDonor = new Donor(request.FullName, request.Email, request.DateBirth, request.Gender, request.Weight, request.BloodTypes, request.RHFactor, request.AddressId);

            if (await _dbContext.Donor.AnyAsync(d => d.Email.Equals(request.Email)))
            {
                throw new InvalidOperationException("Email informado já está em uso!");
            }
            

            await _donorRepository.CreateDonor(newDonor);

            return newDonor.Id;
        }
    }
}
