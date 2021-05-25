using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_API.Services;
using Web_API.ViewModels.User.Request;
using Web_API.ViewModels.User.Response;
namespace Web_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;
        public UserController(
            IUserService userService)
        {
            _userService = userService;
        }
    
        [HttpPost("authenticate")]
        public ActionResult<AuthenticateResponseViewModel> Authenticate(AuthenticateRequestViewModel model)
        {
            var response = _userService.Authenticate(model, IpAddress());
            SetTokenCookie(response.RefreshToken);
            return Ok(response);
        }
         
        [HttpPost("refresh-token")]
        public ActionResult<AuthenticateResponseViewModel> RefreshToken()
        {
            var refreshToken = Request.Cookies["refreshToken"];
            var response = _userService.RefreshToken(refreshToken, IpAddress());
            SetTokenCookie(response.RefreshToken);
            return Ok(response);
        }
        
        [Authorize(Policy = "SelfOrAdmin")]
        [HttpPost("revoke-token")]
        public IActionResult RevokeToken(RevokeTokenRequestViewModel model)
        {
            // accept token from request body or cookie
            var token = model.Token ?? Request.Cookies["refreshToken"];

            if (string.IsNullOrEmpty(token))
                return BadRequest(new { message = "Token is required" });

            _userService.RevokeToken(token, IpAddress());
            return Ok(new { message = "Token revoked" });
        }
        
        [HttpPost("register")]
        public IActionResult Register(RegisterRequestViewModel model)
        {
            _userService.Register(model, Request.Headers["origin"]);
            return Ok(new { message = "Registration successful, please check your email for verification instructions" });
        }

        [HttpGet("verify-email")]
        public IActionResult VerifyEmail(string token)
        {
            _userService.VerifyEmail(token);
            return Ok(new { message = "Verification successful, you can now login" });
        }

        [HttpPost("forgot-password")]
        public IActionResult ForgotPassword(ForgotPasswordRequestViewModel model)
        {
            _userService.ForgotPassword(model, Request.Headers["origin"]);
            return Ok(new { message = "Please check your email for password reset instructions" });
        }

        [HttpPost("validate-reset-token")]
        public IActionResult ValidateResetToken(ValidateResetTokenRequestViewModel model)
        {
            _userService.ValidateResetToken(model);
            return Ok(new { message = "Token is valid" });
        }

        [HttpPost("reset-password")]
        public IActionResult ResetPassword(ResetPasswordRequestViewModel model)
        {
            _userService.ResetPassword(model);
            return Ok(new { message = "Password reset successful, you can now login" });
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserResponseViewModel>> GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }

        [Authorize(Policy = "SelfOrAdmin")]
        [HttpGet("{userId:int}")]
        public ActionResult<UserResponseViewModel> GetById(int userId)
        {
            var user = _userService.GetById(userId);
            return Ok(user);
        }

        [HttpPost]
        public ActionResult<UserResponseViewModel> Create(CreateRequestViewModel model)
        {
            var user = _userService.Create(model);
            return Ok(user);
        }
        
        
        [Authorize(Policy = "SelfOrAdmin")]
        [HttpPut("{userId:int}")]
        public ActionResult<UserResponseViewModel> Update(int userId, UpdateRequestViewModel model)
        {
            var user = _userService.Update(userId, model);
            return Ok(user);
        }

        [Authorize(Policy = "Admin")]
        [HttpPut("update-role/{userId:int}")]
        public ActionResult<UserResponseViewModel> UpdateRole(int userId, UpdateRoleRequestViewModel model)
        {
            var user = _userService.UpdateRole(userId, model);
            return Ok(user);
        }

        [Authorize(Policy = "SelfOrAdmin")]
        [HttpDelete("{userId:int}")]
        public IActionResult Delete(int userId)
        {
            _userService.Delete(userId);
            return Ok(new { message = "User deleted successfully" });
        }

        // helper methods

        private void SetTokenCookie(string token)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddDays(7)
            };
            Response.Cookies.Append("refreshToken", token, cookieOptions);
        }

        private string IpAddress()
        {
            if (Request.Headers.ContainsKey("X-Forwarded-For"))
                return Request.Headers["X-Forwarded-For"];
            return HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
        }
    }
}