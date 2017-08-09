﻿using System.Collections.Generic;
using System.Linq;
using lab9kos.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace lab9kos.Data.Repositories
{
    public class TaakRepository : ITaakRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Taak> _taken;

        public TaakRepository(ApplicationDbContext context)
        {
            _context = context;
            _taken = context.Taken;
        }

        public void AddTaak(Taak taak)
        {
            _context.Add(taak);
        }

        public Taak GetBy(int id) => _taken
            .Include(w => w.Gebruikers)
            .First(w => w.Id == id);

        public void RemoveTaak(Taak taak)
        {
            _context.Remove(taak);
        }

        public List<Taak> GetAllWithNiveau(TaakRealisatieNiveau niveau)
        {
            return _taken
                .Where(t => t.TaakRealisatieNiveau == niveau)
                .Include(t => t.Gebruikers)
                .ToList();
        }

        public IEnumerable<Taak> GetAll()
        {
            return _taken.ToList();
        }


        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}