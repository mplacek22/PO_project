using System.ComponentModel.DataAnnotations;

namespace PO_project.Models
{
	public class Lokalizacja
	{
		public int LokalizacjaId { get; set; }

		[Required]
		[MaxLength(40)]
		public string Name { get; set; }
	}
}
