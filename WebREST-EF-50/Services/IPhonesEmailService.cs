using System.Collections.Generic;
using System.Threading.Tasks;
using WebREST_EF_50.Models;

namespace WebREST_EF_50.Services
{
    public interface IPhonesEmailService
    {
        public Task<Phone> GetOnePhone(int id);
        public Task<int> AddPhone(Phone phone);
        public Task<int> UpdatePhone(Phone phone);
        public Task<int> DeletePhone(int id);
        public Task<List<Phone>> GetAllPhones(int skip, int perPage);
        
        public Task<Email> GetOneEmail(int id);
        public Task<Email?> AddEmail(Email email);
        public Task<Email?> UpdateEmail(Email email);
        public Task<int> DeleteEmail(int id);
        public Task<List<Email>> GetAllEmails(int skip, int perPage);
    }
}