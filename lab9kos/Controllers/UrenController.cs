using System;
using lab9kos.Models.Domain;
using lab9kos.Models.ViewModels.UrenViewModels;
using Microsoft.AspNetCore.Mvc;

namespace lab9kos.Controllers
{
    public class UrenController : Controller
    {
        private IGebruikerRepository _gebruikerRepository;

        public UrenController(IGebruikerRepository gebruikerRepository)
        {
            _gebruikerRepository = gebruikerRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var ivm = new IndexViewModel()
            {
                Gebruikers = _gebruikerRepository.GetAll()
            };
            return View(ivm);
        }
    }
}