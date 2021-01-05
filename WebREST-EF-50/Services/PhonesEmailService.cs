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

        public async Task<Phone> GetOnePhone(int id)
        {
            return await _dataContext.Phones.FirstOrDefaultAsync((phone) => phone.Id == id);
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



        public async Task<Email> GetOneEmail(int id)
        {
            return await _dataContext.Emails.FirstOrDefaultAsync(email => email.Id == id);
        }

        public async Task<int> AddEmail(Email email)
        {
            await _dataContext.Emails.AddAsync(email);
            return await _dataContext.SaveChangesAsync();
        }

        public async Task<int> UpdateEmail(Email email)
        {
            _dataContext.Emails.Update(email);
            return await _dataContext.SaveChangesAsync();
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