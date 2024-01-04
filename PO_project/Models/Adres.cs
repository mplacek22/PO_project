namespace PO_project.Models
{
    public class Adres
    {
        public int AdresId {  get; set; }

        public string City { get; set;} = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string PostCode { get; set; } = string.Empty;
        public string BuildingNumber { get; set; } = string.Empty;

        public int? PracodawcaId { get; set; }
        public Pracodawca? Pracodawca { get; set; }
    }
}
