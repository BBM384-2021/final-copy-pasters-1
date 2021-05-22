using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Web_API.Services;
using Web_API.ViewModels.Report.Request;
using Web_API.ViewModels.Report.Response;

namespace Web_API.Controllers
{
    [ApiController]
    [Route("api/Club/SubClub/[controller]")]
    public class ReportController : BaseController
    {
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpPost]
        public ActionResult<ReportResponseViewModel> Create(
            [FromBody] CreateReportRequestViewModel model)
        {
            var response = _reportService.Create(model);
            return Ok(response);
        }

        [HttpGet]
        public ActionResult<IEnumerable<ReportResponseViewModel>> Read()
        {
            var reports = _reportService.Read();
            return Ok(reports);
        }


        [HttpGet("{reportId:int}")]
        public ActionResult<ReportResponseViewModel> Read(int reportId)
        {
            var report = _reportService.Read(reportId);
            return Ok(report);
        }

        [HttpPut("{reportId:int}")]
        public ActionResult<ReportResponseViewModel> Update(int reportId,
            [FromBody] UpdateReportRequestViewModel model)
        {
            var updatedRateAndReview = _reportService.Update(reportId, model);
            return Ok(updatedRateAndReview);
        }

        [HttpDelete("{reportId:int}")]
        public ActionResult Delete(int reportId)
        {
            _reportService.Delete(reportId);
            return new NoContentResult();
        }
    }
}