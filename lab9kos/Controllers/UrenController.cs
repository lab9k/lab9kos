using System;
using Microsoft.AspNetCore.Mvc;

namespace lab9kos.Controllers
{
    public class UrenController : Controller
    {
        // GET
        public IActionResult Index()
        {
            var random = new Random();
            if (random.NextDouble() > 0.5)
            {
                TempData["success"] = "Proficiat!";
            }
            else
            {
                TempData["error"] = "Damn son!";
            }
            return View();
        }
    }
}