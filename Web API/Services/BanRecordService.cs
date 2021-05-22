using System.Collections.Generic;
using AutoMapper;
using Web_API.Data;
using Web_API.Entities;
using Web_API.ViewModels.BanRecord.Request;
using Web_API.ViewModels.BanRecord.Response;

namespace Web_API.Services
{
    public interface IBanRecordService
    {
        public BanRecordResponseViewModel Create(CreateBanRecordRequestViewModel model);
        public IEnumerable<BanRecordResponseViewModel> Read();
        public BanRecordResponseViewModel Read(int banRecordId);

        public BanRecordResponseViewModel Update(int banRecordId,
            UpdateBanRecordRequestViewModel model);

        public void Delete(int banRecordId);
    }

    public class BanRecordService : IBanRecordService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public BanRecordService(            
            AppDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public BanRecordResponseViewModel Create(CreateBanRecordRequestViewModel model)
        {
            var banRecord = _mapper.Map<BanRecord>(model);
            _context.BanRecords.Add(banRecord);
            _context.SaveChanges();
            var response = _mapper.Map<BanRecordResponseViewModel>(banRecord);
            return response;
        }

        public IEnumerable<BanRecordResponseViewModel> Read()
        {
            var banRecords = _context.BanRecords;
            return _mapper.Map<IList<BanRecordResponseViewModel>>(banRecords);
        }

        public BanRecordResponseViewModel Read(int banRecordId)
        {
            var banRecord = _mapper.Map<BanRecordResponseViewModel>(_context.BanRecords.Find(banRecordId));
            return banRecord;
        }

        public BanRecordResponseViewModel Update(int banRecordId,
            UpdateBanRecordRequestViewModel model)
        {
            var banRecord = _context.BanRecords.Find(banRecordId);
            _mapper.Map(model, banRecord);
            _context.BanRecords.Update(banRecord);
            var updatedBanRecord = _mapper.Map<BanRecordResponseViewModel>(banRecord);
            return updatedBanRecord;
        }

        public void Delete(int banRecordId)
        {
            var banRecord = _context.BanRecords.Find(banRecordId);
            _context.BanRecords.Remove(banRecord);
            _context.SaveChanges();
        }
    }
}