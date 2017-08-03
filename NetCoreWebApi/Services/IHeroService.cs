﻿using NetCoreWebApi.Models;
using System.Collections.Generic;

namespace NetCoreWebApi.Services
{
    public interface IHeroService
    {
		IEnumerable<Hero> GetAll();
		void ClearAll();
		Hero Get(int id);
		void Delete(int id);
		void Add(Hero item);
	}
}
