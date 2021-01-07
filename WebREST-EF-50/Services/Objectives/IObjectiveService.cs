using System.Collections.Generic;
using System.Threading.Tasks;
using WebREST_EF_50.Models;

namespace WebREST_EF_50.Services.Objectives
{
    public interface IObjectiveService
    {
        public Task<List<Objective.Full>> GetAllObjectives(string query, int skipRecords, int perPage);

        public Task<List<Objective.Full>> GetRelatedObjectives(
            int skipRecords, int perPage, int userId = 0, int companyId = 0, int employeeId = 0, int projectId = 0
        );

        public Task<Objective.Full> GetOneObjectiveById(int id);
        public Task<Objective.Full?> PostOneObjective(Objective objectiveBase);
        public Task<Objective.Full?> UpdateOneObjective(Objective objectiveBase);
        public Task<int> DeleteOneObjective(int id);
    }
}