using System.Collections.Generic;
using lab9kos.Models.Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace lab9kos.Models.ViewModels.TakenViewModels
{
    public class TaakUpdateFormViewModel
    {
        public long Id { get; set; }
        public string Titel { get; set; }
        public string Beschrijving { get; set; }
        public string Url { get; set; }

        public TaakUpdateFormViewModel()
        {
        }
    }
}