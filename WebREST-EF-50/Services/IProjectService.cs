using System.Collections.Generic;
using System.Threading.Tasks;
using WebREST_EF_50.Models;

namespace WebREST_EF_50.Services
{
    public interface IProjectService
    {
        public Task<List<Project>> GetProjectsById(int id, int skipRecords, int perPage);
        public Task<List<Project>> GetAllProjects(int skipRecords, int perPage);
        public Task<Project> GetOneProject(int id);
        public Task<Project> AddProjects(Project company);
        public Task<Project> UpdateProject(Project company);
        public Task<int> DeleteProject(int id);
    }
}