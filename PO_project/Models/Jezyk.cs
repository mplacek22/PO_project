using System.ComponentModel.DataAnnotations;

namespace PO_project.Models
{
	public class Jezyk
	{
		public int JezykId { get; set; }

		[Required]
		[MaxLength(40)]
		public string Name { get; set; } =	string.Empty;
	}
}
