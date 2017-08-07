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
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Gebruiker> Gebruikers { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Gebruiker>(MapGebruiker);
        }

        private static void MapGebruiker(EntityTypeBuilder<Gebruiker> gebruiker)
        {
            gebruiker.ToTable("Gebruiker");
            gebruiker.HasKey(g => g.Id);

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
    }
}