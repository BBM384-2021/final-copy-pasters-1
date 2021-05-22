using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Web_API.Services;
using Web_API.ViewModels.ReviewAndRate.Request;
using Web_API.ViewModels.ReviewAndRate.Response;

namespace Web_API.Controllers
{
    [ApiController]
    [Route("api/Club/SubClub/[controller]")]
    public class ReviewAndRateController : BaseController
    {
        private readonly IReviewAndRateService _reviewAndRateService;

        public ReviewAndRateController(IReviewAndRateService reviewAndRateService)
        {
            _reviewAndRateService = reviewAndRateService;
        }

        [HttpPost]
        public ActionResult<ReviewAndRateResponseViewModel> Create(
            [FromBody] CreateReviewAndRateRequestViewModel model)
        {
            var response = _reviewAndRateService.Create(model);
            return Ok(response);
        }

        [HttpGet]
        public ActionResult<IEnumerable<ReviewAndRateResponseViewModel>> Read()
        {
            var reviewAndRates = _reviewAndRateService.Read();
            return Ok(reviewAndRates);
        }


        [HttpGet("{reviewAndRateId:int}")]
        public ActionResult<ReviewAndRateResponseViewModel> Read(int reviewAndRateId)
        {
            var reviewAndRate = _reviewAndRateService.Read(reviewAndRateId);
            return Ok(reviewAndRate);
        }

        [HttpPut("{reviewAndRateId:int}")]
        public ActionResult<ReviewAndRateResponseViewModel> Update(int reviewAndRateId,
            [FromBody] UpdateReviewAndRateRequestViewModel model)
        {
            var updatedRateAndReview = _reviewAndRateService.Update(reviewAndRateId, model);
            return Ok(updatedRateAndReview);
        }

        [HttpDelete("{reviewAndRateId:int}")]
        public ActionResult Delete(int reviewAndRateId)
        {
            _reviewAndRateService.Delete(reviewAndRateId);
            return new NoContentResult();
        }
    }
}