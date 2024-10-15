using SolidarityBlood.Application.DTOs.Donations;
using SolidarityBlood.Application.Services.Interfaces;
using SolidarityBlood.Core.Entities;
using SolidarityBlood.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidarityBlood.Application.Services.Implementations
{
    public class DonationService : IDonationService
    {
        private readonly SolidarityBloodDbContext _dbcontext;

        public DonationService(SolidarityBloodDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public int Create(CreateDonationDTO donation)
        {
            var newDonation = new Donation(donation.DonorId, donation.DateDonation, donation.QuantityMl);

            _dbcontext.Donation.Add(newDonation);
            _dbcontext.SaveChanges();

            return donation.Id;
        }

        public void Delete(int id)
        {
            var donation = _dbcontext.Donation.SingleOrDefault(d => d.Id == id);

            _dbcontext.Donation.Remove(donation);
            _dbcontext.SaveChanges();
        }

        public List<GetAllDonationDTO> GetAllDonations()
        {
            var donations = _dbcontext.Donation.Select(gad => new GetAllDonationDTO(
                gad.Id,
                gad.DonorId,
                gad.DateDonation,
                gad.QuantityMl
                )).ToList();

            return donations;
        }

        public GetByIdDonationDTO GetById(int id)
        {
            var donation = _dbcontext.Donation.SingleOrDefault(d => d.Id == id);

            var newDonation = new GetByIdDonationDTO(donation.Id, donation.DonorId, donation.DateDonation, donation.QuantityMl);

            return newDonation;

        }

        public void Update(int id, UpdateDonationDTO donation)
        {
            var newDonor = _dbcontext.Donation.SingleOrDefault(d => d.Id == id);

            newDonor.Update(donation.DonorId, donation.DateDonation, donation.QuantityMl);
            _dbcontext.SaveChanges();
        }
    }
}
