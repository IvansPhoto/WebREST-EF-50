using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebREST_EF_50.Models;

namespace WebREST_EF_50.Services
{
    public interface IUserService
    {
        public Task<List<User>> GetUsers();
        public Task<User> GetOneUser(int? id, string? query);
        public Task<int> PostOneUser(User user);
        public Task<int> UpdateOneUser(User user);
        public Task<int> DeleteOneUser(int id);
    }
}