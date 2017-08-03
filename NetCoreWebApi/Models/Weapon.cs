using System.ComponentModel.DataAnnotations.Schema;

namespace NetCoreWebApi.Models
{
    public class Weapon
    {
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int WeaponId { get; set; }
		public string Name { get; set; }
		public int Damage { get; set; }
	}
}
