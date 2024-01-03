using System.ComponentModel.DataAnnotations;

namespace PO_project.Models
{
	public class Stopien
	{
		public int Id { get; set; }

		[Required]
		[MaxLength(5)]
		public string Name { get; set; }
	}
}
