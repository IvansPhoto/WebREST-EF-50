using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
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
            throw new System.NotImplementedException();
        }

        public async Task<int> DeletePhones(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<Phone>> GetAllPhones()
        {
            return await _dataContext.Phones.ToListAsync();
        }

        public async Task<List<Email>> GetEmails(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<int> AddEmails(Email email)
        {
            throw new System.NotImplementedException();
        }

        public async Task<int> UpdateEmails(Email email)
        {
            throw new System.NotImplementedException();
        }

        public async Task<int> DeleteEmails(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<Email>> GetAllEmails()
        {
            return await _dataContext.Emails.ToListAsync();
        }
    }
}