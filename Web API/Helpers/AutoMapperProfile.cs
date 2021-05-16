using AutoMapper;
using Web_API.Entities;
using Web_API.ViewModels.User.Request;
using Web_API.ViewModels.User.Response;

namespace Web_API.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserResponseViewModel>();

            CreateMap<User, AuthenticateResponseViewModel>();

            CreateMap<RegisterRequestViewModel, User>();

            CreateMap<CreateRequestViewModel, User>();

            CreateMap<UpdateRequestViewModel, User>()
                .ForAllMembers(x => x.Condition(
                    (src, dest, prop) =>
                    {
                        switch (prop)
                        {
                            // ignore null & empty string properties
                            case null:
                            case string arg3 when string.IsNullOrEmpty(arg3):
                                return false;
                        }

                        // ignore null role
                        return x.DestinationMember.Name != "Role" || src.Role != null;
                    }
                ));
        }
    }
}