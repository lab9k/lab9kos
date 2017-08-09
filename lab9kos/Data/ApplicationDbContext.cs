using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using lab9kos.Models;
using lab9kos.Models.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace lab9kos.Data
{
    public class ApplicationDbContext : IdentityDbContext<Gebruiker, IdentityRole<long>, long>
    {
        public DbSet<Gebruiker> Gebruikers { get; set; }
        public DbSet<Taak> Taken { get; set; }
        public DbSet<Werkweek> Werkweken { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Gebruiker>(MapGebruiker);
            builder.Entity<Werkweek>(MapWerkweek);
            builder.Entity<TaakGebruiker>(MapTaakGebruiker);
            builder.Entity<Taak>(MapTaak);
        }

        private static void MapWerkweek(EntityTypeBuilder<Werkweek> werkweek)
        {
            werkweek.ToTable("WerkWeek");
            werkweek.HasKey(w => w.Id);
            
            
        }

        private static void MapGebruiker(EntityTypeBuilder<Gebruiker> gebruiker)
        {
            gebruiker.ToTable("Gebruiker");
            gebruiker.HasMany(g => g.Werkweken)
                .WithOne(w => w.Werknemer)
                .IsRequired(false);

            gebruiker.Property(g => g.Naam)
                .HasMaxLength(25)
                .IsRequired();

            gebruiker.Property(g => g.Voornaam)
                .HasMaxLength(30)
                .IsRequired();

            gebruiker.Property(g => g.Email)
                .HasMaxLength(250)
                .IsRequired();
        }


        private static void MapTaakGebruiker(EntityTypeBuilder<TaakGebruiker> taakGebruiker)
        {
            //http://www.learnentityframeworkcore.com/configuration/many-to-many-relationship-configuration

            taakGebruiker.HasKey(tg => new {tg.GebruikerId, tg.TaakId});
            taakGebruiker.HasOne(tg => tg.Gebruiker)
                .WithMany(g => g.Taken)
                .HasForeignKey(tg => tg.GebruikerId);

            taakGebruiker.HasOne(tg => tg.Taak)
                .WithMany(t => t.Gebruikers)
                .HasForeignKey(tg => tg.TaakId);
        }

        private static void MapTaak(EntityTypeBuilder<Taak> taak)
        {
            taak.ToTable("Taak");
            taak.HasKey(t => t.Id);
            taak.Property(t => t.Titel)
                .IsRequired();
        }
    }
}