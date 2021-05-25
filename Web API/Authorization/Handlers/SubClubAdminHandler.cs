using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Web_API.Authorization.Requirements;
using Web_API.Data;
using Web_API.Entities;

namespace Web_API.Authorization.Handlers
{
    public class SubClubAdminHandler : AuthorizationHandler<SubClubAdminRequirement>
    {
        private readonly AppDbContext _appDbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public SubClubAdminHandler(AppDbContext appDbContext, IHttpContextAccessor httpContextAccessor)
        {
            _appDbContext = appDbContext;
            _httpContextAccessor = httpContextAccessor;
        }
        
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, SubClubAdminRequirement requirement)
        {
            var routeValues = _httpContextAccessor.HttpContext.Request.RouteValues;
            routeValues.TryGetValue("subClubId", out var subClubId);
            var userId = context.User.FindFirst(c => c.Type == "Id")?.Value;
            var subClubUser = _appDbContext.SubClubUsers.Find(subClubId.ToString(), userId);
            
            if (subClubUser.SubClubRole == SubClubRole.Admin)
                context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}