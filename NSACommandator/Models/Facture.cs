namespace NSACommandator.Models
{
    public class Facture
    {
        public int Id { get; set; }
        public Commande Commande { get; set; } 
        public Paiement Paiement { get; set; }
    }
}
