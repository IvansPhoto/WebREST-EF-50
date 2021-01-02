using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebREST_EF_50.Assistants;
using WebREST_EF_50.Data;
using WebREST_EF_50.Models;

namespace WebREST_EF_50.Services
{
    public class UserService : IUserService
    {
        private readonly DataContext _dbContext;

        public UserService(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<User>> GetUsers()
        {
            List<User> users = await _dbContext.Users.ToListAsync();
            return users;
        }

        public async Task<User> GetOneUser(int? id, string? query)
        {
            User user = await _dbContext.Users.FirstOrDefaultAsync(
                u => u.Id == id || u.Name == query || u.Surname == query
            );
            return user;
        }

        public async Task<int> PostOneUser(User user)
        {
            await _dbContext.Users.AddAsync(user);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> UpdateOneUser(User user)
        {
            User updatingUser = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == user.Id);
            updatingUser.Name = user.Name;
            updatingUser.Surname = user.Surname;
            updatingUser.Phones = user.Phones;
            updatingUser.Emails = user.Emails;
            updatingUser.Objectives = user.Objectives;
            updatingUser.Companies = user.Companies;
            updatingUser.Projects = user.Projects;
            updatingUser.Employees = user.Employees;
            _dbContext.Users.Update(updatingUser);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteOneUser(int id)
        {
            User removingUser = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
            _dbContext.Users.Remove(removingUser);
            return await _dbContext.SaveChangesAsync();
        }
    }
}