using System.Collections.Generic;
using lab9kos.Models.Domain;

namespace lab9kos.Models.ViewModels.UrenViewModels
{
    public class IndexViewModel
    {
        public ICollection<Gebruiker> Gebruikers { get; set; }
    }
}