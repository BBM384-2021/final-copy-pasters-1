using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Web_API.Services;
using Web_API.ViewModels.Question.Request;
using Web_API.ViewModels.Question.Response;

namespace Web_API.Controllers
{
    [ApiController]
    [Route("api/Club/SubClub/[controller]")]
    public class QuestionController : BaseController
    {
        private readonly IQuestionService _questionService;

        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        [HttpPost]
        public ActionResult<QuestionResponseViewModel> Create(
            [FromBody] CreateQuestionRequestViewModel model)
        {
            var response = _questionService.Create(model);
            return Ok(response);
        }

        [HttpGet]
        public ActionResult<IEnumerable<QuestionResponseViewModel>> Read()
        {
            var questions = _questionService.Read();
            return Ok(questions);
        }


        [HttpGet("{questionId:int}")]
        public ActionResult<QuestionResponseViewModel> Read(int questionId)
        {
            var question = _questionService.Read(questionId);
            return Ok(question);
        }

        [HttpPut("{questionId:int}")]
        public ActionResult<QuestionResponseViewModel> Update(int questionId,
            [FromBody] UpdateQuestionRequestViewModel model)
        {
            var updatedRateAndReview = _questionService.Update(questionId, model);
            return Ok(updatedRateAndReview);
        }

        [HttpDelete("{questionId:int}")]
        public ActionResult Delete(int questionId)
        {
            _questionService.Delete(questionId);
            return new NoContentResult();
        }
    }
}