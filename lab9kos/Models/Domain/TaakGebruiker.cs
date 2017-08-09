using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab9kos.Models.Domain
{
    public class TaakGebruiker
    {

        public long TaakId { get; set; }
        public Taak Taak { get; set; }

        public long GebruikerId { get; set; }
        public Gebruiker Gebruiker { get; set; }

        
    }
}
