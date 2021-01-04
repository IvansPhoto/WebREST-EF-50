using System.Collections.Generic;
using System.Threading.Tasks;
using WebREST_EF_50.Models;

namespace WebREST_EF_50.Services
{
    public interface IPhonesEmailService
    {
        public Task<List<Phone>> GetPhones(int id);
        public Task<int> AddPhone(Phone phone);
        public Task<int> UpdatePhone(Phone phone);
        public Task<int> DeletePhones(int id);
        public Task<List<Phone>> GetAllPhones();
        
        public Task<List<Email>> GetEmails(int id);
        public Task<int> AddEmails(Email email);
        public Task<int> UpdateEmails(Email email);
        public Task<int> DeleteEmails(int id);
        public Task<List<Email>> GetAllEmails();
    }
}