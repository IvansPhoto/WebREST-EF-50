using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebREST_EF_50.Data;
using WebREST_EF_50.Models;

namespace WebREST_EF_50.Services
{
    public class ObjectiveService : IObjectiveService
    {
        private DataContext _dataContext;

        public ObjectiveService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Objective>> GetAllObjectives(string query, int skipRecords, int perPage)
        {
            return await _dataContext.Objectives
                .Skip(skipRecords)
                .Take(perPage)
                .Where(objective =>
                    objective.Description.Contains(query) ||
                    objective.Title.Contains(query))
                .ToListAsync();
        }

        public async Task<List<Objective>> GetRelatedObjectives(int id, int skipRecords, int perPage)
        {
            return await _dataContext.Objectives
                .Skip(skipRecords)
                .Take(perPage)
                .Where(objective =>
                    objective.Company != null && objective.Company.Id == id ||
                    objective.Employee != null && objective.Employee.Id == id ||
                    objective.Project != null && objective.Project.Id == id)
                .ToListAsync();
        }

        public async Task<Objective> GetOneObjective(int id)
        {
            return await _dataContext.Objectives.FirstOrDefaultAsync(objective => objective.Id == id);
        }

        public async Task<Objective> PostOneObjective(Objective objective)
        {
            // TODO: Check the correctness returning Objective
            var newObj = await _dataContext.Objectives.AddAsync(objective);
            await _dataContext.SaveChangesAsync();
            return newObj.Entity;
        }

        public async Task<Objective> UpdateOneObjective(Objective objective)
        {
            var updatedObj = _dataContext.Objectives.Update(objective);
            await _dataContext.SaveChangesAsync();
            return updatedObj.Entity;
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