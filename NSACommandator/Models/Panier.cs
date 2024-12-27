namespace NSACommandator.Models
{
    public class Panier
    {
        public int Id { get; set; }
        public Produit Produit { get; set; }
        public Commande Commande { get; set; }
        public int Quantite { get; set; }
        public int Prix {  get; set; }

    }
}
