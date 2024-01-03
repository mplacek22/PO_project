using System.ComponentModel.DataAnnotations;

namespace PO_project.Models
{
	public class CzasTrwania
	{
		public int Id { get; set; }

		[Required]
		[MaxLength(3)]
		public string Name { get; set; }
	}
}
