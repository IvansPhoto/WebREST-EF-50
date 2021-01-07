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

		public async Task<List<User.Full>> GetUsers()
		{
			return await _dataContext.UsersFull
				.Include(u => u.Phones)
				.Include(u => u.Emails)
				.ToListAsync();
		}

		public async Task<User.Full> GetOUserById(int id)
		{
			// TODO: Single vs. split queries.
			// https://docs.microsoft.com/en-us/ef/core/querying/related-data/eager#single-and-split-queries
			// https://go.microsoft.com/fwlink/?linkid=2134277
			return await _dataContext.UsersFull
				.Include(u => u.Phones)
				.Include(u => u.Emails)
				.FirstOrDefaultAsync(u => u.Id == id);
		}

		public async Task<User.Full> FindOneUserById(string query)
		{
			return await _dataContext.UsersFull
				.Include(u => u.Phones)
				.Include(u => u.Emails)
				.FirstOrDefaultAsync(u => u.Name.Contains(query) || u.Surname.Contains(query));
		}

		public async Task<User.Full?> PostOneUser(User user)
		{
			var newUser = await _dataContext.UsersFull.AddAsync(new User.Full(user));
			var rows = await _dataContext.SaveChangesAsync();
			return rows == 0 ? null : newUser.Entity;
		}

		public async Task<User.Full?> UpdateOneUser(User user)
		{
			var updatedUser = _dataContext.UsersFull.Update(new User.Full(user));
			var rows = await _dataContext.SaveChangesAsync();
			return rows == 0 ? null : updatedUser.Entity;
		}

		public async Task<int> DeleteOneUser(int id)
		{
			_dataContext.UsersFull.Remove(
				await _dataContext.UsersFull.FirstOrDefaultAsync(u => u.Id == id)
			);
			return await _dataContext.SaveChangesAsync();
		}
	}
}