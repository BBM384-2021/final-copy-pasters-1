using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Web_API.Authorization.Requirements;
using Web_API.Data;
using Web_API.Entities;

namespace Web_API.Authorization.Handlers
{
    public class SubClubAdminHandler : AuthorizationHandler<SubClubAdminRequirement>
    {
        private readonly AppDbContext _context;
        public SubClubAdminHandler(AppDbContext context)
        {
            _context = context;
        }
        
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, SubClubAdminRequirement requirement)
        {
            if (context.Resource is not AuthorizationFilterContext authContext) return Task.CompletedTask;
            if (authContext.RouteData.Values["subClubId"] == null) return Task.CompletedTask;
            var subClubId = (int) authContext.RouteData.Values["subClubId"];
            var userId = context.User.FindFirst(c => c.Type == "Id")?.Value;
            var subClubUser = _context.SubClubUsers.Find(subClubId, userId);
            
            if (subClubUser.SubClubRole == SubClubRole.Admin)
                context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}