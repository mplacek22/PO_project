using System.ComponentModel.DataAnnotations;

namespace PO_project.Models
{
	public class Olimpiada
	{
		public int Id { get; set; }

		[Required]
		[MaxLength(50)]
		public string Name { get; set; }
	}
}
