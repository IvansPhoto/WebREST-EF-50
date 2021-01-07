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

		public async Task<List<IUserFull>> GetUsers()
		{
			return await _dataContext.Users
				.Include(u => u.Phones)
				.Include(u => u.Emails)
				.ToListAsync();
		}

		public async Task<IUserFull> GetOUserById(int id)
		{
			// TODO: Single vs. split queries.
			// https://docs.microsoft.com/en-us/ef/core/querying/related-data/eager#single-and-split-queries
			// https://go.microsoft.com/fwlink/?linkid=2134277
			return await _dataContext.Users
				.Include(u => u.Phones)
				.Include(u => u.Emails)
				.FirstOrDefaultAsync(u => u.Id == id);
		}

		public async Task<IUserFull> FindOneUserById(string query)
		{
			return await _dataContext.Users
				.Include(u => u.Phones)
				.Include(u => u.Emails)
				.FirstOrDefaultAsync(u => u.Name.Contains(query) || u.Surname.Contains(query));
		}

		public async Task<IUserFull?> PostOneUser(IUserBase user)
		{
			var newUser = await _dataContext.Users.AddAsync(new UserFull(user));
			var rows = await _dataContext.SaveChangesAsync();
			return rows == 0 ? null : newUser.Entity;
		}

		public async Task<IUserFull?> UpdateOneUser(IUserBase user)
		{
			var updatedUser = _dataContext.Users.Update(new UserFull(user));
			var rows = await _dataContext.SaveChangesAsync();
			return rows == 0 ? null : updatedUser.Entity;
		}

		public async Task<int> DeleteOneUser(int id)
		{
			_dataContext.Users.Remove(
				await _dataContext.Users.FirstOrDefaultAsync(u => u.Id == id)
			);
			return await _dataContext.SaveChangesAsync();
		}
	}
}