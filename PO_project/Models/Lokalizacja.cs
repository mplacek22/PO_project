using System.ComponentModel.DataAnnotations;

namespace PO_project.Models
{
	public class Lokalizacja
	{
		public int LokalizacjaId { get; set; }

		public String Name { get; set; } = String.Empty;
	}
}
