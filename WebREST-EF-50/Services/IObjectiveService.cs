using System.Collections.Generic;
using System.Threading.Tasks;
using WebREST_EF_50.Models;

namespace WebREST_EF_50.Services
{
	public interface IObjectiveService
	{
		public Task<List<Objective>> GetObjectives(int limit, string query);
		public Task<List<Objective>> GetOneObjective(int id);
		public Task<Objective> PostOneObjective(Objective objective);
		public Task<List<Objective>> UpdateOneObjective(Objective objective);
		public Task<bool> DeleteOneObjective(int id);
	}
}