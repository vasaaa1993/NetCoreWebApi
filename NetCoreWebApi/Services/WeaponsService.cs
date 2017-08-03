using Microsoft.EntityFrameworkCore;
using NetCoreWebApi.Data;
using NetCoreWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreWebApi.Services
{
	public class WeaponsService : IDisposable
	{

		HeroesContext _context;

		public WeaponsService(HeroesContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Weapon>> GetAll()
		{
			return await _context.Weapons.ToArrayAsync();
		}

		public async Task<int> ClearAll()
		{
			_context.Weapons.RemoveRange(_context.Weapons);
			return await _context.SaveChangesAsync();
		}

		public async Task<Weapon> Get(int id)
		{
			return await _context.Weapons.FirstOrDefaultAsync(w => w.WeaponId == id);
		}

		public async Task<int> Delete(int id)
		{
			var weapon = await _context.Weapons.FirstOrDefaultAsync(w => w.WeaponId == id);
			if (weapon != null)
				_context.Weapons.Remove(weapon);
			return await _context.SaveChangesAsync();

		}

		public async Task<int> Add(Weapon item)
		{
			if (item != null)
				_context.Weapons.Add(item);
			return await _context.SaveChangesAsync();
		}

		private bool _disposed;

		public virtual void Dispose(bool disposing)
		{
			if (!_disposed)
			{
				if (disposing)
				{
					_context.Dispose();
				}
				_disposed = true;
			}
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}
