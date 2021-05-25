using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Web_API.Authorization.Requirements;
using Web_API.Data;

namespace Web_API.Authorization.Handlers
{
    public class SelfHandler : AuthorizationHandler<SelfOrAdminRequirement>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public SelfHandler(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, SelfOrAdminRequirement requirement)
        {
            var routeValues = _httpContextAccessor.HttpContext.Request.RouteValues;
            routeValues.TryGetValue("userId", out var userId);
            if (context.User.HasClaim("Id", userId.ToString()))
                context.Succeed(requirement);
            return Task.CompletedTask;
        }
    }
}