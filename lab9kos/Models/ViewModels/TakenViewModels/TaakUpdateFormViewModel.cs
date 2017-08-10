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
        public TaakRealisatieNiveau TaakRealisatieNiveau { get; set; }
        public SelectList Niveaus { get; set; }

        public TaakUpdateFormViewModel(long id, string titel, string beschrijving, TaakRealisatieNiveau? niveau)
        {
            Id = id;
            Titel = titel;
            Beschrijving = beschrijving;
            TaakRealisatieNiveau = niveau ?? TaakRealisatieNiveau.Todo;
            Niveaus = new SelectList(new List<TaakRealisatieNiveau>()
            {
                TaakRealisatieNiveau.Todo,
                TaakRealisatieNiveau.Inprogress,
                TaakRealisatieNiveau.Inprogress,
                TaakRealisatieNiveau.Done
            }, niveau ?? TaakRealisatieNiveau.Todo);
        }
    }
}