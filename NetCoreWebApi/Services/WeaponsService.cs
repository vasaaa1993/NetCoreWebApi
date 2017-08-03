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

		public async Task<bool> ClearAll()
		{
			return await Task.Run(() => {
				_context.Weapons.RemoveRange(_context.Weapons);
				return true;
			});
		}

		public async Task<Weapon> Get(int id)
		{
			return await _context.Weapons.FirstOrDefaultAsync(w => w.WeaponId == id);
		}

		public async Task<bool> Delete(int id)
		{
			var weapon = await _context.Weapons.FirstOrDefaultAsync(w => w.WeaponId == id);
			return await Task.Run(() =>
			{
				if (weapon != null)
				{
					_context.Weapons.Remove(weapon);
					return true;
				}
				return false;
			});

		}

		public async Task<Weapon> Add(Weapon item)
		{
			return await Task.Run(() => { return item != null ? _context.Weapons.Add(item).Entity : null; });
		}

		private bool _disposed;

		public virtual void Dispose(bool disposing)
		{
			if (!_disposed)
			{
				//if (disposing)
				//{
				//	_ctx.Dispose();
				//}
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
