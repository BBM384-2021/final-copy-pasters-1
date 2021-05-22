using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Web_API.Services;
using Web_API.ViewModels.BanRecord.Request;
using Web_API.ViewModels.BanRecord.Response;

namespace Web_API.Controllers
{
    [ApiController]
    [Route("api/Club/SubClub/[controller]")]
    public class BanRecordController : BaseController
    {
        private readonly IBanRecordService _banRecordService;

        public BanRecordController(IBanRecordService banRecordService)
        {
            _banRecordService = banRecordService;
        }

        [HttpPost]
        public ActionResult<BanRecordResponseViewModel> Create(
            [FromBody] CreateBanRecordRequestViewModel model)
        {
            var response = _banRecordService.Create(model);
            return Ok(response);
        }

        [HttpGet]
        public ActionResult<IEnumerable<BanRecordResponseViewModel>> Read()
        {
            var banRecords = _banRecordService.Read();
            return Ok(banRecords);
        }


        [HttpGet("{banRecordId:int}")]
        public ActionResult<BanRecordResponseViewModel> Read(int banRecordId)
        {
            var banRecord = _banRecordService.Read(banRecordId);
            return Ok(banRecord);
        }

        [HttpPut("{banRecordId:int}")]
        public ActionResult<BanRecordResponseViewModel> Update(int banRecordId,
            [FromBody] UpdateBanRecordRequestViewModel model)
        {
            var updatedRateAndReview = _banRecordService.Update(banRecordId, model);
            return Ok(updatedRateAndReview);
        }

        [HttpDelete("{banRecordId:int}")]
        public ActionResult Delete(int banRecordId)
        {
            _banRecordService.Delete(banRecordId);
            return new NoContentResult();
        }
    }
}