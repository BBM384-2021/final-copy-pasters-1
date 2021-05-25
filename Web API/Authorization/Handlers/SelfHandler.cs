using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Web_API.Authorization.Requirements;
using Web_API.Data;

namespace Web_API.Authorization.Handlers
{
    public class SelfHandler : AuthorizationHandler<SelfOrAdminRequirement>
    {
        private readonly AppDbContext _context;
        public SelfHandler(AppDbContext context)
        {
            _context = context;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, SelfOrAdminRequirement requirement)
        {
            if (context.Resource is not AuthorizationFilterContext authContext) return Task.CompletedTask;
            if (authContext.RouteData.Values["userId"] == null) return Task.CompletedTask;
            var userId = (string) authContext.RouteData.Values["userId"]; 
            if (context.User.HasClaim("Id", userId))
                context.Succeed(requirement);
            return Task.CompletedTask;
        }
    }
}