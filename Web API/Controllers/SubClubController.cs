using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Web_API.Services;
using Web_API.ViewModels.SubClub.Request;
using Web_API.ViewModels.SubClub.Response;

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    public class SubClubController : BaseController
    {
        private readonly ISubClubService _subClubService;

        public SubClubController(ISubClubService subClubService)
        {
            _subClubService = subClubService;
        }

        [HttpPost]
        public ActionResult<SubClubResponseViewModel> Create([FromBody] CreateSubClubRequestViewModel model)
        {
            var response = _subClubService.Create(model);
            return Ok(response);
        }
        
        [HttpGet]
        public ActionResult<IEnumerable<SubClubResponseViewModel>> Read()
        {
            var subClubs = _subClubService.Read();
            return Ok(subClubs);
        }


        [HttpGet("{subClubId:int}")]
        public ActionResult<SubClubResponseViewModel> Read(int subClubId)
        {
            var subClub = _subClubService.Read(subClubId);
            return Ok(subClub);
        }

        [HttpPut("{subClubId:int}")]
        public ActionResult<SubClubResponseViewModel> Update(int subClubId,
            [FromBody] UpdateSubClubRequestViewModel model)
        {
            var updatedSubClub = _subClubService.Update(subClubId, model);
            return Ok(updatedSubClub);
        }

        [HttpDelete("{subClubId:int}")]
        public ActionResult Delete(int subClubId)
        {
            _subClubService.Delete(subClubId);
            return new NoContentResult();
        }
    }
}