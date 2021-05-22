using System.Collections.Generic;
using AutoMapper;
using Web_API.Data;
using Web_API.Entities;
using Web_API.ViewModels.ReviewAndRate.Request;
using Web_API.ViewModels.ReviewAndRate.Response;

namespace Web_API.Services
{
    public interface IReviewAndRateService
    {
        public ReviewAndRateResponseViewModel Create(CreateReviewAndRateRequestViewModel model);
        public IEnumerable<ReviewAndRateResponseViewModel> Read();
        public ReviewAndRateResponseViewModel Read(int reviewAndRateId);

        public ReviewAndRateResponseViewModel Update(int reviewAndRateId,
            UpdateReviewAndRateRequestViewModel model);

        public void Delete(int reviewAndRateId);
    }

    public class ReviewAndRateService : IReviewAndRateService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ReviewAndRateService(            
            AppDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReviewAndRateResponseViewModel Create(CreateReviewAndRateRequestViewModel model)
        {
            var reviewAndRate = _mapper.Map<ReviewAndRate>(model);
            _context.ReviewAndRates.Add(reviewAndRate);
            _context.SaveChanges();
            var response = _mapper.Map<ReviewAndRateResponseViewModel>(reviewAndRate);
            return response;
        }

        public IEnumerable<ReviewAndRateResponseViewModel> Read()
        {
            var reviewAndRates = _context.ReviewAndRates;
            return _mapper.Map<IList<ReviewAndRateResponseViewModel>>(reviewAndRates);
        }

        public ReviewAndRateResponseViewModel Read(int reviewAndRateId)
        {
            var reviewAndRate = _mapper.Map<ReviewAndRateResponseViewModel>(_context.ReviewAndRates.Find(reviewAndRateId));
            return reviewAndRate;
        }

        public ReviewAndRateResponseViewModel Update(int reviewAndRateId,
            UpdateReviewAndRateRequestViewModel model)
        {
            var reviewAndRate = _context.ReviewAndRates.Find(reviewAndRateId);
            _mapper.Map(model, reviewAndRate);
            _context.ReviewAndRates.Update(reviewAndRate);
            var updatedReviewAndRate = _mapper.Map<ReviewAndRateResponseViewModel>(reviewAndRate);
            return updatedReviewAndRate;
        }

        public void Delete(int reviewAndRateId)
        {
            var reviewAndRate = _context.ReviewAndRates.Find(reviewAndRateId);
            _context.ReviewAndRates.Remove(reviewAndRate);
            _context.SaveChanges();
        }
    }
}