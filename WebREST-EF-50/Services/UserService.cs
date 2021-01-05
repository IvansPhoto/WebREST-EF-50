using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebREST_EF_50.Data;
using WebREST_EF_50.Models;

namespace WebREST_EF_50.Services
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

        public async Task<User> GetOneUser(int id)
        {
            //Single vs. split queries.
            //https://docs.microsoft.com/en-us/ef/core/querying/related-data/eager#single-and-split-queries
            return await _dataContext.Users
                .Include(u => u.Phones)
                .Include(u => u.Emails)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User> FindUser(string query)
        {
            return await _dataContext.Users
                .Include(u => u.Phones)
                .Include(u => u.Emails)
                .FirstOrDefaultAsync(u => u.Name.Contains(query) || u.Surname.Contains(query));
        }

        public async Task<int> PostOneUser(User user)
        {
            await _dataContext.Users.AddAsync(user);
            return await _dataContext.SaveChangesAsync();
        }

        public async Task<int> UpdateOneUser(User user)
        {
            User updatingUser = await _dataContext.Users.FirstOrDefaultAsync(u => u.Id == user.Id);
            updatingUser.Name = user.Name;
            updatingUser.Surname = user.Surname;
            updatingUser.Phones = user.Phones;
            updatingUser.Emails = user.Emails;
            _dataContext.Users.Update(updatingUser);
            return await _dataContext.SaveChangesAsync();
        }

        public async Task<int> DeleteOneUser(int id)
        {
            User removingUser = await _dataContext.Users.FirstOrDefaultAsync(u => u.Id == id);
            _dataContext.Users.Remove(removingUser);
            return await _dataContext.SaveChangesAsync();
        }
    }
}