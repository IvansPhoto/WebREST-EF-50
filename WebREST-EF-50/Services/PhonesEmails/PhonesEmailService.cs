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
        public async Task<Phone> GetOnePhone(int id)
        {
            return await _dataContext.Phones.FirstOrDefaultAsync((phone) => phone.Id == id);
        }

        public async Task<Phone?> AddPhone(Phone phone)
        {
            var newPhone = await _dataContext.Phones.AddAsync(phone);
            var rows = await _dataContext.SaveChangesAsync(); 
            return rows == 0 ? null : newPhone.Entity;
        }

        public async Task<Phone?> UpdatePhone(Phone phone)
        {
            var updatedEmail = _dataContext.Phones.Update(phone);
            var rows = await _dataContext.SaveChangesAsync(); 
            return rows == 0 ? null : updatedEmail.Entity;
        }

        public async Task<int> DeletePhone(int id)
        {
            Phone phone = await _dataContext.Phones.FirstOrDefaultAsync(ph => ph.Id == id);
            _dataContext.Phones.Remove(phone);
            return await _dataContext.SaveChangesAsync();
        }

        public async Task<List<Phone>> GetAllPhones(int skip, int perPage)
        {
            // Set limits
            return await _dataContext.Phones
                .Skip(skip)
                .Take(perPage)
                .ToListAsync();
        }



        // Emails
        public async Task<Email> GetOneEmail(int id)
        {
            return await _dataContext.Emails.FirstOrDefaultAsync(email => email.Id == id);
        }

        public async Task<Email?> AddEmail(Email email)
        {
            var newEmail = await _dataContext.Emails.AddAsync(email);
            var rows = await _dataContext.SaveChangesAsync();
            return rows == 0 ? null : newEmail.Entity;
        }

        public async Task<Email?> UpdateEmail(Email email)
        {
            var updatedEmail = _dataContext.Emails.Update(email);
            var rows = await _dataContext.SaveChangesAsync();
            return rows == 0 ? null : updatedEmail.Entity;
        }

        public async Task<int> DeleteEmail(int id)
        {
            Email email = await _dataContext.Emails.FirstOrDefaultAsync(email1 => email1.Id == id);
            _dataContext.Emails.Remove(email);
            return await _dataContext.SaveChangesAsync();
        }

        public async Task<List<Email>> GetAllEmails(int skip, int perPage)
        {
            return await _dataContext.Emails
                .Skip(skip)
                .Take(perPage)
                .ToListAsync();
        }
    }
}