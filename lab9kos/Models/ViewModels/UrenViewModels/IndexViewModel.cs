using System;
using System.Collections.Generic;
using System.Security.Principal;
using lab9kos.Models.Domain;

namespace lab9kos.Models.ViewModels.UrenViewModels
{
    public class IndexViewModel
    {

        public DateTime Datum { get; set; }
        public ICollection<Werkweek> Werkweken { get; set; }
    }
}