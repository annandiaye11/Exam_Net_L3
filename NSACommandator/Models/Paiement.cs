namespace NSACommandator.Models
{
    public class Paiement
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Reference { get; set; }
        public Facture Facture { get; set; }
    }
}
