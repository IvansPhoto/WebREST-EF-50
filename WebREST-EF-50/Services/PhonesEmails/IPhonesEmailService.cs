using System.Collections.Generic;
using System.Threading.Tasks;
using WebREST_EF_50.Models;

namespace WebREST_EF_50.Services.PhonesEmails
{
    public interface IPhonesEmailService
    {
        public Task<Phone.Full> GetOnePhone(int id);
        public Task<Phone.Full?> AddPhone(Phone phone);
        public Task<Phone.Full?> UpdatePhone(Phone phone);
        public Task<int> DeletePhone(int id);
        public Task<List<Phone.Full>> GetAllPhones(int skip, int perPage);
        
        public Task<Email.Full> GetOneEmail(int id);
        public Task<Email.Full?> AddEmail(Email emailBase);
        public Task<Email.Full?> UpdateEmail(Email emailBase);
        public Task<int> DeleteEmail(int id);
        public Task<List<Email.Full>> GetAllEmails(int skip, int perPage);
    }
}