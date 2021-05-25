using AutoMapper;
using Web_API.Entities;
using Web_API.ViewModels.Club.Request;
using Web_API.ViewModels.Club.Response;
using Web_API.ViewModels.Comment.Request;
using Web_API.ViewModels.Comment.Response;
using Web_API.ViewModels.OfflineEvent.Request;
using Web_API.ViewModels.OfflineEvent.Response;
using Web_API.ViewModels.OnlineEvent.Request;
using Web_API.ViewModels.OnlineEvent.Response;
using Web_API.ViewModels.Post.Request;
using Web_API.ViewModels.Post.Response;
using Web_API.ViewModels.Question.Request;
using Web_API.ViewModels.Question.Response;
using Web_API.ViewModels.Report.Request;
using Web_API.ViewModels.Report.Response;
using Web_API.ViewModels.ReviewAndRate.Request;
using Web_API.ViewModels.ReviewAndRate.Response;
using Web_API.ViewModels.SubClub.Request;
using Web_API.ViewModels.SubClub.Response;
using Web_API.ViewModels.SubClubUser.Request;
using Web_API.ViewModels.SubClubUser.Response;
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
                        return x.DestinationMember.Name != "Role";
                    }
                ));
            
            // Configs for entities
            CreateMap<Club, ClubResponseViewModel>();
            CreateMap<CreateClubRequestViewModel, Club>();
            CreateMap<UpdateClubRequestViewModel, Club>();
            
            CreateMap<Comment, CommentResponseViewModel>();
            CreateMap<CreateCommentRequestViewModel, Comment>();
            CreateMap<UpdateCommentRequestViewModel, Comment>();
            
            CreateMap<OfflineEvent, OfflineEventResponseViewModel>();
            CreateMap<CreateOfflineEventRequestViewModel, OfflineEvent>();
            CreateMap<UpdateOfflineEventRequestViewModel, OfflineEvent>();
            
            CreateMap<OnlineEvent, OnlineEventResponseViewModel>();
            CreateMap<CreateOnlineEventRequestViewModel, OnlineEvent>();
            CreateMap<UpdateOnlineEventRequestViewModel, Club>();
            
            CreateMap<Post, PostResponseViewModel>();
            CreateMap<CreatePostRequestViewModel, Post>();
            CreateMap<UpdatePostRequestViewModel, Post>();
            
            CreateMap<Question, QuestionResponseViewModel>();
            CreateMap<CreateQuestionRequestViewModel, Question>();
            CreateMap<UpdateQuestionRequestViewModel, Question>();
            
            CreateMap<Report, ReportResponseViewModel>();
            CreateMap<CreateReportRequestViewModel, Report>();
            CreateMap<UpdateReportRequestViewModel, Report>();
            
            CreateMap<ReviewAndRate, ReviewAndRateResponseViewModel>();
            CreateMap<CreateReviewAndRateRequestViewModel, ReviewAndRate>();
            CreateMap<UpdateReviewAndRateRequestViewModel, ReviewAndRate>();
            
            CreateMap<SubClub, SubClubResponseViewModel>();
            CreateMap<CreateSubClubRequestViewModel, SubClub>();
            CreateMap<UpdateSubClubRequestViewModel, SubClub>();
            
            CreateMap<SubClubUser, SubClubUserResponseViewModel>();
            CreateMap<CreateSubClubUserRequestViewModel, SubClubUser>();
            CreateMap<UpdateSubClubUserRequestViewModel, SubClubUser>();
        }
    }
}