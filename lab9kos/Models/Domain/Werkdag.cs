using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab9kos.Models.Domain
{
    public class Werkdag
    {
        public long Id { get; set; }
        public DateTime Datum { get; set; }
        public int AantalUren { get; set; }

        public Gebruiker Werknemer { get; set; }
    }
}
