using back_wachify.Business_Logic_Layer.Dto;
using back_wachify.Data.Model;
using back_wachify.Dto;
using back_wachify.Model;
using Microsoft.AspNetCore.Mvc;

namespace back_wachify.Data_Layer.Repositroy
{
    public interface IUserRepository
    {
        Task<User> add(User userDto);
        Task<User> FindByUsername(string username);
        Task<User> GetUserByRefreshTokenAsync(string refreshToken);

    }
}
