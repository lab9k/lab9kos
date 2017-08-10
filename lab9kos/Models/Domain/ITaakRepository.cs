using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab9kos.Models.Domain
{
    public interface ITaakRepository
    {
        void AddTaak(Taak taak);
        Taak GetBy(long id);
        void RemoveTaak(Taak taak);
        void RemoveTaakGebruiker(TaakGebruiker taakGebruiker);
        List<Taak> GetAllWithNiveau(TaakRealisatieNiveau niveau);
        IEnumerable<Taak> GetAll();
        void SaveChanges();
    }
}