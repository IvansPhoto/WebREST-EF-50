using System.Collections.Generic;
using System.Threading.Tasks;
using WebREST_EF_50.Models;

namespace WebREST_EF_50.Services
{
	public class ObjectiveService : IObjectiveService
	{
		public async Task<List<Objective>> GetObjectives(int limit, string query)
		{
			var obj = new Objective(title: "First objective", createDate: new System.DateTime(), finishDate: new System.DateTime(), new User(name: "Jan", surname: "Miller"), description: "A call");
			var objList = new List<Objective>() {obj};
			return objList;
		}

		public Task<List<Objective>> GetOneObjective(int id)
		{
			throw new System.NotImplementedException();
		}

		public Task<Objective> PostOneObjective(Objective objective)
		{
			throw new System.NotImplementedException();
		}

		public Task<List<Objective>> UpdateOneObjective(Objective objective)
		{
			throw new System.NotImplementedException();
		}

		public Task<bool> DeleteOneObjective(int id)
		{
			throw new System.NotImplementedException();
		}
	}
}