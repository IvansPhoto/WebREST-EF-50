using System.Collections.Generic;
using System.Threading.Tasks;
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

        public async Task<List<Objective>> GetAllObjectives(int limit, string query)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Objective>> GetAllObjectivesById(int id, int limit, string query)
        {
            throw new System.NotImplementedException();
        }

        public Task<Objective> GetOneObjective(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Objective> PostOneObjective(Objective objective)
        {
            throw new System.NotImplementedException();
        }

        public Task<Objective> UpdateOneObjective(Objective objective)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> DeleteOneObjective(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}