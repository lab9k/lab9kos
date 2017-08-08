using System;
using System.Globalization;
using lab9kos.Models.Domain;
using lab9kos.Models.ViewModels.UrenViewModels;
using lab9kos.Util;
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
        public IActionResult Index()
        {
            var weekNummer = DateUtilities.GetIso8601WeekOfYear(DateTime.Now);
            var ivm = new IndexViewModel()
            {
                Werkweken = _werkweekRepository.GetByWeek(weekNummer),
                WeekNummer = weekNummer
            };
            return View(ivm);
        }
    }
}