using Microsoft.AspNetCore.Mvc;

namespace lab9kos.Controllers
{
    public class UrenController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}