using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using lab9kos.Models;
using lab9kos.Models.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace lab9kos.Data
{
    public class DataInitializer
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<Gebruiker> _userManager;
        private readonly IConfiguration _configuration;

        public DataInitializer(ApplicationDbContext context, UserManager<Gebruiker> userManager,
            IConfiguration configuration)
        {
            _context = context;
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task ReleaseInitializeData()
        {
            _context.Database.EnsureDeleted();
            if (_context.Database.EnsureCreated())
            {
                var hans = new Gebruiker
                {
                    Voornaam = "Hans",
                    Naam = "Fraiponts",
                    Email = "hans.fraiponts@digipolis.gent",
                    UserName = "hans.fraiponts@digipolis.gent"
                };

                var sabine = new Gebruiker
                {
                    Voornaam = "Sabine",
                    Naam = "Braat",
                    Email = "Sabine.Braat@digipolis.be",
                    UserName = "Sabine.Braat@digipolis.be"
                };
                await _userManager.CreateAsync(hans,
                    _configuration.GetSection("InitialSeedInfo").GetSection("password").Value);
                await _userManager.CreateAsync(sabine,
                    _configuration.GetSection("InitialSeedInfo").GetSection("password").Value);

                await _userManager.AddClaimAsync(hans, new Claim(ClaimTypes.Role, "admin"));
            }
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


                var adminGebruiker = new Gebruiker
                {
                    Voornaam = "Hans",
                    Naam = "Fraiponts",
                    Email = "hansf@gmail.com",
                    UserName = "hansf@gmail.com"
                };

                await _userManager.CreateAsync(adminGebruiker, "hanshans");
                await _userManager.AddClaimAsync(adminGebruiker, new Claim(ClaimTypes.Role, "admin"));

                await _userManager.CreateAsync(wim, "lollol");
                await _userManager.AddClaimAsync(wim, new Claim(ClaimTypes.Role, "admin"));

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

                var taak = new Taak()
                {
                    TaakRealisatieNiveau = TaakRealisatieNiveau.Needsreview,
                    Beschrijving = "dependencies opruimen, code documenteren, nog veel andere kleine dingen",
                    Titel = "Opruimen website"
                };

                var taakGebruiker = new TaakGebruiker()
                {
                    Gebruiker = wim,
                    Taak = taak
                };
                var taakGebruiker2 = new TaakGebruiker()
                {
                    Gebruiker = wim1,
                    Taak = taak
                };
                ;
                _context.TaakGebruikers.Add(taakGebruiker);
                _context.TaakGebruikers.Add(taakGebruiker2);

                _context.Taken.Add(taak);
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