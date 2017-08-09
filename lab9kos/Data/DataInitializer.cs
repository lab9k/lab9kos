using System;
using System.Threading.Tasks;
using lab9kos.Models;
using lab9kos.Models.Domain;
using Microsoft.AspNetCore.Identity;

namespace lab9kos.Data
{
    public class DataInitializer
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<Gebruiker> _userManager;

        public DataInitializer(ApplicationDbContext context, UserManager<Gebruiker> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task InitializeData()
        {
            _context.Database.EnsureDeleted();
            if (_context.Database.EnsureCreated())
            {
                var week = new Werkweek
                {
                    StartDatum = DateTime.Now,
                    Maandag = 8,
                    Dinsdag = 7,
                    Woensdag = 8,
                    Donderdag = 7,
                    Vrijdag = 8
                };
                var wim = new Gebruiker
                {
                    Voornaam = "Wim",
                    Naam = "De Troyer",
                    Email = "wimdetroyer@gmail.com",
                    UserName = "wimdetroyer@gmail.com"
                };

                await _userManager.CreateAsync(wim, "lollol");
                wim.AddWerkWeek(week);
                //_context.Gebruikers.Add(wim);
                _context.Werkweken.Add(week);
                _context.SaveChanges();
            }
        }
    }
}