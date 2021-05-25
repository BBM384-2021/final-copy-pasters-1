using AutoMapper;
using BC = BCrypt.Net.BCrypt;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Web_API.Data;
using Web_API.Entities;
using Web_API.Helpers;
using Web_API.ViewModels.User.Request;
using Web_API.ViewModels.User.Response;
using static System.Enum;

namespace Web_API.Services
{
    public interface IUserService
    {
        AuthenticateResponseViewModel Authenticate(AuthenticateRequestViewModel model, string ipAddress);
        AuthenticateResponseViewModel RefreshToken(string token, string ipAddress);
        void RevokeToken(string token, string ipAddress);
        void Register(RegisterRequestViewModel model, string origin);
        void VerifyEmail(string token);
        void ForgotPassword(ForgotPasswordRequestViewModel model, string origin);
        void ValidateResetToken(ValidateResetTokenRequestViewModel model);
        void ResetPassword(ResetPasswordRequestViewModel model);
        IEnumerable<UserResponseViewModel> GetAll();
        UserResponseViewModel GetById(int id);
        UserResponseViewModel Create(CreateRequestViewModel model);
        UserResponseViewModel Update(int id, UpdateRequestViewModel model);
        public UserResponseViewModel UpdateRole(int id, UpdateRoleRequestViewModel model);
        void Delete(int id);
    }

    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;
        private readonly IEmailService _emailService;
        private readonly AuthorizationHandlerContext _authContext;
        public UserService(
            AppDbContext context,
            IMapper mapper,
            IOptions<AppSettings> appSettings,
            IEmailService emailService)
        {
            _context = context;
            _mapper = mapper;
            _appSettings = appSettings.Value;
            _emailService = emailService;
        }

        public AuthenticateResponseViewModel Authenticate(AuthenticateRequestViewModel model, string ipAddress)
        {
            var user = _context.Users.SingleOrDefault(x => x.Email == model.Email);

            if (user == null || !user.IsVerified || !BC.Verify(model.Password, user.PasswordHash))
                throw new AppException("Email or password is incorrect");

            // authentication successful so generate jwt and refresh tokens
            var jwtToken = GenerateJwtToken(user);
            var refreshToken = GenerateRefreshToken(ipAddress);
            user.RefreshTokens.Add(refreshToken);

            // remove old refresh tokens from user
            RemoveOldRefreshTokens(user);

            // save changes to db
            _context.Update(user);
            _context.SaveChanges();

            var response = _mapper.Map<AuthenticateResponseViewModel>(user);
            response.JwtToken = jwtToken;
            response.RefreshToken = refreshToken.Token;
            return response;
        }

        public AuthenticateResponseViewModel RefreshToken(string token, string ipAddress)
        {
            var (refreshToken, user) = GetRefreshToken(token);

            // replace old refresh token with a new one and save
            var newRefreshToken = GenerateRefreshToken(ipAddress);
            refreshToken.Revoked = DateTime.UtcNow;
            refreshToken.RevokedByIp = ipAddress;
            refreshToken.ReplacedByToken = newRefreshToken.Token;
            user.RefreshTokens.Add(newRefreshToken);

            RemoveOldRefreshTokens(user);

            _context.Update(user);
            _context.SaveChanges();

            // generate new jwt
            var jwtToken = GenerateJwtToken(user);

            var response = _mapper.Map<AuthenticateResponseViewModel>(user);
            response.JwtToken = jwtToken;
            response.RefreshToken = newRefreshToken.Token;
            return response;
        }

        public void RevokeToken(string token, string ipAddress)
        {
            var (refreshToken, user) = GetRefreshToken(token);

            // revoke token and save
            refreshToken.Revoked = DateTime.UtcNow;
            refreshToken.RevokedByIp = ipAddress;
            _context.Update(user);
            _context.SaveChanges();
        }

