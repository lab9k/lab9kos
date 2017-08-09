using lab9kos.Filters;
using lab9kos.Models.Domain;
using lab9kos.Models.ViewModels.TakenViewModels;
using Microsoft.AspNetCore.Mvc;

namespace lab9kos.Controllers
{
    public class TakenController : Controller
    {
        private readonly ITaakRepository _taakRepository;

        public TakenController(ITaakRepository taakRepository)
        {
            _taakRepository = taakRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var ivm = new IndexViewModel()
            {
                Todo = _taakRepository.GetAllWithNiveau(TaakRealisatieNiveau.Todo),
                InProgress = _taakRepository.GetAllWithNiveau(TaakRealisatieNiveau.Inprogress),
                NeedsReview = _taakRepository.GetAllWithNiveau(TaakRealisatieNiveau.Needsreview),
                Done = _taakRepository.GetAllWithNiveau(TaakRealisatieNiveau.Done)
            };
            return View(ivm);
        }

        [HttpPost]
        [ServiceFilter(typeof(AjaxFilter))]
        public IActionResult Index(bool isAjax)
        {
            return null;
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddViewModel avm)
        {
            return RedirectToAction(nameof(Index));
        }
    }
}