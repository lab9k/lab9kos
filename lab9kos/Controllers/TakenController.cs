using System;
using System.Linq;
using System.Threading.Tasks;
using ASP;
using lab9kos.Filters;
using lab9kos.Models.Domain;
using lab9kos.Models.ViewModels.TakenViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace lab9kos.Controllers
{
    public class TakenController : Controller
    {
        private readonly ITaakRepository _taakRepository;
        private readonly UserManager<Gebruiker> _userManager;

        public TakenController(ITaakRepository taakRepository, UserManager<Gebruiker> userManager)
        {
            _taakRepository = taakRepository;
            _userManager = userManager;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Index()
        {
            var ivm = new IndexViewModel()
            {
                Todo = _taakRepository.GetAllWithNiveau(TaakRealisatieNiveau.Todo),
                InProgress = _taakRepository.GetAllWithNiveau(TaakRealisatieNiveau.Inprogress),
                NeedsReview = _taakRepository.GetAllWithNiveau(TaakRealisatieNiveau.Needsreview),
                Done = _taakRepository.GetAllWithNiveau(TaakRealisatieNiveau.Done),
                CurrentUserId = long.Parse(_userManager.GetUserId(User))
            };
            return View(ivm);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Index(TaakUpdateFormViewModel tufvm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var taakToUpdate = _taakRepository.GetBy(tufvm.Id);
                    taakToUpdate.Titel = tufvm.Titel;
                    taakToUpdate.Beschrijving = tufvm.Beschrijving;
                    taakToUpdate.Url = tufvm.Url;
                    _taakRepository.SaveChanges();
                    TempData["success"] = "success!";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception)
                {
                    TempData["error"] = "er is iets misgegaan, raadpleeg Jef";
                    return RedirectToAction(nameof(Index));
                }
            }
            TempData["error"] = "er is iets misgegaan, raadpleeg Jef";
            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        public IActionResult Add()
        {
            _taakRepository.AddTaak(Taak.CreateDummyTaak());
            _taakRepository.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ServiceFilter(typeof(AjaxFilter))]
        public IActionResult ChangeTaakNiveau(bool isAjax, ChangeTaakRealisatieViewModel ctrvm)
        {
            if (!isAjax) throw new ArgumentException("Only ajax allowed");
            var taak = _taakRepository.GetBy(ctrvm.TaakId);
            taak.SwitchNiveau(ctrvm.KolomId);
            _taakRepository.SaveChanges();
            return Json(new {success = true});
        }

        [HttpPost]
        [ServiceFilter(typeof(AjaxFilter))]
        public IActionResult RemoveTaak(bool isAjax, RemoveTaakViewModel rtvm)
        {
            if (!isAjax) throw new ArgumentException("Moet Ajax zijn");
            try
            {
                var taak = _taakRepository.GetBy(rtvm.TaakId);
                _taakRepository.RemoveTaak(taak);
                _taakRepository.SaveChanges();
            }
            catch (Exception e)
            {
                return Json(new
                {
                    success = false,
                    message = e.Message
                });
            }
            return Json(new {success = true});
        }

        [HttpPost]
        [ServiceFilter(typeof(AjaxFilter))]
        public async Task<IActionResult> Sub(bool isAjax, RemoveTaakViewModel rtvm)
        {
            if (!isAjax) throw new ArgumentException("Moet Ajax zijn");
            try
            {
                var taak = _taakRepository.GetBy(rtvm.TaakId);
                var user = await _userManager.GetUserAsync(User);
                taak.AddGebruiker(user);
                _taakRepository.SaveChanges();

                return PartialView("_TaakGebruikers", taak.Gebruikers.Select(t => t.Gebruiker));
            }
            catch (Exception e)
            {
                return Json(new
                {
                    success = false,
                    message = e.Message
                });
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(AjaxFilter))]
        public async Task<IActionResult> Unsub(bool isAjax, RemoveTaakViewModel rtvm)
        {
            if (!isAjax) throw new ArgumentException("Moet Ajax zijn");
            try
            {
                var taak = _taakRepository.GetBy(rtvm.TaakId);
                var user = await _userManager.GetUserAsync(User);
                _taakRepository.RemoveTaakGebruiker(taak.Gebruikers.First(g => g.GebruikerId == user.Id));
                _taakRepository.SaveChanges();

                return PartialView("_TaakGebruikers", taak.Gebruikers.Select(t => t.Gebruiker));
            }
            catch (Exception e)
            {
                return Json(new
                {
                    success = false,
                    message = e.Message
                });
            }
        }
    }
}