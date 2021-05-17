using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Web_API.Data;
using Web_API.Services;
using Web_API.ViewModels.Event.Request;
using Web_API.ViewModels.Event.Response;

namespace Web_API.Controllers
{
    [ApiController]
    [Route("api/Club/{clubId:int}/SubClub/{subClubId:int}/[controller]")]
    public class EventController : BaseController
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IEventService _eventService;

        public EventController(AppDbContext context, IMapper mapper, IEventService eventService)
        {
            _context = context;
            _mapper = mapper;
            _eventService = eventService;
        }
        [HttpPost]
        public ActionResult<CreateEventResponseViewModel> Create(CreateEventRequestViewModel model)
        {
            return Ok();
        }
        
        [HttpGet]
        public ActionResult<ReadEventResponseViewModel> Read()
        {
            return Ok();
        }    
        
        [HttpGet("{id:int}")]
        public ActionResult<ReadEventResponseViewModel> Read(int id)
        {
            return Ok();
        }

        [HttpPut("{id:int}")]
        public ActionResult<UpdateEventResponseViewModel> Update(int id, [FromBody] UpdateEventRequestViewModel model)
        {
            return Ok();
        }
        
        [HttpDelete("{id:int}")]
        public ActionResult<DeleteEventResponseViewModel> Delete(int id)
        {
            return Ok();
        }
    }
}