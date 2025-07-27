using Dal.Models;
using Dal.Api;
using BL.Api;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL.Services
{

    public class BLUserService : IBLUser
    {
        private readonly IUser _dalUser;

        public BLUserService(IUser dalUser)
        {
            _dalUser = dalUser;
        }

        public Task<IEnumerable<User>> GetAllAsync() => _dalUser.GetAllAsync();
        public Task<User?> GetByIdAsync(int id) => _dalUser.GetByIdAsync(id);
        public Task AddAsync(User user) => _dalUser.AddAsync(user);
        public Task UpdateAsync(User user) => _dalUser.UpdateAsync(user);
        public Task DeleteAsync(int id) => _dalUser.DeleteAsync(id);
        public Task<User?> GetByEmailAsync(string email) => _dalUser.GetByEmailAsync(email);
    }
}
