using back_wachify.Business_Logic_Layer.Dto;
using back_wachify.Data;
using back_wachify.Data.Model;
using back_wachify.Dto;
using back_wachify.Migrations;
using back_wachify.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace back_wachify.Data_Layer.Repositroy
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public UserRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

        }

        public async Task<User> add(User user)
        {
            try
            {
                // Add the user entity to the DbContext
                _dbContext.User.Add(user);

                // Save changes to the database
                await _dbContext.SaveChangesAsync();

                // Return the user entity as part of the response
                return user;

            }
            catch
            {
                return null;
            }


        }

        public async Task<User> FindByUsername(string username)
        {
            return await _dbContext.User.FirstOrDefaultAsync(u => u.Username == username);

        }
        public async Task<User> FindById(string id)
        {
            return await _dbContext.User.FirstOrDefaultAsync(u => u.Id.ToString() == id);

        }


        public async Task<User> GetUserByRefreshTokenAsync(string refreshToken)
        {
            return await _dbContext.User.FirstOrDefaultAsync(u => u.RefreshToken == refreshToken);
        }

        public async Task<IEnumerable<User>> Get()
        {
            var users = await _dbContext.User.ToListAsync();

            return users;
        }

        public async Task Update(User entity)
        {
           
              
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();


        }

        public async Task Delete(User user)
        {
            
                _dbContext.User.Remove(user);
                await _dbContext.SaveChangesAsync();
            
        }
    }
}
