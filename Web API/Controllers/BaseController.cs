using Microsoft.AspNetCore.Mvc;
using Web_API.Entities;

namespace Web_API.Controllers
{
    [Controller]
    public abstract class BaseController : ControllerBase
    {
        // returns the current authenticated account (null if not logged in)
        protected new User User => (User)HttpContext.Items["User"];
    }
}