using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Web_API.Services;
using Web_API.ViewModels.OfflineEvent.Request;
using Web_API.ViewModels.OfflineEvent.Response;

namespace Web_API.Controllers
{
    [ApiController]
    [Route("api/Club/SubClub/[controller]")]
    public class OfflineEventController : BaseController
    {
        private readonly IOfflineEventService _offlineEventService;

        public OfflineEventController(IOfflineEventService offlineEventService)
        {
            _offlineEventService = offlineEventService;
        }

        [HttpPost]
        public ActionResult<OfflineEventResponseViewModel> Create(
            [FromBody] CreateOfflineEventRequestViewModel model)
        {
            var response = _offlineEventService.Create(model);
            return Ok(response);
        }

        [HttpGet]
        public ActionResult<IEnumerable<OfflineEventResponseViewModel>> Read()
        {
            var offlineEvents = _offlineEventService.Read();
            return Ok(offlineEvents);
        }


        [HttpGet("{offlineEventId:int}")]
        public ActionResult<OfflineEventResponseViewModel> Read(int offlineEventId)
        {
            var offlineEventInstance = _offlineEventService.Read(offlineEventId);
            return Ok(offlineEventInstance);
        }

        [HttpPut("{offlineEventId:int}")]
        public ActionResult<OfflineEventResponseViewModel> Update(int offlineEventId,
            [FromBody] UpdateOfflineEventRequestViewModel model)
        {
            var updatedRateAndReview = _offlineEventService.Update(offlineEventId, model);
            return Ok(updatedRateAndReview);
        }

        [HttpDelete("{offlineEventId:int}")]
        public ActionResult Delete(int offlineEventId)
        {
            _offlineEventService.Delete(offlineEventId);
            return new NoContentResult();
        }
    }
}