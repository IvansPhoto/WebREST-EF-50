using System.Collections.Generic;
using System.Threading.Tasks;
using WebREST_EF_50.Models;

namespace WebREST_EF_50.Services
{
	public interface IObjectiveService
	{
		public Task<List<Objective>> GetAllObjectives(int limit, string query);
		public Task<List<Objective>> GetAllObjectivesById(int id, int limit, string query);
		public Task<Objective> GetOneObjective(int id);
		public Task<Objective> PostOneObjective(Objective objective);
		public Task<Objective> UpdateOneObjective(Objective objective);
		public Task<int> DeleteOneObjective(int id);
	}
}