using System;
using lab9kos.Models.ViewModels.UrenViewModels;
using Microsoft.AspNetCore.Mvc;

namespace lab9kos.Controllers
{
    public class UrenController : Controller
    {
        // GET
        public IActionResult Index()
        {
            var ivm = new IndexViewModel();
            return View(ivm);
        }
    }
}