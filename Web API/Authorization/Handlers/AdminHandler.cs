using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Web_API.Authorization.Requirements;
using Web_API.Data;
using Web_API.Entities;

namespace Web_API.Authorization.Handlers
{
    public class AdminHandler : AuthorizationHandler<SelfOrAdminRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, SelfOrAdminRequirement requirement)
        {
            if (context.User.HasClaim("UserType", "Admin"))
                context.Succeed(requirement);
            return Task.CompletedTask;
        }
    }
}