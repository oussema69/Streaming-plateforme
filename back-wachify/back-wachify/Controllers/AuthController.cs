using back_wachify.Dto;
using back_wachify.Model;
using back_wachify.Services.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace back_wachify.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;
        private readonly ApplicationDbContext _dbContext; 




        public AuthController(IConfiguration configuration, IUserService userService, ApplicationDbContext dbContext)
        {
            _configuration = configuration;
            _userService = userService;
            _dbContext = dbContext;

        }

        [HttpGet, Authorize]
        public ActionResult<string> GetMe()
        {
            var userName = _userService.GetMyName();
            return Ok(userName);
        }


        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserDto request)
        {
            var user = new User();

            // Generate password hash and salt
            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            // Assign values to the user entity
            user.Username = request.Username;
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.Role = request.Role;
            user.ConfirmationCode = _userService.GenerateRandomCode();
            user.IsEmailConfirmed = false;
            try
            {
                // Add the user entity to the DbContext
                _dbContext.User.Add(user);

                // Save changes to the database
                await _dbContext.SaveChangesAsync();

                // Return the user entity as part of the response
                return Ok(user);
            }
            catch (DbUpdateException ex)
            {
                // Check if the inner exception is a SqlException and if it's a duplicate key violation
                if (ex.InnerException is SqlException sqlEx && sqlEx.Number == 2601)
                {
                    // Log the error for debugging purposes
                    Console.WriteLine($"Duplicate key violation: {ex.InnerException.Message}");

                    // Return a 400 Bad Request status code with a specific error message
                    return BadRequest("This username is already taken. Please choose a different one.");
                }
                else
                {
                    // Log the general exception details for debugging purposes
                    Console.WriteLine($"An error occurred while registering the user: {ex.Message}");

                    // Return a 500 Internal Server Error status code with a generic error message
                    return StatusCode(500, "An error occurred while registering the user.");
                }
            }

        }

        private string GenerateRandomCode()
        {
            throw new NotImplementedException();
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(UserDto request)
        {
            var user = await _dbContext.User.FirstOrDefaultAsync(u => u.Username == request.Username);

            if (user == null)
            {
                return BadRequest("User not found.");
            }

            if (!VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                return BadRequest("Wrong password.");
            }

            string token = CreateToken(user);

            var refreshToken = GenerateRefreshToken(user);
            SetRefreshToken(user, refreshToken);

            return Ok(token);
        }

        [HttpPost("refresh-token")]
        public async Task<ActionResult<string>> RefreshToken()
        {
            var refreshToken = Request.Cookies["refreshToken"];

            var user = await _dbContext.User.FirstOrDefaultAsync(u => u.RefreshToken == refreshToken);

            if (user == null)
            {
                return Unauthorized("Invalid Refresh Token.");
            }
            else if (user.TokenExpires < DateTime.Now)
            {
                return Unauthorized("Token expired.");
            }

            string token = CreateToken(user);
            var newRefreshToken = GenerateRefreshToken(user);
            SetRefreshToken(user, newRefreshToken);

            return Ok(token);
        }

        private RefreshToken GenerateRefreshToken(User user)
        {
            var refreshToken = new RefreshToken
            {
                Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
                Expires = DateTime.Now.AddDays(7),
                Created = DateTime.Now
            };

            // Update user's refresh token in the database
            user.RefreshToken = refreshToken.Token;
            user.TokenCreated = refreshToken.Created;
            user.TokenExpires = refreshToken.Expires;
            _dbContext.SaveChanges();

            return refreshToken;
        }

        private void SetRefreshToken(User user, RefreshToken newRefreshToken)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = newRefreshToken.Expires
            };
            Response.Cookies.Append("refreshToken", newRefreshToken.Token, cookieOptions);

            // Update user's refresh token in the database
            user.RefreshToken = newRefreshToken.Token;
            user.TokenCreated = newRefreshToken.Created;
            user.TokenExpires = newRefreshToken.Expires;
            _dbContext.SaveChanges();
        }


        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }
    }
}
