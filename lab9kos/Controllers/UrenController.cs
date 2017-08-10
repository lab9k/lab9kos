using System;
using System.Globalization;
using System.Security;
using System.Security.Authentication;
using System.Security.Claims;
using System.Threading.Tasks;
using lab9kos.Models.Domain;
using lab9kos.Models.ViewModels.UrenViewModels;
using lab9kos.Util;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace lab9kos.Controllers
{
    [Authorize]
    public class UrenController : Controller
    {
        private readonly IWerkweekRepository _werkweekRepository;
        private readonly IGebruikerRepository _gebruikerRepository;
        private readonly UserManager<Gebruiker> _userManager;
        public UrenController(IWerkweekRepository werkweekRepository, IGebruikerRepository gebruikerRepository, UserManager<Gebruiker> userManager)
        {
            _werkweekRepository = werkweekRepository;
            _gebruikerRepository = gebruikerRepository;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index(long unixTimeStamp = 0)
        {
            var datum = DateTime.Now;
            if (unixTimeStamp != 0)
            {
                datum = DateTimeOffset.FromUnixTimeSeconds(unixTimeStamp).DateTime;
            }

            var ivm = new IndexViewModel()
            {
                Werkweken = _werkweekRepository.GetByDate(datum),
                Datum = datum,
            };
            return View(ivm);
        }

        public IActionResult Edit(long id)
        {
            Werkweek week = _werkweekRepository.GetById(id);
            if (week.Werknemer.Id != Convert.ToInt64(_userManager.GetUserId(User)) && !User.IsInRole("admin"))
            {
                throw new AuthenticationException("Niet geauthoriseerd");

            }

            var evm = new EditViewModel()
            {
                Id = id,
                Maandag = week.Maandag,
                Dinsdag = week.Dinsdag,
                Woensdag = week.Woensdag,
                Donderdag = week.Donderdag,
                Vrijdag = week.Vrijdag
            };
            ViewData["Title"] = "Wijzig bestaand uurrooster";
            return View(evm);
        }

        [HttpPost]
        public IActionResult Edit(EditViewModel evm)
        {
            if (ModelState.IsValid)
            {
                Werkweek week = _werkweekRepository.GetById(evm.Id.Value);
                week.Maandag = evm.Maandag;
                week.Dinsdag = evm.Dinsdag;
                week.Woensdag = evm.Woensdag;
                week.Donderdag = evm.Donderdag;
                week.Vrijdag = evm.Vrijdag;
                _werkweekRepository.SaveChanges();
                TempData["success"] = "Succesvol geëditeerd";
                return RedirectToAction(nameof(Index),new {unixTimeStamp = evm.DateTimeStamp});
            }
            else
            {
                return View();
            }
        }

        public IActionResult Create(long unixTimeStamp)
        {
            var evm = new EditViewModel()
            {
                DateTimeStamp = unixTimeStamp
            };
            ViewData["Title"] = "Maak nieuw uurrooster";
            return View(nameof(Edit), evm);
        }

        [HttpPost]
        public IActionResult Create(EditViewModel evm)
        {
            if (ModelState.IsValid)
            {
                Werkweek week = MapEditViewModelToWerkWeek(evm);
                _werkweekRepository.AddWerkWeek(week);
                _werkweekRepository.SaveChanges();
                TempData["success"] = "Succesvol Gemaakt!";
                return RedirectToAction(nameof(Index), new { unixTimeStamp = evm.DateTimeStamp });
            }
            else
            {
                return View(nameof(Edit), evm);
            }
        }

        private Werkweek MapEditViewModelToWerkWeek(EditViewModel evm)
        {
            return new Werkweek()
            {
                Werknemer = _gebruikerRepository.GetById(Convert.ToInt64(_userManager.GetUserId(User))),
                Maandag = evm.Maandag,
                Dinsdag = evm.Dinsdag,
                Woensdag = evm.Woensdag,
                Donderdag = evm.Donderdag,
                Vrijdag = evm.Vrijdag,
                StartDatum = DateTimeOffset.FromUnixTimeSeconds(evm.DateTimeStamp).DateTime
            };
        }
    }
}