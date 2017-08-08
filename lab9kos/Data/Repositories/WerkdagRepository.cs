using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using lab9kos.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace lab9kos.Data.Repositories
{
    public class WerkdagRepository : IWerkdagRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Werkdag> _werkdagen;
        public WerkdagRepository(ApplicationDbContext context)
        {
            _context = context;
            _werkdagen = context.Werkdagen;
        }

        private static int GetIso8601WeekOfYear(DateTime time)
        {
            DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(time);
            if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
            {
                time = time.AddDays(3);
            }
            return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }

        public List<Werkdag> GetByWeek(DateTime week)
        {
            int weekNummer = GetIso8601WeekOfYear(week);
            return _werkdagen.Where(w => GetIso8601WeekOfYear(w.Datum) == weekNummer).ToList();
        }

        public List<Werkdag> GetByGebruiker(Gebruiker gebruiker)
        {
            return _werkdagen.Where(w => w.Werknemer.Equals(gebruiker)).ToList();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void AddWerkDag(Werkdag werkdag)
        {
            _werkdagen.Add(werkdag);
        }
    }
}
