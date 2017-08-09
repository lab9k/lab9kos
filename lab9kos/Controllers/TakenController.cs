﻿using System;
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
    }
}