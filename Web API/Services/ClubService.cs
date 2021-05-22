using System.Collections.Generic;
using AutoMapper;
using Web_API.Data;
using Web_API.Entities;
using Web_API.ViewModels.Club.Request;
using Web_API.ViewModels.Club.Response;

namespace Web_API.Services
{
    public interface IClubService
    {
        public ClubResponseViewModel Create(CreateClubRequestViewModel model);
        public IEnumerable<ClubResponseViewModel> Read();
        public ClubResponseViewModel Read(int clubId);

        public ClubResponseViewModel Update(int clubId, UpdateClubRequestViewModel model);

        public void Delete(int clubId);

    }
    // TODO: all request will be converted into async type.
    public class ClubService : IClubService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ClubService(            
            AppDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public ClubResponseViewModel Create(CreateClubRequestViewModel model)
        {
            var club = _mapper.Map<Club>(model);
            _context.Clubs.Add(club);
            _context.SaveChanges();
            var response = _mapper.Map<ClubResponseViewModel>(club);
            return response;
        }

        public IEnumerable<ClubResponseViewModel> Read()
        {
            var clubs = _context.Clubs;
            return _mapper.Map<IList<ClubResponseViewModel>>(clubs);
        }
        
        public ClubResponseViewModel Read(int clubId)
        {
            var club = _mapper.Map<ClubResponseViewModel>(_context.Clubs.Find(clubId));
            return club;
        }

        public ClubResponseViewModel Update(int clubId, UpdateClubRequestViewModel model)
        {
            var club = _context.Clubs.Find(clubId);
            _mapper.Map(model, club);
            _context.Clubs.Update(club);
            var updatedClub = _mapper.Map<ClubResponseViewModel>(club);
            return updatedClub;
        }

        public void Delete(int clubId)
        {
            var club = _context.Clubs.Find(clubId);
            _context.Clubs.Remove(club);
            _context.SaveChanges();
        }
        
        // When to put an object into Ok().
        // TODO: we'll finish the club service.
    }
}