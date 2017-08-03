using NetCoreWebApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace NetCoreWebApi.Data
{
	public static class HeroesDbInitializer
	{
		public static void Initialize(HeroesContext context)
		{
			context.Database.EnsureCreated();

			if (context.Heroes.Any())
			{
				return; // Db was initialized
			}

			var heroes = new List<Hero>()
			{
				new Hero(){Level = 100, Name="Hulk" },
				new Hero(){Level = 90, Name="Zeus", Weapon = new List<Weapon>()
				{
					new Weapon() { Name = "Dragon", Damage = 50 },
					new Weapon() {  Name="LightBall", Damage= 45} }
				},
				new Hero(){Level = 80, Name="Osiris", Weapon = new List<Weapon>(){ new Weapon() { Name = "Lightning", Damage=45} } },
				new Hero(){Level = 70, Name="Tor", Weapon = new List<Weapon>(){ new Weapon() { Name = "Hummer", Damage=55} } },
				new Hero(){Level = 60, Name="Spiderman", Weapon = new List<Weapon>(){ new Weapon() { Name = "Spider web", Damage=30} } }
			};

			foreach (var hero in heroes)
				context.Heroes.Add(hero);

			var weapons = new List<Weapon>()
			{
				new Weapon(){ Name="Anduil", Damage=50},
				new Weapon(){ Name="Sting", Damage=30}
			};

			foreach (var weapon in weapons)
				context.Weapons.Add(weapon);

			context.SaveChanges();
		}
	}
}
