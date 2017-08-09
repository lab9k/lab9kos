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

                var week1 = new Werkweek
                {
                    StartDatum = DateTime.Now,
                    Maandag = 8,
                    Dinsdag = 7,
                    Woensdag = 8,
                    Donderdag = 7,
                    Vrijdag = 8
                };
                var wim1 = new Gebruiker
                {
                    Voornaam = "Ruben",
                    Naam = "Vervust",
                    Email = "wimd3etroyer@gmail.com",
                    UserName = "wimd3etroyer@gmail.com"
                };
                var week2 = new Werkweek
                {
                    StartDatum = DateTime.Now,
                    Maandag = 8,
                    Dinsdag = 7,
                    Woensdag = 8,
                    Donderdag = 7,
                    Vrijdag = 8
                };
                var wim2 = new Gebruiker
                {
                    Voornaam = "Jef",
                    Naam = "Willems",
                    Email = "wimd2etroyer@gmail.com",
                    UserName = "wimd2etroyer@gmail.com"
                };
                await _userManager.CreateAsync(wim, "lollol");
                await _userManager.CreateAsync(wim1, "lollol");
                await _userManager.CreateAsync(wim2, "lollol");

                var vorigeweek = new Werkweek
                {
                    StartDatum = DateTime.Now.AddDays(7),
                    Maandag = 8,
                    Dinsdag = 7,
                    Woensdag = 8,
                    Donderdag = 7,
                    Vrijdag = 8
                };


                var volgendeweek = new Werkweek
                {
                    StartDatum = DateTime.Now.AddDays(-7),
                    Maandag = 8,
                    Dinsdag = 7,
                    Woensdag = 8,
                    Donderdag = 7,
                    Vrijdag = 8
                };
                wim.AddWerkWeek(week);
                wim.AddWerkWeek(vorigeweek);
                wim.AddWerkWeek(volgendeweek);

                wim1.AddWerkWeek(week1);
                wim2.AddWerkWeek(week2);

                //_context.Gebruikers.Add(wim);
                _context.Werkweken.Add(week);
                _context.Werkweken.Add(week1);
                _context.Werkweken.Add(week2);
                _context.Werkweken.Add(volgendeweek);
                _context.Werkweken.Add(vorigeweek);

                _context.SaveChanges();
            }
        }
    }
}