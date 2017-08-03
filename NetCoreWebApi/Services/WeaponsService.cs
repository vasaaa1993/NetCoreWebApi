using NetCoreWebApi.Data;
using NetCoreWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NetCoreWebApi.Services
{
	public class WeaponsService : IDisposable
	{

		HeroesContext _context;

		public WeaponsService(HeroesContext context)
		{
			_context = context;
		}

		public IEnumerable<Weapon> GetAll()
		{
			return _context.Weapons.ToList();
		}

		public void Add(Weapon item)
		{
			_context.Weapons.Add(item);
			_context.SaveChanges();
		}

		public void ClearAll()
		{
			_context.Weapons.RemoveRange(_context.Weapons);
			_context.SaveChanges();
		}

		public void Delete(int id)
		{
			var weapon = _context.Weapons.FirstOrDefault(w => w.WeaponId == id);
			if (weapon != null)
				_context.Weapons.Remove(weapon);
			_context.SaveChanges();
		}

		public Weapon Get(int id)
		{
			return _context.Weapons.FirstOrDefault(w => w.WeaponId == id);
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
