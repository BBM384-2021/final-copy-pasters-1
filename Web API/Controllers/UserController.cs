using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_API.Entities;
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
        private readonly IMapper _mapper;

        public UserController(
            IUserService userService,
            IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
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
        
        [Helpers.Authorize]
        [HttpPost("revoke-token")]
        public IActionResult RevokeToken(RevokeTokenRequestViewModel model)
        {
            // accept token from request body or cookie
            var token = model.Token ?? Request.Cookies["refreshToken"];

            if (string.IsNullOrEmpty(token))
                return BadRequest(new { message = "Token is required" });

            // users can revoke their own tokens and admins can revoke any tokens
            if (!User.OwnsToken(token) && User.Role != Role.Admin)
                return Unauthorized(new { message = "Unauthorized" });

            _userService.RevokeToken(token, IpAddress());
            return Ok(new { message = "Token revoked" });
        }
        
        [HttpPost("register")]
        public IActionResult Register(RegisterRequestViewModel model)
        {
            _userService.Register(model, Request.Headers["origin"]);
            return Ok(new { message = "Registration successful, please check your email for verification instructions" });
        }

        [HttpPost("verify-email")]
        public IActionResult VerifyEmail(VerifyEmailRequestViewModel model)
        {
            _userService.VerifyEmail(model.Token);
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

        [Helpers.Authorize(Role.Admin)]
        [HttpGet]
        public ActionResult<IEnumerable<UserResponseViewModel>> GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }

        [Helpers.Authorize]
        [HttpGet("{id:int}")]
        public ActionResult<UserResponseViewModel> GetById(int id)
        {
            // users can get their own user and admins can get any user
            if (id != User.Id && User.Role != Role.Admin)
                return Unauthorized(new { message = "Unauthorized" });

            var user = _userService.GetById(id);
            return Ok(user);
        }

        [Helpers.Authorize(Role.Admin)]
        [HttpPost]
        public ActionResult<UserResponseViewModel> Create(CreateRequestViewModel model)
        {
            var user = _userService.Create(model);
            return Ok(user);
        }

        [Helpers.Authorize]
        [HttpPut("{id:int}")]
        public ActionResult<UserResponseViewModel> Update(int id, UpdateRequestViewModel model)
        {
            // users can update their own user and admins can update any user
            if (id != User.Id && User.Role != Role.Admin)
                return Unauthorized(new { message = "Unauthorized" });

            // only admins can update role
            if (User.Role != Role.Admin)
                model.Role = null;

            var user = _userService.Update(id, model);
            return Ok(user);
        }

        [Helpers.Authorize]
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            // users can delete their own user and admins can delete any user
            if (id != User.Id && User.Role != Role.Admin)
                return Unauthorized(new { message = "Unauthorized" });

            _userService.Delete(id);
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