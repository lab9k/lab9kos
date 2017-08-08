using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab9kos.Models.Domain
{
    public class Taak
    {
        public long Id { get; set; }
        public string Titel { get; set; }
        public string Beschrijving { get; set; }
        public List<TaakGebruiker> Gebruikers { get; set; }
    }
}
