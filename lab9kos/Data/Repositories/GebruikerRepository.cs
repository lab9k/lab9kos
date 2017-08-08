using System.Collections.Generic;
using System.Linq;
using lab9kos.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace lab9kos.Data.Repositories
{
    public class GebruikerRepository : IGebruikerRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Gebruiker> _gebruikers;

        public GebruikerRepository(ApplicationDbContext context)
        {
            _context = context;
            _gebruikers = context.Gebruikers;
        }

        public Gebruiker GetByEmail(string email) => _gebruikers
            .Include(g => g.Werkweken)
            .Include(g => g.Taken)
            .First(g => g.Email.Equals(email));

        public ICollection<Gebruiker> GetAll() => _gebruikers
            .Include(g => g.Werkweken)
            .Include(g => g.Taken)
            .ToList();

        public void SaveChanges() => _context.SaveChanges();
    }
}