using System.ComponentModel.DataAnnotations;

namespace PO_project.Models
{
	public class CzasTrwania
	{
		public int CzasTrwaniaId { get; set; }

		[Required]
		public double Value { get; set; }
	}
}
