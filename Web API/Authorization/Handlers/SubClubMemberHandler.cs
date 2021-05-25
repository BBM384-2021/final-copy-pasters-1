using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Web_API.Authorization.Requirements;
using Web_API.Data;
using Web_API.Entities;

namespace Web_API.Authorization.Handlers
{
    public class SubClubMemberHandler : AuthorizationHandler<SubClubMemberRequirement>
    {
        private readonly AppDbContext _context;
        public SubClubMemberHandler(AppDbContext context)
        {
            _context = context;
        }
        
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, SubClubMemberRequirement requirement)
        {
            if (context.Resource is not AuthorizationFilterContext authContext) return Task.CompletedTask;
            if (authContext.RouteData.Values["subClubId"] == null) return Task.CompletedTask;
            var subClubId = (int) authContext.RouteData.Values["subClubId"];
            var userId = context.User.FindFirst(c => c.Type == "Id")?.Value;
            var subClubUser = _context.SubClubUsers.Find(subClubId, userId);
            
            // For the sake of simplicity, I've written the expression that checks the user is in the subclub in question as such.
            if (subClubUser.SubClubRole == SubClubRole.Admin || subClubUser.SubClubRole == SubClubRole.Member)
                context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}