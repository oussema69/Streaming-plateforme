using back_wachify.Business_Logic_Layer.Dto;
using back_wachify.Model;

namespace back_wachify.Services.UserService
{
    public interface IUserService
    {
        string GetMyName();
         Task UpdateUser(int id, UserUpdateDto entity);
        Task DeleteUser(int id);
        Task<User> findById(int id);
        Task<User> findByusername(string username);


    }
}

