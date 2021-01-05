using System.Collections.Generic;
using System.Threading.Tasks;
using WebREST_EF_50.Models;

namespace WebREST_EF_50.Services.Projects
{
    public interface IProjectService
    {
        public Task<List<Project>> GetProjectsByRelatedId(
            int skipRecords, int perPage, int userId = 0, int companyId = 0, int employeeId = 0
        );

        public Task<List<Project>> GetProjectsByQuery(int skipRecords, int perPage, string query);
        public Task<List<Project>> GetAllProjects(int skipRecords, int perPage);
        public Task<Project> GetOneProject(int id);
        public Task<Project?> AddProjects(Project company);
        public Task<Project?> UpdateProject(Project company);
        public Task<int> DeleteProject(int id);
    }
}