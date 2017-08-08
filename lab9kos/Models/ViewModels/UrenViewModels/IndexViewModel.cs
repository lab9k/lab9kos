using System.Collections.Generic;
using lab9kos.Models.Domain;

namespace lab9kos.Models.ViewModels.UrenViewModels
{
    public class IndexViewModel
    {
        public int WeekNummer { get; set; }
        public ICollection<Werkweek> Werkweken { get; set; }
    }
}