using NetCoreWebApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetCoreWebApi.Services
{
    public interface IHeroService
    {
		Task<IEnumerable<Hero>> GetAll();
		Task<int> ClearAll();
		Task<Hero> Get(int id);
		Task<int> Delete(int id);
		Task<int> Add(Hero item);
	}
}
