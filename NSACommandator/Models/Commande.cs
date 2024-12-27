namespace NSACommandator.Models
{
    public class Commande
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Montant { get; set; }
        public String Statut { get; set; }
        public ICollection<Produit> Produits { get; set; }
        public Client Client { get; set; }
        public Livreur Livreur { get; set; }




    }
}