        public void Register(RegisterRequestViewModel model, string origin)
        {
            // validate
            if (_context.Users.Any(x => x.Email == model.Email))
            {
                // send already registered error in email to prevent user enumeration
                SendAlreadyRegisteredEmail(model.Email, origin);
                return;
            }

            // map model to new user object
            var user = _mapper.Map<User>(model);

            // first registered user is an admin
            var isFirstUser = !_context.Users.Any();
            user.Role = isFirstUser ? Role.Admin : Role.User;
            user.Created = DateTime.UtcNow;
            user.VerificationToken = RandomTokenString();

            // hash password
            user.PasswordHash = BC.HashPassword(model.Password);

            // save user
            _context.Users.Add(user);
            _context.SaveChanges();

            // send email
            SendVerificationEmail(user, origin);
        }

        public void VerifyEmail(string token)
        {
            var user = _context.Users.SingleOrDefault(x => x.VerificationToken == token);

            if (user == null) throw new AppException("Verification failed");

            user.Verified = DateTime.UtcNow;
            user.VerificationToken = null;

            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public void ForgotPassword(ForgotPasswordRequestViewModel model, string origin)
        {
            var user = _context.Users.SingleOrDefault(x => x.Email == model.Email);

            // always return ok response to prevent email enumeration
            if (user == null) return;

            // create reset token that expires after 1 day
            user.ResetToken = RandomTokenString();
            user.ResetTokenExpires = DateTime.UtcNow.AddDays(1);

            _context.Users.Update(user);
            _context.SaveChanges();

            // send email
            SendPasswordResetEmail(user, origin);
        }

        public void ValidateResetToken(ValidateResetTokenRequestViewModel model)
        {
            var user = _context.Users.SingleOrDefault(x =>
                x.ResetToken == model.Token &&
                x.ResetTokenExpires > DateTime.UtcNow);

            if (user == null)
                throw new AppException("Invalid token");
        }

        public void ResetPassword(ResetPasswordRequestViewModel model)
        {
            var user = _context.Users.SingleOrDefault(x =>
                x.ResetToken == model.Token &&
                x.ResetTokenExpires > DateTime.UtcNow);

            if (user == null)
                throw new AppException("Invalid token");

            // update password and remove reset token
            user.PasswordHash = BC.HashPassword(model.Password);
            user.PasswordReset = DateTime.UtcNow;
            user.ResetToken = null;
            user.ResetTokenExpires = null;

            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public IEnumerable<UserResponseViewModel> GetAll()
        {
            var users = _context.Users;
            return _mapper.Map<IList<UserResponseViewModel>>(users);
        }

        public UserResponseViewModel GetById(int id)
        {
            var user = GetUser(id);
            return _mapper.Map<UserResponseViewModel>(user);
        }

        public UserResponseViewModel Create(CreateRequestViewModel model)
        {
            // validate
            if (_context.Users.Any(x => x.Email == model.Email))
                throw new AppException($"Email '{model.Email}' is already registered");

            // map model to new user object
            var user = _mapper.Map<User>(model);
            user.Created = DateTime.UtcNow;
            user.Verified = DateTime.UtcNow;

            // hash password
            user.PasswordHash = BC.HashPassword(model.Password);

            // save user
            _context.Users.Add(user);
            _context.SaveChanges();

            return _mapper.Map<UserResponseViewModel>(user);
        }

        public UserResponseViewModel Update(int id, UpdateRequestViewModel model)
        {
            var user = GetUser(id);

            // validate
            if (user.Email != model.Email && _context.Users.Any(x => x.Email == model.Email))
                throw new AppException($"Email '{model.Email}' is already taken");

            // hash password if it was entered
            if (!string.IsNullOrEmpty(model.Password))
                user.PasswordHash = BC.HashPassword(model.Password);

            // copy model to user and save
            _mapper.Map(model, user);
            user.Updated = DateTime.UtcNow;
            _context.Users.Update(user);
            _context.SaveChanges();

            return _mapper.Map<UserResponseViewModel>(user);
        }

        public UserResponseViewModel UpdateRole(int id, UpdateRoleRequestViewModel model)
        {
            var user = GetUser(id);
            var tryParse = TryParse(model.Role, out Role outValue);
            if (!tryParse) return _mapper.Map<UserResponseViewModel>(user);
            
            user.Role = outValue;
            user.Updated = DateTime.UtcNow;

            _context.Users.Update(user);
            _context.SaveChanges();

            return _mapper.Map<UserResponseViewModel>(user);
        }
        

        public void Delete(int id)
        {
            var user = GetUser(id);
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        // helper methods

        private User GetUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null) throw new KeyNotFoundException("User not found");
            return user;
        }

        private (RefreshToken, User) GetRefreshToken(string token)
        {
            var user = _context.Users.SingleOrDefault(u => u.RefreshTokens.Any(t => t.Token == token));
            if (user == null) throw new AppException("Invalid token");
            var refreshToken = user.RefreshTokens.Single(x => x.Token == token);
            if (!refreshToken.IsActive) throw new AppException("Invalid token");
            return (refreshToken, user);
        }

        private string GenerateJwtToken(User user)
        {
            // TODO: these are the necessities to evaluate authorizations.
            var claims = new List<Claim>
            {
                new Claim("Id", user.Id.ToString()),
                new Claim("UserType", user.Role.ToString())
            };

            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(30.0),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        
        private RefreshToken GenerateRefreshToken(string ipAddress)
        {
            return new RefreshToken
            {
                Token = RandomTokenString(),
                Expires = DateTime.UtcNow.AddDays(7),
                Created = DateTime.UtcNow,
                CreatedByIp = ipAddress
            };
        }

        private void RemoveOldRefreshTokens(User user)
        {
            user.RefreshTokens.RemoveAll(x =>
                !x.IsActive &&
                x.Created.AddDays(_appSettings.RefreshTokenTTL) <= DateTime.UtcNow);
        }

        private string RandomTokenString()
        {
            using var rngCryptoServiceProvider = new RNGCryptoServiceProvider();
            var randomBytes = new byte[40];
            rngCryptoServiceProvider.GetBytes(randomBytes);
            // convert random bytes to hex string
            return BitConverter.ToString(randomBytes).Replace("-", "");
        }

        private void SendVerificationEmail(User user, string origin)
        {
            string message;
            if (!string.IsNullOrEmpty(origin))
            {
                var verifyUrl = $"{origin}/api/user/verify-email?token={user.VerificationToken}";
                message = $@"<p>Please click the below link to verify your email address:</p>
                             <p><a href=""{verifyUrl}"">{verifyUrl}</a></p>";
            }
            else
            {
                message =
                    $@"<p>Please use the below token to verify your email address with the <code>/api/user/verify-email</code> api route:</p>
                             <p><code>{user.VerificationToken}</code></p>";
            }

            _emailService.Send(
                to: user.Email,
                subject: "Sign-up Verification API - Verify Email",
                html: $@"<h4>Verify Email</h4>
                         <p>Thanks for registering!</p>
                         {message}"
            );
        }

        private void SendAlreadyRegisteredEmail(string email, string origin)
        {
            string message;
            if (!string.IsNullOrEmpty(origin))
                message =
                    $@"<p>If you don't know your password please visit the <a href=""{origin}/api/user/forgot-password"">forgot password</a> page.</p>";
            else
                message =
                    "<p>If you don't know your password you can reset it via the <code>/api/user/forgot-password</code> api route.</p>";

            _emailService.Send(
                to: email,
                subject: "Sign-up Verification API - Email Already Registered",
                html: $@"<h4>Email Already Registered</h4>
                         <p>Your email <strong>{email}</strong> is already registered.</p>
                         {message}"
            );
        }

        private void SendPasswordResetEmail(User user, string origin)
        {
            string message;
            if (!string.IsNullOrEmpty(origin))
            {
                var resetUrl = $"{origin}/api/user/reset-password?token={user.ResetToken}";
                message =
                    $@"<p>Please click the below link to reset your password, the link will be valid for 1 day:</p>
                             <p><a href=""{resetUrl}"">{resetUrl}</a></p>";
            }
            else
            {
                message =
                    $@"<p>Please use the below token to reset your password with the <code>/api/user/reset-password</code> api route:</p>
                             <p><code>{user.ResetToken}</code></p>";
            }

            _emailService.Send(
                to: user.Email,
                subject: "Sign-up Verification API - Reset Password",
                html: $@"<h4>Reset Password Email</h4>
                         {message}"
            );
        }
    }
}