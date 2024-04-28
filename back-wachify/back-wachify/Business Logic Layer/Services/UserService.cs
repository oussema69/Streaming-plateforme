using AutoMapper;
using back_wachify.Business_Logic_Layer.Dto;
using back_wachify.Data_Layer.Repositroy;
using back_wachify.Model;
using System.Security.Claims;

namespace back_wachify.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;



        public UserService(IHttpContextAccessor httpContextAccessor, IUserRepository userRepository, IMapper mapper)
        {
            _httpContextAccessor = httpContextAccessor;
            _userRepository = userRepository;
            _mapper = mapper;


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
        public async Task UpdateUser(int id, UserUpdateDto entity)
        {
            var user = await _userRepository.FindById(id.ToString());
            if (user != null)
            {
                _mapper.Map(entity, user);
                // Update other properties as needed

                await _userRepository.Update(user);
            }
        }
        public async Task DeleteUser(int id)
        {
            var user = await _userRepository.FindById(id.ToString());
            if (user != null)
            {
                await _userRepository.Delete(user);
            }
            else
            {
                throw new InvalidOperationException("User not found.");
            }
        }
        public async Task<User> findById(int id)
        {
            var user = await _userRepository.FindById(id.ToString());
            if (user != null)
            {
                return user;
            }
            else
            {
                throw new InvalidOperationException("User not found.");
            }
        }
        public async Task<User> findByusername(string username)
        {
            var user = await _userRepository.FindByUsername(username);
            if (user != null)
            {
                return user;
            }
            else
            {
                throw new InvalidOperationException("User not found.");
            }
        }



    }
}
