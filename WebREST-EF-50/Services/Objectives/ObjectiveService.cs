using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebREST_EF_50.Data;
using WebREST_EF_50.Models;

namespace WebREST_EF_50.Services.Objectives
{
    public class ObjectiveService : IObjectiveService
    {
        private readonly DataContext _dataContext;

        public ObjectiveService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Objective>> GetAllObjectives(string query, int skipRecords, int perPage)
        {
            return await _dataContext.Objectives
                .Skip(skipRecords)
                .Take(perPage)
                .OrderBy(objective => objective.Id)
                .Where(objective =>
                    objective.Description.Contains(query) ||
                    objective.Title.Contains(query))
                .ToListAsync();
        }

        public async Task<List<Objective>> GetRelatedObjectives(
            int skipRecords, int perPage, int userId = 0, int companyId = 0, int employeeId = 0, int projectId = 0
        )
        {
            return await _dataContext.Objectives
                .Skip(skipRecords)
                .Take(perPage)
                .OrderBy(objective => objective.Id)
                .Where(objective =>
                    objective.Company != null && objective.Company.Id == companyId ||
                    objective.Employee != null && objective.Employee.Id == employeeId ||
                    objective.Project != null && objective.Project.Id == projectId ||
                    objective.ResponsibleUser.Id == userId)
                .ToListAsync();
        }

        public async Task<Objective> GetOneObjectiveById(int id)
        {
            return await _dataContext.Objectives.FirstOrDefaultAsync(objective => objective.Id == id);
        }

        public async Task<Objective?> PostOneObjective(Objective objective)
        {
            // TODO: Check the correctness returning Objective
            var newObj = await _dataContext.Objectives.AddAsync(objective);
            var rows = await _dataContext.SaveChangesAsync();
            return rows == 0 ? null : newObj.Entity;
        }

        public async Task<Objective?> UpdateOneObjective(Objective objective)
        {
            var updatedObj = _dataContext.Objectives.Update(objective);
            var rows = await _dataContext.SaveChangesAsync();
            return rows == 0 ? null : updatedObj.Entity;
        }

        public async Task<int> DeleteOneObjective(int id)
        {
            _dataContext.Objectives.Remove(
                await _dataContext.Objectives.FirstOrDefaultAsync(objective => objective.Id == id)
            );
            return await _dataContext.SaveChangesAsync();
        }
    }
}