namespace NSACommandator.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Telephone { get; set; }
        public string Adresse { get; set; }
        public ICollection<Panier> Panier { get; set; } 
        public ICollection<Commande> Commandes { get; set; }
    }
}
