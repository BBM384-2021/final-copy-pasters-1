using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Web_API.Services;
using Web_API.ViewModels.Comment.Request;
using Web_API.ViewModels.Comment.Response;

namespace Web_API.Controllers
{
    [ApiController]
    [Route("api/Club/SubClub/Post/[controller]")]
    public class CommentController : BaseController
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost]
        public ActionResult<CommentResponseViewModel> Create(
            [FromBody] CreateCommentRequestViewModel model)
        {
            var response = _commentService.Create(model);
            return Ok(response);
        }

        [HttpGet]
        public ActionResult<IEnumerable<CommentResponseViewModel>> Read()
        {
            var comments = _commentService.Read();
            return Ok(comments);
        }


        [HttpGet("{commentId:int}")]
        public ActionResult<CommentResponseViewModel> Read(int commentId)
        {
            var comment = _commentService.Read(commentId);
            return Ok(comment);
        }

        [HttpPut("{commentId:int}")]
        public ActionResult<CommentResponseViewModel> Update(int commentId,
            [FromBody] UpdateCommentRequestViewModel model)
        {
            var updatedRateAndReview = _commentService.Update(commentId, model);
            return Ok(updatedRateAndReview);
        }

        [HttpDelete("{commentId:int}")]
        public ActionResult Delete(int commentId)
        {
            _commentService.Delete(commentId);
            return new NoContentResult();
        }
    }
}