using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Web_API.Services;
using Web_API.ViewModels.OnlineEvent.Request;
using Web_API.ViewModels.OnlineEvent.Response;

namespace Web_API.Controllers
{
    [ApiController]
    [Route("api/Club/SubClub/[controller]")]
    public class OnlineEventController : BaseController
    {
        private readonly IOnlineEventService _onlineEventService;

        public OnlineEventController(IOnlineEventService onlineEventService)
        {
            _onlineEventService = onlineEventService;
        }

        [HttpPost]
        public ActionResult<OnlineEventResponseViewModel> Create(
            [FromBody] CreateOnlineEventRequestViewModel model)
        {
            var response = _onlineEventService.Create(model);
            return Ok(response);
        }

        [HttpGet]
        public ActionResult<IEnumerable<OnlineEventResponseViewModel>> Read()
        {
            var onlineEvents = _onlineEventService.Read();
            return Ok(onlineEvents);
        }


        [HttpGet("{onlineEventId:int}")]
        public ActionResult<OnlineEventResponseViewModel> Read(int onlineEventId)
        {
            var onlineEventInstance = _onlineEventService.Read(onlineEventId);
            return Ok(onlineEventInstance);
        }

        [HttpPut("{onlineEventId:int}")]
        public ActionResult<OnlineEventResponseViewModel> Update(int onlineEventId,
            [FromBody] UpdateOnlineEventRequestViewModel model)
        {
            var updatedRateAndReview = _onlineEventService.Update(onlineEventId, model);
            return Ok(updatedRateAndReview);
        }

        [HttpDelete("{onlineEventId:int}")]
        public ActionResult Delete(int onlineEventId)
        {
            _onlineEventService.Delete(onlineEventId);
            return new NoContentResult();
        }
    }
}