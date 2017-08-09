using System;
using System.Globalization;
using lab9kos.Models.Domain;
using lab9kos.Models.ViewModels.UrenViewModels;
using lab9kos.Util;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace lab9kos.Controllers
{
    public class UrenController : Controller
    {
        private readonly IWerkweekRepository _werkweekRepository;

        public UrenController(IWerkweekRepository werkweekRepository)
        {
            _werkweekRepository = werkweekRepository;
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
                Datum = datum
            };
            return View(ivm);
        }

        public IActionResult Edit(long id)
        {
            Werkweek week = _werkweekRepository.GetById(id);
            var evm = new EditViewModel()
            {
                Id = id,
                Maandag = week.Maandag,
                Dinsdag = week.Dinsdag,
                Woensdag = week.Woensdag,
                Donderdag = week.Donderdag,
                Vrijdag = week.Vrijdag
            };
            return View(evm);
        }

        [HttpPost]
        public IActionResult Edit(EditViewModel evm)
        {
            if (ModelState.IsValid)
            {
                Werkweek week = _werkweekRepository.GetById(evm.Id);
                week.Maandag = evm.Maandag;
                week.Dinsdag = evm.Dinsdag;
                week.Woensdag = evm.Woensdag;
                week.Donderdag = evm.Donderdag;
                week.Vrijdag = evm.Vrijdag;
                _werkweekRepository.SaveChanges();
                TempData["success"] = "Succesvol geëditeerd";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }
    }
}