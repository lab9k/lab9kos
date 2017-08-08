using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace lab9kos.Models.Domain
{
    public class Gebruiker : IdentityUser<long>
    {
        public string Naam { get; set; }
        public string Voornaam { get; set; }
        public List<Werkdag> Werkdagen { get; set; }

        public List<TaakGebruiker> Taken { get; set; }
    }
}