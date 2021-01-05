using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebREST_EF_50.Data;
using WebREST_EF_50.Models;

namespace WebREST_EF_50.Services.Projects
{
    public class ProjectService : IProjectService
    {
        private readonly DataContext _dataContext;

        public ProjectService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Project>> GetProjectsByRelatedId(int skipRecords, int perPage, int userId = 0, int companyId = 0, int employeeId = 0)
        {
            return await _dataContext.Projects
                .Skip(skipRecords)
                .Take(perPage)
                .Where(project => companyId != 0 && project.Company != null && project.Company.Id == companyId ||
                                  employeeId != 0 && project.Employee != null && project.Employee.Id == employeeId ||
                                  userId != 0 && project.ResponsibleUser.Id == userId)
                .ToListAsync();
        }

        public async Task<List<Project>> GetProjectsByQuery(int skipRecords, int perPage, string query)
        {
            return await _dataContext.Projects
                .Skip(skipRecords)
                .Take(perPage)
                .Where(project =>
                    project.Title.Contains(query) || 
                    project.Description.Contains(query))
                .ToListAsync();
        }

        public async Task<List<Project>> GetAllProjects(int skipRecords, int perPage)
        {
            return await _dataContext.Projects
                .Skip(skipRecords)
                .Take(perPage)
                .ToListAsync();
        }

        public async Task<Project> GetOneProject(int id)
        {
            return await _dataContext.Projects.FirstOrDefaultAsync(project => project.Id == id);
        }

        public async Task<Project?> AddProjects(Project project)
        {
            var newProject = await _dataContext.Projects.AddAsync(project);
            var rows = await _dataContext.SaveChangesAsync();
            return rows == 0 ? null : newProject.Entity;
        }

        public async Task<Project?> UpdateProject(Project project)
        {
            var updatedProject = _dataContext.Projects.Update(project);
            var rows = await _dataContext.SaveChangesAsync();
            return rows == 0 ? null : updatedProject.Entity;
        }

        public async Task<int> DeleteProject(int id)
        {
            _dataContext.Projects.Remove(
                await _dataContext.Projects.FirstOrDefaultAsync(project => project.Id == id)
            );
            return await _dataContext.SaveChangesAsync();
        }
    }
}