using System.Collections.Generic;
using lab9kos.Models.Domain;

namespace lab9kos.Models.ViewModels.AdminViewModels
{
    public class AccountsOverzichtViewModel
    {
        public IEnumerable<Gebruiker> Gebruikers { get; set; }
    }
}