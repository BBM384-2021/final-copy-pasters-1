using System.Collections.Generic;
using AutoMapper;
using Web_API.Data;
using Web_API.Entities;
using Web_API.ViewModels.OfflineEvent.Request;
using Web_API.ViewModels.OfflineEvent.Response;

namespace Web_API.Services
{
    public interface IOfflineEventService
    {
        public OfflineEventResponseViewModel Create(CreateOfflineEventRequestViewModel model);
        public IEnumerable<OfflineEventResponseViewModel> Read();
        public OfflineEventResponseViewModel Read(int eventId);

        public OfflineEventResponseViewModel Update(int eventId,
            UpdateOfflineEventRequestViewModel model);

        public void Delete(int eventId);
    }

    public class OfflineEventService : IOfflineEventService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public OfflineEventService(            
            AppDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public OfflineEventResponseViewModel Create(CreateOfflineEventRequestViewModel model)
        {
            var offlineEvent = _mapper.Map<OfflineEvent>(model);
            _context.OfflineEvents.Add(offlineEvent);
            _context.SaveChanges();
            var response = _mapper.Map<OfflineEventResponseViewModel>(offlineEvent);
            return response;
        }

        public IEnumerable<OfflineEventResponseViewModel> Read()
        {
            var offlineEvents = _context.OfflineEvents;
            return _mapper.Map<IList<OfflineEventResponseViewModel>>(offlineEvents);
        }

        public OfflineEventResponseViewModel Read(int eventId)
        {
            var offlineEvent = _mapper.Map<OfflineEventResponseViewModel>(_context.OfflineEvents.Find(eventId));
            return offlineEvent;
        }

        public OfflineEventResponseViewModel Update(int eventId,
            UpdateOfflineEventRequestViewModel model)
        {
            var offlineEvent = _context.OfflineEvents.Find(eventId);
            _mapper.Map(model, offlineEvent);
            _context.OfflineEvents.Update(offlineEvent);
            var updatedOfflineEvent = _mapper.Map<OfflineEventResponseViewModel>(offlineEvent);
            return updatedOfflineEvent;
        }

        public void Delete(int eventId)
        {
            var offlineEvent = _context.OfflineEvents.Find(eventId);
            _context.OfflineEvents.Remove(offlineEvent);
            _context.SaveChanges();
        }
    }
}