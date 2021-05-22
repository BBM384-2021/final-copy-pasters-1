using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Web_API.Services;
using Web_API.ViewModels.Club.Request;
using Web_API.ViewModels.Club.Response;

namespace Web_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClubController : BaseController
    {
        private readonly IClubService _clubService;

        public ClubController(IClubService clubService)
        {
            _clubService = clubService;
        }
        [HttpPost]
        public ActionResult<ClubResponseViewModel> Create([FromBody] CreateClubRequestViewModel model)
        {
            var response = _clubService.Create(model);
            return Ok(response);
        }
        
        
        [HttpGet]
        public ActionResult<IEnumerable<ClubResponseViewModel>> Read()
        {
            var clubs = _clubService.Read();
            return Ok(clubs);
        }     
        
        [HttpGet("{clubId:int}")]
        public ActionResult<ClubResponseViewModel> Read(int clubId)
        {
            var club = _clubService.Read(clubId);
            return Ok(club);
        }

        [HttpPut("{clubId:int}")]
        public ActionResult<ClubResponseViewModel> Update(int clubId, [FromBody] UpdateClubRequestViewModel model)
        {
            var updatedClub = _clubService.Update(clubId, model);
            return Ok(updatedClub);
        }
        
        [HttpDelete("{clubId:int}")]
        public ActionResult Delete(int clubId)
        {
            _clubService.Delete(clubId);
            return new NoContentResult();
        }
    }
}