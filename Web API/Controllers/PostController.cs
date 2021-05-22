using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Web_API.Services;
using Web_API.ViewModels.Post.Request;
using Web_API.ViewModels.Post.Response;

namespace Web_API.Controllers
{
    [ApiController]
    [Route("api/Club/SubClub/[controller]")]
    public class PostController : BaseController
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpPost]
        public ActionResult<PostResponseViewModel> Create(
            [FromBody] CreatePostRequestViewModel model)
        {
            var response = _postService.Create(model);
            return Ok(response);
        }

        [HttpGet]
        public ActionResult<IEnumerable<PostResponseViewModel>> Read()
        {
            var posts = _postService.Read();
            return Ok(posts);
        }


        [HttpGet("{postId:int}")]
        public ActionResult<PostResponseViewModel> Read(int postId)
        {
            var post = _postService.Read(postId);
            return Ok(post);
        }

        [HttpPut("{postId:int}")]
        public ActionResult<PostResponseViewModel> Update(int postId,
            [FromBody] UpdatePostRequestViewModel model)
        {
            var updatedRateAndReview = _postService.Update(postId, model);
            return Ok(updatedRateAndReview);
        }

        [HttpDelete("{postId:int}")]
        public ActionResult Delete(int postId)
        {
            _postService.Delete(postId);
            return new NoContentResult();
        }
    }
}