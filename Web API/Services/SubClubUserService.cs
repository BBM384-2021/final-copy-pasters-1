using System.Collections.Generic;
using AutoMapper;
using Web_API.Data;
using Web_API.Entities;
using Web_API.ViewModels.SubClubUser.Request;
using Web_API.ViewModels.SubClubUser.Response;

namespace Web_API.Services
{
    public interface ISubClubUserService
    {
        public SubClubUserResponseViewModel Create(CreateSubClubUserRequestViewModel model);
        public IEnumerable<SubClubUserResponseViewModel> Read();
        public SubClubUserResponseViewModel Read(int subClubId, int userId);

        public SubClubUserResponseViewModel Update(int subClubId, int userId, UpdateSubClubUserRequestViewModel model);

        public void Delete(int subClubId, int userId);
    }

    public class SubClubUserService : ISubClubUserService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public SubClubUserService(
            AppDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public SubClubUserResponseViewModel Create(CreateSubClubUserRequestViewModel model)
        {
            var subClubUser = _mapper.Map<SubClubUser>(model);
            _context.SubClubUsers.Add(subClubUser);
            _context.SaveChanges();
            var response = _mapper.Map<SubClubUserResponseViewModel>(subClubUser);
            return response;
        }

        public IEnumerable<SubClubUserResponseViewModel> Read()
        {
            var clubs = _context.SubClubUsers;
            return _mapper.Map<IList<SubClubUserResponseViewModel>>(clubs);
        }

        public SubClubUserResponseViewModel Read(int subClubId, int userId)
        {
            var subClubUser = _mapper.Map<SubClubUserResponseViewModel>(_context.SubClubUsers.
                Find(subClubId, userId));
            return subClubUser;
        }

        public SubClubUserResponseViewModel Update(int subClubId, int userId, UpdateSubClubUserRequestViewModel model)
        {
            var subClubUser = _context.SubClubUsers.Find(subClubId, userId);
            _mapper.Map(model, subClubUser);
            _context.SubClubUsers.Update(subClubUser);
            var updatedSubClubUser = _mapper.Map<SubClubUserResponseViewModel>(subClubUser);
            return updatedSubClubUser;
        }

        public void Delete(int subClubId, int userId)
        {
            var subClubUser = _context.SubClubUsers.Find(subClubId, userId);
            _context.SubClubUsers.Remove(subClubUser);
            _context.SaveChanges();
        }
    }
}