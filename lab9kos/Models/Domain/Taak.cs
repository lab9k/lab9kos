using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;

namespace lab9kos.Models.Domain
{
    public class Taak
    {
        public long Id { get; set; }
        public string Titel { get; set; }
        public string Beschrijving { get; set; }
        public List<TaakGebruiker> Gebruikers { get; set; }
        public TaakRealisatieNiveau TaakRealisatieNiveau { get; set; }

        public Taak()
        {
            Gebruikers = new List<TaakGebruiker>();
            TaakRealisatieNiveau = TaakRealisatieNiveau.Todo;
        }

        public static Taak CreateDummyTaak()
        {
            return new Taak()
            {
                Titel = "Nieuwe Taak",
                Beschrijving = "Nieuwe Taak",
                Gebruikers = new List<TaakGebruiker>(),
                TaakRealisatieNiveau = TaakRealisatieNiveau.Todo
            };
        }

        public void SwitchNiveau(int kolomId)
        {
            switch (kolomId)
            {
                case 1:
                    TaakRealisatieNiveau = TaakRealisatieNiveau.Todo;
                    break;
                case 2:
                    TaakRealisatieNiveau = TaakRealisatieNiveau.Inprogress;
                    break;
                case 3:
                    TaakRealisatieNiveau = TaakRealisatieNiveau.Needsreview;
                    break;
                case 4:
                    TaakRealisatieNiveau = TaakRealisatieNiveau.Done;
                    break;
                default:
                    break;
            }
        }

        public void AddGebruiker(Gebruiker user)
        {
            Gebruikers.Add(new TaakGebruiker()
            {
                Gebruiker = user,
                Taak = this,
            });
        }
    }
}