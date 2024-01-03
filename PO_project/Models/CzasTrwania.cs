using System.ComponentModel.DataAnnotations;

namespace PO_project.Models
{
	public class CzasTrwania
	{
		public int Id { get; set; }

		[Required]
		public double Value { get; set; }
	}
}
