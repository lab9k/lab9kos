using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lab9kos.Models.Domain;
using lab9kos.Models.ViewModels.AdminViewModels;
using lab9kos.Util;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace lab9kos.Controllers
{
    [Authorize("AdminOnly")]
    public class AdminController : Controller
    {
        private readonly IWerkweekRepository _werkweekRepository;
        public AdminController(IWerkweekRepository werkweekRepository)
        {
            _werkweekRepository = werkweekRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult VerstuurMail()
        {
            var nu = DateTime.Now;
            var volgende = DateTime.Now.AddDays(7);
            IList<Werkweek> nuWeken = _werkweekRepository.GetByDate(nu);
            IList<Werkweek> volgendeWeken = _werkweekRepository.GetByDate(volgende);
            string Inhoud = "Dag Sabine, \n\n";
            Inhoud += "De gepresteerde uren deze week: \n\n";
            foreach (Werkweek week in nuWeken)
            {
                Inhoud += week.ToReadableFormat();
            }
            Inhoud += "\nDe uren voor volgende week: \n\n";
            foreach (Werkweek week in volgendeWeken)
            {
                Inhoud += week.ToReadableFormat();
            }
            Inhoud += "\n Met vriendelijke groet, \n\n Hans Fraiponts";
            WekenViewModel wvm = new WekenViewModel
            {
                Inhoud = Inhoud
            };
            return View(wvm);
        }
    }
}