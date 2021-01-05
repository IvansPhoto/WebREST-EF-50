using System.Collections.Generic;
using System.Threading.Tasks;
using WebREST_EF_50.Models;

namespace WebREST_EF_50.Services.Objectives
{
    public interface IObjectiveService
    {
        public Task<List<Objective>> GetAllObjectives(string query, int skipRecords, int perPage);

        public Task<List<Objective>> GetRelatedObjectives(
            int skipRecords, int perPage, int userId = 0, int companyId = 0, int employeeId = 0, int projectId = 0
        );

        public Task<Objective> GetOneObjectiveById(int id);
        public Task<Objective?> PostOneObjective(Objective objective);
        public Task<Objective?> UpdateOneObjective(Objective objective);
        public Task<int> DeleteOneObjective(int id);
    }
}