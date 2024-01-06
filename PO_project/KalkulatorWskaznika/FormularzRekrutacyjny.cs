using System.ComponentModel.DataAnnotations.Schema;

namespace PO_project.KalkulatorWskaznika
{
	public class FormularzRekrutacyjny
	{
		[NotMapped]
		public (string, double)[] WskaznikiRekrutacyjne { get; set; }
	}
}
