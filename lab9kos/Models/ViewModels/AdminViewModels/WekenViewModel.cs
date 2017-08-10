using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lab9kos.Models.Domain;

namespace lab9kos.Models.ViewModels.AdminViewModels
{
    public class WekenViewModel
    {
        public String Ontvanger { get; set; } = "Sabine.Braat@digipolis.be";

        public String Inhoud { get; set; } = "heee";
        public IList<Werkweek> WekenNu { get; set; }

        public IList<Werkweek> WekenVolgendeWeek { get; set; }
    }
}
