using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NSACommandator.Models;

namespace NSACommandator.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Commande> Commandees { get; set; }
        public DbSet<Facture> Features { get; set; }
        public DbSet<Livreur> Livreurs { get; set;}
        public DbSet<Paiement> Piements { get; set; }
        public DbSet<Panier> Paniers { get; set; }
        public DbSet<Produit> Produits { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Client>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nom).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Prenom).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Telephone).HasMaxLength(20);
                entity.Property(e => e.Adresse).HasMaxLength(200);

                // Relation avec Commande
                entity.HasMany(c => c.Commandes)
                      .WithOne(c => c.Client)
                      .HasForeignKey(c => c.Id)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<Commande>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Date).IsRequired();
                entity.Property(e => e.Statut).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Montant).HasColumnType("decimal(18,2)");

                entity.HasOne(c => c.Livreur)
                      .WithMany(l => l.Commandes)
                      .HasForeignKey(c => c.Id)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<Facture>(entity =>
            {
                entity.HasKey(e => e.Id);

                // Relation avec Paiement
                entity.HasOne(f => f.Paiement)
                      .WithOne(p => p.Facture)
                      .HasForeignKey<Paiement>(p => p.Id);
            });

            builder.Entity<Livreur>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nom).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Prenom).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Telephone).IsRequired().HasMaxLength(20);
            });

            builder.Entity<Paiement>(entity =>
            {
                entity.HasKey(e => e.Id);
            });

            builder.Entity<Panier>(entity =>
            {
                entity.HasKey(e => e.Id);

                // Relation avec Produits (many-to-many)
                entity.HasMany(p => p.Produits)
                      .WithMany(p => p.Paniers)
                      .UsingEntity<Dictionary<string, object>>(
                        "PanierProduit",
                        j => j.HasOne<Produit>().WithMany().HasForeignKey("ProduitId"),
                        j => j.HasOne<Panier>().WithMany().HasForeignKey("PanierId"),
                        j =>
                        {
                            j.Property<int>("Quantite");
                            j.HasKey("PanierId", "ProduitId");
                        });
            });

            builder.Entity<Produit>(entity =>
            {
                entity.HasKey(e => e.Id);
            });
        }
    }
}

