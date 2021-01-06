using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebREST_EF_50.Data;
using WebREST_EF_50.Models;

namespace WebREST_EF_50.Services.Users
{
    public class UserService : IUserService
    {
        private readonly DataContext _dataContext;

        public UserService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<User>> GetUsers()
        {
            return await _dataContext.Users
                .Include(u => u.Phones)
                .Include(u => u.Emails)
                .ToListAsync();
        }

        public async Task<User> GetOUserById(int id)
        {
            // TODO: Single vs. split queries.
            // https://docs.microsoft.com/en-us/ef/core/querying/related-data/eager#single-and-split-queries
            // https://go.microsoft.com/fwlink/?linkid=2134277
            return await _dataContext.Users
                .Include(u => u.Phones)
                .Include(u => u.Emails)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User> FindOneUserById(string query)
        {
            return await _dataContext.Users
                .Include(u => u.Phones)
                .Include(u => u.Emails)
                .FirstOrDefaultAsync(u => u.Name.Contains(query) || u.Surname.Contains(query));
        }

        public async Task<User?> PostOneUser(User user)
        {
            var newUser = await _dataContext.Users.AddAsync(user);
            var rows = await _dataContext.SaveChangesAsync();
            return rows == 0 ? null : newUser.Entity;
        }

        public async Task<User?> UpdateOneUser(User user)
        {
            var updatedUser = _dataContext.Users.Update(user);
            var rows = await _dataContext.SaveChangesAsync();
            return rows == 0 ? null : updatedUser.Entity;
        }

        public async Task<int> DeleteOneUser(int id)
        {
            User removingUser = await _dataContext.Users.FirstOrDefaultAsync(u => u.Id == id);
            _dataContext.Users.Remove(removingUser);
            return await _dataContext.SaveChangesAsync();
        }
    }
}