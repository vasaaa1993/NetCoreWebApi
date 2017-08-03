using NetCoreWebApi.Data;
using NetCoreWebApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace NetCoreWebApi.Services
{
	public class HeroesService : IHeroService
	{
		HeroesContext _context;
		public HeroesService(HeroesContext context)
		{
			_context = context;
		}

		public void Add(Hero item)
		{
			_context.Heroes.Add(item);
			_context.SaveChanges();
		}

		public void ClearAll()
		{
			_context.Heroes.RemoveRange(_context.Heroes);
			_context.SaveChanges();
		}

		public void Delete(int id)
		{
			var hero = _context.Heroes.FirstOrDefault(h => h.HeroId == id);
			if (hero != null)
				_context.Heroes.Remove(hero);
			_context.SaveChanges();
		}

		public Hero Get(int id)
		{
			return _context.Heroes.FirstOrDefault(h => h.HeroId == id);
		}

		public IEnumerable<Hero> GetAll()
		{
			return _context.Heroes.ToList();
		}
	}
}
