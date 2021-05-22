using System.Collections.Generic;
using AutoMapper;
using Web_API.Data;
using Web_API.Entities;
using Web_API.ViewModels.OnlineEvent.Request;
using Web_API.ViewModels.OnlineEvent.Response;

namespace Web_API.Services
{
    public interface IOnlineEventService
    {
        public OnlineEventResponseViewModel Create(CreateOnlineEventRequestViewModel model);
        public IEnumerable<OnlineEventResponseViewModel> Read();
        public OnlineEventResponseViewModel Read(int eventId);

        public OnlineEventResponseViewModel Update(int eventId,
            UpdateOnlineEventRequestViewModel model);

        public void Delete(int eventId);
    }

    public class OnlineEventService : IOnlineEventService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public OnlineEventService(            
            AppDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public OnlineEventResponseViewModel Create(CreateOnlineEventRequestViewModel model)
        {
            var onlineEvent = _mapper.Map<OnlineEvent>(model);
            _context.OnlineEvents.Add(onlineEvent);
            _context.SaveChanges();
            var response = _mapper.Map<OnlineEventResponseViewModel>(onlineEvent);
            return response;
        }

        public IEnumerable<OnlineEventResponseViewModel> Read()
        {
            var onlineEvents = _context.OnlineEvents;
            return _mapper.Map<IList<OnlineEventResponseViewModel>>(onlineEvents);
        }

        public OnlineEventResponseViewModel Read(int eventId)
        {
            var onlineEvent = _mapper.Map<OnlineEventResponseViewModel>(_context.OnlineEvents.Find(eventId));
            return onlineEvent;
        }

        public OnlineEventResponseViewModel Update(int eventId,
            UpdateOnlineEventRequestViewModel model)
        {
            var onlineEvent = _context.OnlineEvents.Find(eventId);
            _mapper.Map(model, onlineEvent);
            _context.OnlineEvents.Update(onlineEvent);
            var updatedOnlineEvent = _mapper.Map<OnlineEventResponseViewModel>(onlineEvent);
            return updatedOnlineEvent;
        }

        public void Delete(int eventId)
        {
            var onlineEvent = _context.OnlineEvents.Find(eventId);
            _context.OnlineEvents.Remove(onlineEvent);
            _context.SaveChanges();
        }
    }
}