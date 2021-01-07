using System.Collections.Generic;
using System.Threading.Tasks;
using WebREST_EF_50.Models;

namespace WebREST_EF_50.Services.Users
{
    public interface IUserService
    {
        public Task<List<User.Full>> GetUsers();
        public Task<User.Full> GetOUserById(int id);
        public Task<User.Full> FindOneUserById(string query);
        public Task<User.Full?> PostOneUser(User user);
        public Task<User.Full?> UpdateOneUser(User user);
        public Task<int> DeleteOneUser(int id);
    }
}