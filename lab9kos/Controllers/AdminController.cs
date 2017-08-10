using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using FluentEmail.Core;
using FluentEmail.Mailgun;
using lab9kos.Models.Domain;
using lab9kos.Models.ViewModels.AdminViewModels;
using lab9kos.Util;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Configuration;

namespace lab9kos.Controllers
{
    [Authorize("AdminOnly")]
    public class AdminController : Controller
    {
        private readonly IWerkweekRepository _werkweekRepository;
        private readonly IConfiguration _configuration;
        private readonly UserManager<Gebruiker> _userManager;
        private readonly IGebruikerRepository _gebruikerRepository;

        public AdminController(UserManager<Gebruiker> userManager,
            IWerkweekRepository werkweekRepository, IConfiguration configuration,
            IGebruikerRepository gebruikerRepository)
        {
            _userManager = userManager;
            _configuration = configuration;
            _werkweekRepository = werkweekRepository;
            _gebruikerRepository = gebruikerRepository;
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
            string Inhoud = "Dag Sabine \n\n";
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
            Inhoud += "\n Met vriendelijke groeten \n\n Hans Fraiponts";
            WekenViewModel wvm = new WekenViewModel
            {
                Inhoud = Inhoud,
                Ontvanger = _configuration.GetSection("Mailgun").GetSection("ontvanger").Value
            };
            return View(wvm);
        }

        [HttpPost]
        public async Task<IActionResult> VerstuurMail(WekenViewModel wvm)
        {
            String mailgunKey = _configuration.GetSection("Mailgun").GetSection("key").Value;
            String domain = _configuration.GetSection("Mailgun").GetSection("domain").Value;
            if (ModelState.IsValid)
            {
                var sender = new MailgunSender(
                    domain,
                    mailgunKey
                );
                Email.DefaultSender = sender;
                var email = Email
                    .From("noreply@mail.lab9k.gent", "Hans Fraiponts")
                    .To(wvm.Ontvanger)
                    .Subject("Werkuren Jobstudenten Lab9K")
                    .Body(wvm.Inhoud);
                var response = await email.SendAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(wvm);
            }
        }

        public IActionResult VoegAdminToe()
        {
            return View(new VoegAdminToeViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> VoegAdminToe(VoegAdminToeViewModel vam)
        {
            if (ModelState.IsValid)
            {
                Gebruiker g = _gebruikerRepository.GetByEmail(vam.Email);
                if (g != null)
                {
                    IList<Claim> claimsUser = await _userManager.GetClaimsAsync(g);
                    bool isAdmin = claimsUser.FirstOrDefault(c => c.Value == "admin") != null;
                    if (!isAdmin)
                    {
                        await _userManager.AddClaimAsync(g, new Claim(ClaimTypes.Role, "admin"));
                        return RedirectToAction(nameof(Index));
                    }
                    ModelState.AddModelError("GebruikerAlAdmin", "Deze gebruiker is al Admin");

                    return View(vam);
                }
                ModelState.AddModelError("GebruikerNull", "Deze gebruiker zit niet in het systeem");
                return View(vam);
            }
            else
            {
                return View(vam);

            }
        }

    }
}