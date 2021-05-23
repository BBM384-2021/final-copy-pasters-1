using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Web_API.Entities;
using Web_API.Services;
using Web_API.ViewModels.SubClubUser.Request;
using Web_API.ViewModels.SubClubUser.Response;

namespace Web_API.Controllers
{
    [ApiController]
    [Route("api/Club/SubClub/[controller]")]
    public class SubClubUserController : BaseController
    {
        private readonly ISubClubUserService _subClubUserService;

        public SubClubUserController(ISubClubUserService subClubUserService)
        {
            _subClubUserService = subClubUserService;
        }

        [Helpers.Authorize(Role.Admin)]
        [HttpPost]
        public ActionResult<SubClubUserResponseViewModel> Create(
            [FromBody] CreateSubClubUserRequestViewModel model)
        {
            var response = _subClubUserService.Create(model);
            return Ok(response);
        }
        
        [Helpers.Authorize(Role.Admin)]
        [HttpGet]
        public ActionResult<IEnumerable<SubClubUserResponseViewModel>> Read()
        {
            var subClubUsers = _subClubUserService.Read();
            return Ok(subClubUsers);
        }
        
        [Helpers.Authorize(Role.Admin)]
        [HttpGet("{subClubId:int}/{userId:int}")]
        public ActionResult<SubClubUserResponseViewModel> Read(int subClubId, int userId)
        {
            var subClubUser = _subClubUserService.Read(subClubId, userId);
            return Ok(subClubUser);
        }

        [HttpPut("{subClubId:int}/{userId:int}")]
        public ActionResult<SubClubUserResponseViewModel> Update(int subClubId, int userId,
            [FromBody] UpdateSubClubUserRequestViewModel model)
        {
            var updatedSubClubUser = _subClubUserService.Update(subClubId, userId, model);
            return Ok(updatedSubClubUser);
        }   
        
        [HttpDelete("{subClubId:int}/{userId:int}")]
        public ActionResult Delete(int subClubId, int userId)
        {
            _subClubUserService.Delete(subClubId, userId);
            return new NoContentResult();
        }
    }
}