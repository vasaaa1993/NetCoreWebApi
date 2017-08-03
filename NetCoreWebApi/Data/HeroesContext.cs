using Microsoft.EntityFrameworkCore;
using NetCoreWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreWebApi.Data
{
    public class HeroesContext: DbContext
    {
		public HeroesContext(DbContextOptions<HeroesContext> options)
            : base(options)
        { }

		public DbSet<Hero> Heroes { get; set; }
		public DbSet<Weapon> Weapons { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Hero>().HasMany<Weapon>();
		}
	}
}
