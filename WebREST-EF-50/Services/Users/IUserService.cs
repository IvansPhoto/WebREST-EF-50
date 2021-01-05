using System.Collections.Generic;
using System.Threading.Tasks;
using WebREST_EF_50.Models;

namespace WebREST_EF_50.Services.Users
{
    public interface IUserService
    {
        public Task<List<User>> GetUsers();
        public Task<User> GetOUserById(int id);
        public Task<User> FindOneUserById(string query);
        public Task<User?> PostOneUser(User user);
        public Task<User?> UpdateOneUser(User user);
        public Task<int> DeleteOneUser(int id);
    }
}