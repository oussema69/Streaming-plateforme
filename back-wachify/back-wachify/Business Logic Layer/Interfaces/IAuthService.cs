using back_wachify.Business_Logic_Layer.Dto;
using back_wachify.Data.Model;
using back_wachify.Dto;

namespace back_wachify.Business_Logic_Layer.Interfaces
{
    public interface IAuthService
    {
        bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt);
        void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
        string CreateToken(User user);
        void SetRefreshToken(User user, RefreshToken newRefreshToken);
        RefreshToken GenerateRefreshToken(User user);
        Task<User> RegisterUser(UserDto request);
        Task<(string Token, bool IsPasswordWrong)> login(AuthDto request);
        Task<(string Token, string Message)> RefreshToken(string refreshToken);
    }
}
