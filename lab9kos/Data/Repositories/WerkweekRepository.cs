using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using lab9kos.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace lab9kos.Data.Repositories
{
    public class WerkweekRepository : IWerkweekRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Werkweek> _werkdagen;

        public WerkweekRepository(ApplicationDbContext context)
        {
            _context = context;
            _werkdagen = context.Werkweken;
        }

        public List<Werkweek> GetByWeek(int week)
        {
            return _werkdagen.Where(w => w.GetWeekNummer() == week).ToList();
        }

        public List<Werkweek> GetByGebruiker(Gebruiker gebruiker)
        {
            return _werkdagen.Where(w => w.Werknemer.Equals(gebruiker)).ToList();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void AddWerkDag(Werkweek werkdag)
        {
            _werkdagen.Add(werkdag);
        }
    }
}