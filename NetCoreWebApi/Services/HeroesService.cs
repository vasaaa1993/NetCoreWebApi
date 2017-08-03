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

		public async Task<int> ClearAll()
		{
			_context.Heroes.RemoveRange(_context.Heroes);
			return await _context.SaveChangesAsync();
		}

		public async Task<Hero> Get(int id)
		{
			return await _context.Heroes.FirstOrDefaultAsync(h => h.HeroId == id);
		}

		public async Task<int> Delete(int id)
		{
			var hero = await _context.Heroes.FirstOrDefaultAsync(h => h.HeroId == id);
			if (hero != null)
				_context.Heroes.Remove(hero);
			return await _context.SaveChangesAsync();

		}

		public async Task<int> Add(Hero item)
		{
			if (item != null)
				_context.Heroes.Add(item);
			return await _context.SaveChangesAsync();
		}

	}
}
