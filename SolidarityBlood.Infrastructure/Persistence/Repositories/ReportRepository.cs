using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using SolidarityBlood.Core.DTOs.Report;
using SolidarityBlood.Core.Entities;
using SolidarityBlood.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidarityBlood.Infrastructure.Persistence.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private readonly SolidarityBloodDbContext _dbContext;
        private readonly string _connectionString;

        public ReportRepository(SolidarityBloodDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _connectionString = configuration.GetConnectionString("DataBase");
        }

        public async Task<List<ReportDonationDTO>> ReportLastDonation()
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                var script = @"SELECT dn.Id, dn.DateDonation, dn.QuantityMl, dn.Status, d.Id AS DonorId, d.FullName, d.Email, d.Gender, d.BloodTypes, d.RHFactor 
                               FROM tb_Donation AS dn 
                               INNER JOIN tb_Donor AS d ON dn.DonorId = d.Id 
                               WHERE dn.DateDonation 
                               BETWEEN GETDATE() -30 AND GETDATE();";

                var get = await sqlConnection.QueryAsync<ReportDonationDTO>(script);

                return get.ToList();
            } 
        }


        public async Task<List<BloodStock>> ReportStockCheck()
        {

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                var script = @"SELECT Id, BloodType, RHFactor, QuantityMl, Status FROM tb_BloodStock";

                var get = await sqlConnection.QueryAsync<BloodStock>(script);

                return get.ToList();
            }


        }


    }
}
