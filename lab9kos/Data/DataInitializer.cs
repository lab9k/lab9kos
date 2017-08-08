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
                Werkweek week = new Werkweek();
                Gebruiker wim = new Gebruiker();
                wim.Naam = "De Troyer";
                wim.Voornaam = "Wim";
                wim.Email = "wimdetroyer@gmail.com";
                wim.UserName = "wimdetroyer@gmail.com";;
                await _userManager.CreateAsync(wim, "lol");
                week.StartDatum = DateTime.Now;
                week.Maandag = 8;
                week.Dinsdag = 7;
                week.Woensdag = 8;
                week.Donderdag = 7;
                week.Werknemer = wim;
                _context.Gebruikers.Add(wim);
                _context.Werkweken.Add(week);
                //TODO add data
                _context.SaveChanges();
            }
        }
    }
}