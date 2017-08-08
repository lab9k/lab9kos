using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace lab9kos.Models.Domain
{
    public class Gebruiker : IdentityUser<long>
    {
        public string Naam { get; set; }
        public string Voornaam { get; set; }
        public ICollection<Werkweek> Werkweken { get; set; }
        public ICollection<TaakGebruiker> Taken { get; set; }
    }
}