using SolidarityBlood.Core.DTOs.Report;
using SolidarityBlood.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidarityBlood.Core.Repositories
{
    public interface IReportRepository
    {

        Task<List<ReportDonationDTO>> ReportLastDonation();
        Task<List<BloodStock>> ReportStockCheck();

    }
}
