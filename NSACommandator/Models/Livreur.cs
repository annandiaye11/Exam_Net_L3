namespace NSACommandator.Models
{
    public class Livreur
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Telephone { get; set; }
        public ICollection<Commande> Commandes { get; set; }

    }
}
