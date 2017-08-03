using NetCoreWebApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetCoreWebApi.Services
{
    public interface IHeroService
    {
		Task<IEnumerable<Hero>> GetAll();
		Task<bool> ClearAll();
		Task<Hero> Get(int id);
		Task<bool> Delete(int id);
		Task<Hero> Add(Hero item);
	}
}
