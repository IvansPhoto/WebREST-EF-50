using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebREST_EF_50.Data;
using WebREST_EF_50.Models;

namespace WebREST_EF_50.Services
{
    public class PhonesEmailService : IPhonesEmailService
    {
        private readonly DataContext _dataContext;

        public PhonesEmailService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Phone>> GetPhones(int id)
        {
            return await _dataContext.Phones
                .Where((phone) => phone.Company != null && phone.Company.Id == id ||
                                  phone.Employee != null && phone.Employee.Id == id ||
                                  phone.User != null && phone.User.Id == id)
                .ToListAsync();
        }

        public async Task<int> AddPhone(Phone phone)
        {
            await _dataContext.Phones.AddAsync(phone);
            return await _dataContext.SaveChangesAsync();
        }

        public async Task<int> UpdatePhone(Phone phone)
        {
            _dataContext.Phones.Update(phone);
            return await _dataContext.SaveChangesAsync();
        }

        public async Task<int> DeletePhones(int id)
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



        public async Task<List<Email>> GetEmails(int id)
        {
            return await _dataContext.Emails
                .Where(email => 
                    email.Company != null && email.Company.Id == id || 
                    email.Employee != null && email.Employee.Id == id || 
                    email.User != null && email.User.Id == id)
                .ToListAsync();
        }

        public async Task<int> AddEmails(Email email)
        {
            await _dataContext.Emails.AddAsync(email);
            return await _dataContext.SaveChangesAsync();
        }

        public async Task<int> UpdateEmails(Email email)
        {
            _dataContext.Emails.Update(email);
            return await _dataContext.SaveChangesAsync();
        }

        public async Task<int> DeleteEmails(int id)
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