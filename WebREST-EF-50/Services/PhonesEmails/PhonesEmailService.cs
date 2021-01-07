using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using WebREST_EF_50.Data;
using WebREST_EF_50.Models;

namespace WebREST_EF_50.Services.PhonesEmails
{
	public class PhonesEmailService : IPhonesEmailService
	{
		private readonly DataContext _dataContext;

		public PhonesEmailService(DataContext dataContext)
		{
			_dataContext = dataContext;
		}

		// Phones
		public async Task<Phone.Full> GetOnePhone(int id)
		{
			return await _dataContext.PhonesFull.FirstOrDefaultAsync((phone) => phone.Id == id);
		}

		public async Task<Phone.Full?> AddPhone(Phone phone)
		{
			var newPhone = await _dataContext.PhonesFull.AddAsync(new Phone.Full(phone));
			var rows = await _dataContext.SaveChangesAsync();
			return rows == 0 ? null : newPhone.Entity;
		}

		public async Task<Phone.Full?> UpdatePhone(Phone phone)
		{
			var updatedEmail = _dataContext.PhonesFull.Update(new Phone.Full(phone));
			var rows = await _dataContext.SaveChangesAsync();
			return rows == 0 ? null : updatedEmail.Entity;
		}

		public async Task<int> DeletePhone(int id)
		{
			_dataContext.PhonesFull.Remove(
				await _dataContext.PhonesFull.FirstOrDefaultAsync(ph => ph.Id == id)
			);
			return await _dataContext.SaveChangesAsync();
		}

		public async Task<List<Phone.Full>> GetAllPhones(int skip, int perPage)
		{
			return await _dataContext.PhonesFull
				.Skip(skip)
				.Take(perPage)
				.ToListAsync();
		}


		// Emails
		public async Task<Email.Full> GetOneEmail(int id)
		{
			return await _dataContext.EmailsFull.FirstOrDefaultAsync(email => email.Id == id);
		}

		public async Task<Email.Full?> AddEmail(Email emailBase)
		{
			var newEmail = await _dataContext.EmailsFull.AddAsync(new Email.Full(emailBase));
			var rows = await _dataContext.SaveChangesAsync();
			return rows == 0 ? null : newEmail.Entity;
		}

		public async Task<Email.Full?> UpdateEmail(Email emailBase)
		{
			var updatedEmail = _dataContext.EmailsFull.Update(new Email.Full(emailBase));
			var rows = await _dataContext.SaveChangesAsync();
			return rows == 0 ? null : updatedEmail.Entity;
		}

		public async Task<int> DeleteEmail(int id)
		{
			_dataContext.EmailsFull.Remove(
				await _dataContext.EmailsFull.FirstOrDefaultAsync(email1 => email1.Id == id)
			);
			return await _dataContext.SaveChangesAsync();
		}

		public async Task<List<Email.Full>> GetAllEmails(int skip, int perPage)
		{
			return await _dataContext.EmailsFull
				.Skip(skip)
				.Take(perPage)
				.ToListAsync();
		}
	}
}