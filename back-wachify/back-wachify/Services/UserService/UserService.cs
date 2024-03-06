using System.Security.Claims;

namespace back_wachify.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public string GetMyName()
        {
            var result = string.Empty;
            if (_httpContextAccessor.HttpContext != null)
            {
                result = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
            }
            return result;
        }
        public string GenerateRandomCode()
        {
            Random random = new Random();
            int code = random.Next(00000, 99999); // Génère un nombre aléatoire entre 10000 et 99999

            return code.ToString();
        }

    }

}
