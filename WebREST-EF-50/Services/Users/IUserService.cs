using System.Collections.Generic;
using System.Threading.Tasks;
using WebREST_EF_50.Models;

namespace WebREST_EF_50.Services.Users
{
    public interface IUserService
    {
        public Task<List<IUserFull>> GetUsers();
        public Task<IUserFull> GetOUserById(int id);
        public Task<IUserFull> FindOneUserById(string query);
        public Task<IUserFull?> PostOneUser(IUserBase user);
        public Task<IUserFull?> UpdateOneUser(IUserBase user);
        public Task<int> DeleteOneUser(int id);
    }
}