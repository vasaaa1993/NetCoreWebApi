using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCoreWebApi.Models
{
    public class Hero
    {
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int HeroId { get; set; }
		public string Name { get; set; }
		public int Level { get; set; }
		public IEnumerable<Weapon> Weapon { get; set; }
	}
}
