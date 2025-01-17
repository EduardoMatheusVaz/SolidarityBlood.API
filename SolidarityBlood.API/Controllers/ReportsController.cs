using MediatR;
using Microsoft.AspNetCore.Mvc;
using SolidarityBlood.Application.Commands.Reports;

namespace SolidarityBlood.API.Controllers
{
    [ApiController]
    [Route("api/reports")]
    public class ReportsController  : ControllerBase
    {
        private IMediator _mediator;

        public ReportsController(IMediator mediator)
        {
            _mediator = mediator;
        }



        [HttpPost("Report Last Thirty Days Donations")]
        public async Task<IActionResult> ThirtyDayDonationReport()
        {
            var takePDF = new ReportLastDonationsCommand();

            var report = await _mediator.Send(takePDF);

            return Ok(report);
        }



        [HttpPost("Report Total Blood by Type")]
        public async Task<IActionResult> TotalBlood()
        {
            var get = new ReportStockCheckCommand();

            var report = await _mediator.Send(get);
            
            return Ok(report);
        }
    }
}
