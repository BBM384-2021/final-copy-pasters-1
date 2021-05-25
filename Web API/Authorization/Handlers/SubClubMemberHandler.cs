using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Web_API.Authorization.Requirements;
using Web_API.Data;
using Web_API.Entities;

namespace Web_API.Authorization.Handlers
{
    public class SubClubMemberHandler : AuthorizationHandler<SubClubMemberRequirement>
    {
        private readonly AppDbContext _appDbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public SubClubMemberHandler(AppDbContext appDbContext, IHttpContextAccessor httpContextAccessor)
        {
            _appDbContext = appDbContext;
            _httpContextAccessor = httpContextAccessor;
        }
        
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, SubClubMemberRequirement requirement)
        {
            // TODO: WE'RE HERE.
            var routeValues = _httpContextAccessor.HttpContext.Request.RouteValues;
            routeValues.TryGetValue("subClubId", out var subClubId);
            var userId = context.User.FindFirst(c => c.Type == "Id")?.Value;
            var subClubUser = _appDbContext.SubClubUsers.Find(subClubId.ToString(), userId);
            
            // For the sake of simplicity, I've written the expression that checks the user is in the subclub in question as such.
            if (subClubUser.SubClubRole == SubClubRole.Admin || subClubUser.SubClubRole == SubClubRole.Member)
                context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}