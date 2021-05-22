using System.Collections.Generic;
using AutoMapper;
using Web_API.Data;
using Web_API.Entities;
using Web_API.ViewModels.SubClub.Request;
using Web_API.ViewModels.SubClub.Response;

namespace Web_API.Services
{
    public interface ISubClubService
    {
        public SubClubResponseViewModel Create(CreateSubClubRequestViewModel model);
        public IEnumerable<SubClubResponseViewModel> Read();
        public SubClubResponseViewModel Read(int clubId);

        public SubClubResponseViewModel Update(int clubId, UpdateSubClubRequestViewModel model);

        public void Delete(int clubId);
    }

    public class SubClubService : ISubClubService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public SubClubService(            
            AppDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public SubClubResponseViewModel Create(CreateSubClubRequestViewModel model)
        {
            var subClub = _mapper.Map<SubClub>(model);
            _context.SubClubs.Add(subClub);
            _context.SaveChanges();
            var response = _mapper.Map<SubClubResponseViewModel>(subClub);
            return response;
        }

        public IEnumerable<SubClubResponseViewModel> Read()
        {
            var clubs = _context.SubClubs;
            return _mapper.Map<IList<SubClubResponseViewModel>>(clubs);
        }
        
        public SubClubResponseViewModel Read(int clubId)
        {
            var subClub = _mapper.Map<SubClubResponseViewModel>(_context.SubClubs.Find(clubId));
            return subClub;
        }

        public SubClubResponseViewModel Update(int clubId, UpdateSubClubRequestViewModel model)
        {
            var subClub = _context.SubClubs.Find(clubId);
            _mapper.Map(model, subClub);
            _context.SubClubs.Update(subClub);
            var updatedSubClub = _mapper.Map<SubClubResponseViewModel>(subClub);
            return updatedSubClub;
        }

        public void Delete(int clubId)
        {
            var subClub = _context.SubClubs.Find(clubId);
            _context.SubClubs.Remove(subClub);
            _context.SaveChanges();
        }
    }
}