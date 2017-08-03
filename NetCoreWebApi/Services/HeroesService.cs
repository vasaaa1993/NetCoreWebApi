using Microsoft.EntityFrameworkCore;
using NetCoreWebApi.Data;
using NetCoreWebApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreWebApi.Services
{
	public class HeroesService : IHeroService
	{
		HeroesContext _context;
		public HeroesService(HeroesContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Hero>> GetAll()
		{
			return await _context.Heroes.ToArrayAsync();
		}

		public async Task<bool> ClearAll()
		{
			return await Task.Run(() => {
				_context.Heroes.RemoveRange(_context.Heroes);
				return true;
			});
		}

		public async Task<Hero> Get(int id)
		{
			return await _context.Heroes.FirstOrDefaultAsync(h => h.HeroId == id);
		}

		public async Task<bool> Delete(int id)
		{
			var hero = await _context.Heroes.FirstOrDefaultAsync(h => h.HeroId == id);
			return await Task.Run(() =>
			{
				if (hero != null)
				{
					_context.Heroes.Remove(hero);
					return true;
				}
				return false;
			});

		}

		public async Task<Hero> Add(Hero item)
		{
			return await Task.Run(() => { return item != null ? _context.Heroes.Add(item).Entity : null; });
		}

	}
}
