using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using lab9kos.Models.Domain;
using lab9kos.Util;
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

        public List<Werkweek> GetByDate(DateTime date) => _werkdagen
            .Where(w => w.GetWeekNummer() == DateUtilities.GetIso8601WeekOfYear(date) && w.GetYear() == date.Year)
            .Include(w => w.Werknemer)
            .ToList();

        public List<Werkweek> GetByGebruiker(Gebruiker gebruiker) => _werkdagen
            .Where(w => w.Werknemer.Equals(gebruiker))
            .Include(w => w.Werknemer)
            .ToList();

        public Werkweek GetById(long id) => _werkdagen
            .Where(w => w.Id == id)
            .FirstOrDefault();

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